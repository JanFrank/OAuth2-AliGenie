using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CloudApi.ToolHelper;

namespace CloudApi.Providers
{
    /// <summary>
    /// 线程，定时去保存状态到Redis中。以便后续回收IIS的时候，从Redis加载缓存
    /// </summary>
    public class RedisCacheSaveThread
    {
        public readonly static RedisCacheSaveThread Instance = new RedisCacheSaveThread();
        private RedisCacheSaveThread()
        { }


        public void Start()//启动  
        {
            Thread thread = new Thread(threadStart);
            thread.IsBackground = true;
            thread.Start();
        }


        public static void CacheAll()
        {
            using (var client = RedisManager.GetClient())
            {

                string accessTokenCacheKey = System.Configuration.ConfigurationManager.AppSettings["accessTokenCacheKey"] + "";// "accessTokenCacheKey";
                if (string.IsNullOrEmpty(accessTokenCacheKey))
                {
                    accessTokenCacheKey = "accessTokenCacheKey";
                }
                client.Set<ConcurrentDictionary<string, CloudApi.Models.IntelligentHostCacheModel>>(accessTokenCacheKey, CacheData.accessTokenCacheModel);




                string RefreshTokensKey = System.Configuration.ConfigurationManager.AppSettings["RefreshTokensKey"] + "";
                if (string.IsNullOrEmpty(RefreshTokensKey))
                {
                    RefreshTokensKey = "RefreshTokensKey";
                }
                client.Set<ConcurrentDictionary<string, string>>(RefreshTokensKey, OpenRefreshTokenProvider.refreshTokens);


            }
        }

        private void threadStart()
        {
            //让它刚启动的时候，不先去保存数据，不然数据会乱掉
            while (true)
            {
                Thread.Sleep(1000 * 60 * 10);
                try
                {
                    //加载进REDIS缓存中
                    Thread.Sleep(1);
                    
                    FunctionHelper.writeLog("", "in", "RedisCacheSaveThreadLog");
                    CacheAll();
                }
                catch (Exception ex)
                {
                    FunctionHelper.writeLog("RedisCacheSaveThread.cs => threadStart error:", ex.Message, "ThreadError");
                }

            }
        }

    }
}