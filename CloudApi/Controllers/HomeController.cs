using CloudApi.AliGenie;
using CloudApi.AliGenie.X1Handle;
using CloudApi.AliGenie.X1ReceviceModel;
using CloudApi.AliGenie.X1ReturnModel;
using CloudApi.AliGenie.X1ReturnModel.DeviceDiscover;
using CloudApi.AliGenie.X1ReturnModel.DeviceOper;
using CloudApi.ToolHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace CloudApi.Controllers
{
    public class HomeController : Controller
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }





        /// <summary>
        /// 登录页
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexLogin()
        {
            string clientId = Request.QueryString["client_id"] + "";
            string redirect_uri = Request.QueryString["redirect_uri"] + "";
            string response_type = Request.QueryString["response_type"] + "";
            string state = Request.QueryString["state"] + "";

            string error = Request.QueryString["error"]+"";

            bool canOper = CloudApi.Providers.OpenAuthorizationServerProvider.CheckClientValidate(clientId);//是否可继续操作
               

         
            if (!canOper)
            {
                return Redirect(redirect_uri);
            }



            /*
             * ?redirect_uri=https%3A%2F%2Fopen.bot.tmall.com%2Foauth%2Fcallback%3FskillId%3D11111111%26token%3DXXXXXXXXXX
             * &client_id=XXXXXXXXX
             * &response_type=code
             * &state=111
             */
            ViewBag.clientId = clientId;
            ViewBag.redirect_uri = redirect_uri;
            ViewBag.response_type = response_type;
            ViewBag.state = state;
            ViewBag.errorCode = error;

            return View();
        }

        

        /// <summary>
        /// 用户输入登录之后的检验
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index2()
        {
            string clientId = Request.Form["clientId"] + "";

            string response_type = Request.Form["response_type"] + "";

            string redirect_uri = Request.Form["redirect_uri"] + "";
            
            string state = Request.Form["state"] + "";

            string account= Request.Form["account"] + "";
            string password = Request.Form["password"] + "";


            string urlEncode = HttpUtility.UrlEncode(redirect_uri);


            bool canOper = CloudApi.Providers.OpenAuthorizationServerProvider.CheckClientValidate(clientId);//是否可继续操作

            if (!canOper)
            {
                return Redirect(redirect_uri);
            }


            bool yourLoginFun=true;
            if (yourLoginFun)
            {
                var TempHostId = "yourHostId";//要授权的网关ID或设备ID
                string sessionID = "";
                return Redirect("~/authorize?grant_type=authorization_code&response_type=code&client_id=" + clientId + "&account=" + account + "&pwd=" + password + "&sessionId=" + sessionID + "&hostId=" + TempHostId + "&redirect_uri=" + urlEncode);
            }
            else
            {
                return Redirect(Url.Action("IndexLogin") + "?client_id=" + clientId + "&redirect_uri=" + urlEncode + "&response_type=" + response_type + "&state=" + state + "&error=1");
            }
        }




        private readonly static string _serverUrl = System.Configuration.ConfigurationManager.AppSettings["serverUrl"];

        private readonly static string _serverExtUrlParam = System.Configuration.ConfigurationManager.AppSettings["serverExtUrlParam"];

        private readonly static Int64 _tokenExpressTime = Convert.ToInt64( "0"+System.Configuration.ConfigurationManager.AppSettings["tokenExpiresTime"]);



        /// <summary>
        /// 获取 access_token 的地址 (也可用于刷新access_token)
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> TestToken()
        {
            string grant_type = Request.Form["grant_type"] + "";
            string client_id = Request.Form["client_id"] + "";
            string client_secret = Request.Form["client_secret"] + "";
            string code = Request.Form["code"] + "";
            string redirect_uri = Request.Form["redirect_uri"] + "";
            string refreshToken = Request.Form["refresh_token"] + "";
            
            //刷新token 
            //https://XXXXX/token?grant_type=refresh_token&client_id=XXXXX&client_secret=XXXXXX&refresh_token=XXXXXX



            ToolHelper.FunctionHelper.writeLog("Form:", "grant_type:" + grant_type + "  code:" + code + "   refreshToken:" + refreshToken + "  client_id:" + client_id + "    client_secret:" + client_secret, "TestToken");

            var parameters = new Dictionary<string, string>();
            parameters.Add("grant_type", grant_type);


            if (!string.IsNullOrEmpty(code))
            {
                parameters.Add("code", code);

                parameters.Add("redirect_uri", redirect_uri);
            }

            


            if (!string.IsNullOrEmpty(refreshToken))
            {
                parameters.Add("refresh_token", refreshToken);
            }

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
            

            HttpClient _httpClient = new HttpClient();



            _httpClient.BaseAddress = new Uri(_serverUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(client_id + ":" + client_secret)));

            string tempUrl = "/token";
            if (!string.IsNullOrEmpty(_serverExtUrlParam + ""))
            {//这个参数是用于，如果发布到IIS上，是发布于子应用程序的话，serverExtUrlParam 就是对应的子应用程序的名称
                tempUrl = "/" + _serverExtUrlParam + "/token";
            }

            var response = await _httpClient.PostAsync(tempUrl, new FormUrlEncodedContent(parameters));
            



            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //去缓存里找它上一个授权的方式。。。。

                if (grant_type.Equals("refresh_token", StringComparison.OrdinalIgnoreCase))
                {
                    var newItem= CacheData.GetAccessTokenByOldRefreshToken(refreshToken);
                    if (newItem != null)
                    {
                        /*
                         * 这儿做了个额外的判断，此代码出现的原因：
                         * 天猫那边规定 refreshToken 要 1.5S内返回数据（超时认为此请求无效，过5分钟之后会发起第二次 refreshToken 的请求）
                         * 但实际用的过程中，天猫那边发 refreshToken 过来时，服务器能正常响应，并清掉原有的 token 数据。
                         * 但！！！天猫那边还是超时了，这种情况已经发生好几次了。可能我们自己服务器辣鸡，或者代码有问题。但我真的想不出什么好解决办法，只有出此下策。。。
                         */

                        string tempJson = JsonConvert.SerializeObject(new TokenResponseRight 
                        {
                            AccessToken = newItem.AccessToken,
                            RefreshToken = newItem.RefreshToken,
                            expires_in = _tokenExpressTime
                        });
                        ToolHelper.FunctionHelper.writeLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "", tempJson + "", "ErrorRefresh");
                        return Content(tempJson, "application/json");
                    }
                }



                ToolHelper.FunctionHelper.writeLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "", "失败了..." + "", "ErrorRefreshResponse");

                return Json(new TaskResponseError
                {
                    error = response.StatusCode + "",
                    error_description = (await response.Content.ReadAsAsync<System.Web.Http.HttpError>()).ExceptionMessage
                });
            }
            var TokenResponse = await response.Content.ReadAsAsync<TokenResponseRight>();

            TokenResponse.expires_in = _tokenExpressTime;


            await Task.Run(() => {
                if (grant_type.Equals("authorization_code", StringComparison.OrdinalIgnoreCase))
                {
                    var firstCacheModel= CacheData.GetFirstAuthCache(code);

                    string hostId = firstCacheModel.HostId;

                    //授权成功，要给它重新写一次正式授权的缓存


                    CacheData.SetAccessTokenCache(TokenResponse.AccessToken, new Models.IntelligentHostCacheModel() 
                    {
                        AccountId=firstCacheModel.AccountId,
                        
                        Pwd=firstCacheModel.Password,
                        RefreshToken=TokenResponse.RefreshToken,
                        SessionCacheTime=firstCacheModel.SessionCacheTime,
                        SessionId=firstCacheModel.SessionId,
                        AccessToken=TokenResponse.AccessToken,
                        ClientId=client_id,
                        HostId = firstCacheModel.HostId,
                        TokenTimeStamp=FunctionHelper.GetTimStamp()
                    });

                }
                else if (grant_type.Equals("refresh_token", StringComparison.OrdinalIgnoreCase))
                {
                    Task.Run(()=>
                        {
                            CacheData.ReSetAccessTokenCache(refreshToken, TokenResponse.AccessToken, TokenResponse.RefreshToken);
                        });
                }
            });


            string theResJson = JsonConvert.SerializeObject(TokenResponse);
            ToolHelper.FunctionHelper.writeLog("TestToken:", theResJson + "", "TestToken");
            return Content(theResJson, "application/json");
        }



        /// <summary>
        /// 天猫指令入口
        /// </summary>
        /// <param name="receiveObj"></param>
        /// <returns></returns>
        public async Task<ActionResult> TestReceive([FromBody]X1ReceiveObj receiveObj)
        {
            ToolHelper.FunctionHelper.writeLog("receiveObj", JsonConvert.SerializeObject(receiveObj), "TestReceive");
            object res = null;

            //直接来判断具体应该怎么操作，不走原来的流程。。

            if (receiveObj.header.@namespace.Equals("AliGenie.Iot.Device.Discovery"))
            {//查询设备列表
               res= new DevDiscover().DiscoverDev(receiveObj); 
            }
            else 
            { //控制设备
                await Task.Run(() => {
                    res = new DevControl().DealDevControl(receiveObj);
                    ToolHelper.FunctionHelper.writeLog("success", JsonConvert.SerializeObject(res), "TestReceive");
                });
            }

           
            return Content(JsonConvert.SerializeObject(res), "application/json");
        }





        public ActionResult CacheNow()
        {
            CloudApi.Providers.RedisCacheSaveThread.CacheAll();
            return Content(JsonConvert.SerializeObject(new { errcode = "0"}), "application/json");
        }




        public class TokenResponseRight
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }


            [JsonProperty("expires_in")]
            public long expires_in { get; set; }

        }


        public class TaskResponseError
        {
            [JsonProperty("error_description")]
            public string error_description { get; set; }

            [JsonProperty("error")]
            public string error { get; set; }
        }
    }
}
