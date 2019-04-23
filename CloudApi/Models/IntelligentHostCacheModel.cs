using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Models
{
    /// <summary>
    /// 缓存用户的授权信息类
    /// </summary>
    public class IntelligentHostCacheModel
    {
        /// <summary>
        /// 网关ID
        /// </summary>
        public string HostId 
        {
            get 
            {
                return _hostId;
            }
            set 
            {
                _hostId = value;

                if (!string.IsNullOrEmpty(value) && ClientId.ToLower().IndexOf("dueos")>-1)
                {
                    #warning 如果有新的设备被授权了，要通知设备状态变化监视，当设备状态变化时，通知到小度.
                }
                
            }
        }


        /// <summary>
        /// 网关ID
        /// </summary>
        private string _hostId { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// 授权的密码
        /// </summary>
        public string Pwd { get; set; }



        /// <summary>
        /// 网关登录标识
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// 网关登录标识时间
        /// </summary>
        public DateTime SessionCacheTime { get; set; }

        /// <summary>
        /// 刷新token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// 授权码
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 授权ClientId
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 被授权的百度账号开放ID，与设备云账号一一对应。
        /// </summary>
        public string OpenUid { get; set; }


        /// <summary>
        /// 授权的时间点
        /// </summary>
        public long TokenTimeStamp { get; set; }


        /// <summary>
        /// 上一次的token
        /// </summary>
        public string LastRefreshToken { get; set; }
    }


    public class FirstAuthCacheModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string HostId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime SessionCacheTime { get; set; }
    }

}