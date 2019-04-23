using CloudApi.ToolHelper;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace CloudApi.Providers
{
    public class OpenAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 验证 client 信息
        /// </summary>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

         
            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
            {
                clientId = context.Parameters.Get("client_id");
                clientSecret = context.Parameters.Get("client_secret");
            }





            bool canOper = false;//是否可继续操作


            string cacheClientId = ToolHelper.CacheData.GetSysParamValue("AliGenieClientId_" + clientId);
            string cacheClientSecret = ToolHelper.CacheData.GetSysParamValue("AliGenieClientSecret_" + clientId);
            


            string commonClientId = ToolHelper.CacheData.GetSysParamValue("AliGenieClientId");
            string commonClientSecret = ToolHelper.CacheData.GetSysParamValue("AliGenieClientSecret");


            

            canOper = (clientId.Equals(cacheClientId) && clientSecret.Equals(cacheClientSecret)) || (clientId.Equals(commonClientId) && clientSecret.Equals(commonClientSecret));

            

            if (!canOper)
            {
                context.SetError("invalid_client", "client or clientSecret is not valid");
                return;
            }





            context.Validated();
        }



        /// <summary>
        /// 生成 access_token（client credentials 授权方式）
        /// </summary>
        public override async Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(
                context.ClientId, OAuthDefaults.AuthenticationType),
                context.Scope.Select(x => new Claim("urn:oauth:scope", x)));
            

            context.Validated(identity);
        }



        /// <summary>
        /// 生成 access_token（resource owner password credentials 授权方式） 这是输入账号密码的方式直接获取的
        /// </summary>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (string.IsNullOrEmpty(context.UserName))
            {
                context.SetError("invalid_username", "username is not valid");
                return;
            }
            if (string.IsNullOrEmpty(context.Password))
            {
                context.SetError("invalid_password", "password is not valid");
                return;
            }




            if (context.UserName != "xishuai" || context.Password != "123")
            {
                context.SetError("invalid_identity", "username or password is not valid");
                return;
            }

            var OAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            OAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            context.Validated(OAuthIdentity);
        }



        /// <summary>
        /// 生成 authorization_code（authorization code 授权方式）、生成 access_token （implicit 授权模式）
        /// </summary>
        public override async Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
        {
            if (context.AuthorizeRequest.IsImplicitGrantType)
            {
                //implicit 授权方式
                var identity = new ClaimsIdentity("Bearer");
                context.OwinContext.Authentication.SignIn(identity);
                context.RequestCompleted();
            }
            else if (context.AuthorizeRequest.IsAuthorizationCodeGrantType)
            {
                //authorization code 授权方式
                var redirectUri = context.Request.Query["redirect_uri"];
                var clientId = context.Request.Query["client_id"];
                string hostId = context.Request.Query["hostId"]+"";


                /*
                 * 这儿添加了对应的账号密码,sessionId等信息，额外保存起来.
                 * 其他传递的参数自行处理
                 */

                string account = context.Request.Query["account"] + "";
                string pwd = context.Request.Query["pwd"] + "";
                string sessionId=context.Request.Query["sessionId"]+"";

                var identity = new ClaimsIdentity(new GenericIdentity(
                    clientId, OAuthDefaults.AuthenticationType));
                
                var authorizeCodeContext = new AuthenticationTokenCreateContext(
                    context.OwinContext,
                    context.Options.AuthorizationCodeFormat,
                    new AuthenticationTicket(
                        identity,
                        new AuthenticationProperties(new Dictionary<string, string>
                        {
                            {"client_id", clientId},
                            {"redirect_uri", redirectUri}
                        })
                        {
                            IssuedUtc = DateTimeOffset.UtcNow,
                            ExpiresUtc = DateTimeOffset.UtcNow.Add(context.Options.AuthorizationCodeExpireTimeSpan)
                        }));

                
                await context.Options.AuthorizationCodeProvider.CreateAsync(authorizeCodeContext);


                var ResUrl = redirectUri;
                if (redirectUri.Contains("?"))
                {
                    ResUrl += "&code=" + Uri.EscapeDataString(authorizeCodeContext.Token);
                }
                else
                {
                    ResUrl += "?code=" + Uri.EscapeDataString(authorizeCodeContext.Token);
                }



                string code= authorizeCodeContext.Token;
                CacheData.SetFirstAuthCache(code, new Models.FirstAuthCacheModel() 
                {
                    AccountId=account,
                    ClientId=clientId,
                    Password=pwd,
                    SessionId = sessionId,
                    SessionCacheTime=DateTime.Now,
                    HostId=hostId
                });


                context.Response.Redirect(ResUrl);
                context.RequestCompleted();
            }
        }



        /// <summary>
        /// 验证 authorization_code 的请求
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateAuthorizeRequest(OAuthValidateAuthorizeRequestContext context)
        {
            if (CheckClientValidate(context.AuthorizeRequest.ClientId) && (context.AuthorizeRequest.IsAuthorizationCodeGrantType || context.AuthorizeRequest.IsImplicitGrantType))
            {
                context.Validated();
            }
            else
            {
                context.Rejected();
            }
        }

        


        /// <summary>
        /// 验证 redirect_uri
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            context.Validated(context.RedirectUri);
        }

        
        /// <summary>
        /// 验证 access_token 的请求
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
        {
            if (context.TokenRequest.IsAuthorizationCodeGrantType || context.TokenRequest.IsRefreshTokenGrantType || context.TokenRequest.IsResourceOwnerPasswordCredentialsGrantType)
            {
                context.Validated();
            }
            else
            {
                context.Rejected();
            }
        }



        public static bool CheckClientValidate(string clientId)
        {
            string cacheClientId = ToolHelper.CacheData.GetSysParamValue("AliGenieClientId_" + clientId);
            return cacheClientId.Equals(clientId);
        }
    }
}