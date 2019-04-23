using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using CloudApi.ToolHelper;

namespace CloudApi.Providers
{
    public class OpenRefreshTokenProvider : AuthenticationTokenProvider
    {
        private static ConcurrentDictionary<string, string> _refreshTokens = null;

        public static ConcurrentDictionary<string, string> refreshTokens
        {
            get
            {
                if (_refreshTokens == null || _refreshTokens.Count() == 0)
                {
                    int k = 0;
                ReLoadFromRedis:
                    if (k < 3)
                    {
                        try
                        {
                            using (var client = RedisManager.GetClient())
                            {

                                string RefreshTokensKey = System.Configuration.ConfigurationManager.AppSettings["RefreshTokensKey"] + "";
                                if (string.IsNullOrEmpty(RefreshTokensKey))
                                {
                                    RefreshTokensKey = "RefreshTokensKey";
                                }

                                var templss = client.Get<ConcurrentDictionary<string, string>>(RefreshTokensKey);

                                if (templss == null)
                                {
                                    templss = new ConcurrentDictionary<string, string>();
                                }
                                _refreshTokens = templss;
                            }
                        }
                        catch (Exception)
                        {
                            k++;
                            Thread.Sleep(100);
                            goto ReLoadFromRedis;
                        }
                    }
                    else
                    {
                        _refreshTokens = new ConcurrentDictionary<string, string>();
                    }

                    return _refreshTokens;
                }
                else
                {
                    return _refreshTokens;
                }
            }
            set
            {
                _refreshTokens = value;
            }
        }
        

        /// <summary>
        /// 生成 refresh_token
        /// </summary>
        public override void Create(AuthenticationTokenCreateContext context)
        {
            context.Ticket.Properties.IssuedUtc = DateTime.UtcNow;
            context.Ticket.Properties.ExpiresUtc = DateTime.UtcNow.AddDays(60);

            var refreshToken = Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n");
          

            context.SetToken(refreshToken);
            
            var Ticket = context.SerializeTicket();
            refreshTokens.AddOrUpdate(context.Token, Ticket, (k, ov) => ov = Ticket);
        }


        /// <summary>
        /// 由 refresh_token 解析成 access_token
        /// </summary>
        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            string value;
            if (refreshTokens.TryRemove(context.Token, out value))
            {
                context.DeserializeTicket(value);
            }
        }
    }
}