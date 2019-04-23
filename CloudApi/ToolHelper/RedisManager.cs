using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Common;
using ServiceStack.Common.Web;
//从NuGet取数据，要找 ServiceStack.Redis 选择第一个
namespace CloudApi.ToolHelper
{
    /// <summary>
    ///  RedisManager类主要是创建链接池管理对象的  
    /// </summary>
    public static class RedisManager
    {
        /// <summary>  
        /// redis配置文件信息  
        /// </summary>  
        private static string RedisPath = CacheData.GetSysParamValue("RedisIP");//System.Configuration.ConfigurationSettings.AppSettings["redispath"];
        private static PooledRedisClientManager _prcm;


      
        
        /// <summary>  
        /// 静态构造方法，初始化链接池管理对象  
        /// </summary>  
        static RedisManager()
        {
            CreateManager();
        }

        /// <summary>  
        /// 创建链接池管理对象  
        /// </summary>  
        private static void CreateManager()
        {
            _prcm = CreateManager(new string[] { RedisPath }, new string[] { RedisPath });
            _prcm.ConnectTimeout = 30;
        }


        private static PooledRedisClientManager CreateManager(string[] readWriteHosts, string[] readOnlyHosts)
        {
            //WriteServerList：可写的Redis链接地址。  
            //ReadServerList：可读的Redis链接地址。  
            //MaxWritePoolSize：最大写链接数。  
            //MaxReadPoolSize：最大读链接数。  
            //AutoStart：自动重启。  
            //LocalCacheTime：本地缓存到期时间，单位:秒。  
            //RecordeLog：是否记录日志,该设置仅用于排查redis运行时出现的问题,如redis工作正常,请关闭该项。  
            //RedisConfigInfo类是记录redis连接信息，此信息和配置文件中的RedisConfig相呼应  


            // 支持读写分离，均衡负载   
            return new PooledRedisClientManager(readWriteHosts, readOnlyHosts, new RedisClientManagerConfig
            {
                MaxWritePoolSize = 50, // “写”链接池链接数
                MaxReadPoolSize = 50, // “读”链接池链接数
                AutoStart = true,
            });
        }

        private static IEnumerable<string> SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
        }

       

        public static IRedisClient GetClient()
        {
            if (_prcm == null)
            {
                CreateManager();
            }
            var TempClient = _prcm.GetClient();


            TempClient.Password = CacheData.GetSysParamValue("RedisPwd");
            return TempClient;
        }


    }



}