using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using CloudApi.Models;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CloudApi.ToolHelper
{

   

    public class CacheData
    {

        public static void LoadCacheData()
        {
            //加载 系统参数配置
            LoadSysParamsCacheData();
        }



        /// <summary>
        /// 输出操作日志的：controller值
        /// </summary>
        private static string OperLogController = "";

        /// <summary>
        /// 输出操作日志的： action值
        /// </summary>
        private static string OperLogAction = "";

        /// <summary>
        /// 输出操作日志的锁
        /// </summary>

        private static object _OperLogLock = new object();




        /// <summary>
        /// 系统参数配置缓存
        /// </summary>
        private static ConcurrentDictionary<string, string> SysParamsCacheData = new ConcurrentDictionary<string, string>();


        /// <summary>
        /// 授权账号密码数据缓存
        /// </summary>
        private static ConcurrentDictionary<string, FirstAuthCacheModel> firstAuthCacheModel = new ConcurrentDictionary<string, FirstAuthCacheModel>();


        /// <summary>
        /// 设置授权账号密码授权数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="model"></param>
        public static void SetFirstAuthCache(string code, FirstAuthCacheModel model)
        {
            firstAuthCacheModel.AddOrUpdate(code, model, (k, ov) => ov = model);
        }


        /// <summary>
        /// 获取授权账号密码授权的数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static FirstAuthCacheModel GetFirstAuthCache(string code)
        { 
            FirstAuthCacheModel model=new FirstAuthCacheModel();
            firstAuthCacheModel.TryRemove(code, out model);
            return model;
        }
        


        private static string IsRedis = System.Configuration.ConfigurationManager.AppSettings["IsRedis"] + "";

        private static ConcurrentDictionary<string, IntelligentHostCacheModel> _accessTokenCacheModel = new ConcurrentDictionary<string, IntelligentHostCacheModel>();

        
        /// <summary>
        /// 
        /// </summary>
        public static ConcurrentDictionary<string, IntelligentHostCacheModel> accessTokenCacheModel 
        {
            get
            {
                if (IsRedis == "0")
                {
                    if (_accessTokenCacheModel == null || _accessTokenCacheModel.Count() == 0)
                    {
                        int k = 0;
                    ReLoadFromRedisAccessTokenCache:
                        if (k < 3)
                        {
                            try
                            {
                                using (var client = RedisManager.GetClient())
                                {
                                    string accessTokenCacheKey = System.Configuration.ConfigurationManager.AppSettings["accessTokenCacheKey"] + "";// "accessTokenCacheKey";
                                    if (string.IsNullOrEmpty(accessTokenCacheKey))
                                    {
                                        accessTokenCacheKey = "accessTokenCacheKey";
                                    }


                                    var templss = client.Get<ConcurrentDictionary<string, IntelligentHostCacheModel>>(accessTokenCacheKey);

                                    if (templss == null)
                                    {
                                        templss = new ConcurrentDictionary<string, IntelligentHostCacheModel>();
                                    }
                                    _accessTokenCacheModel = templss;
                                }
                            }
                            catch (Exception)
                            {
                                k++;
                                Thread.Sleep(100);
                                goto ReLoadFromRedisAccessTokenCache;
                            }
                        }
                        else
                        {
                            _accessTokenCacheModel = new ConcurrentDictionary<string, IntelligentHostCacheModel>();
                        }

                        return _accessTokenCacheModel;
                    }
                    else
                    {
                        return _accessTokenCacheModel;
                    }
                }
                else
                {
                    if (_accessTokenCacheModel == null || _accessTokenCacheModel.Count() == 0)
                    {
                        _accessTokenCacheModel = new ConcurrentDictionary<string, IntelligentHostCacheModel>();
                    }
                    return _accessTokenCacheModel;
                }
                
            }
            set
            {
                _accessTokenCacheModel = value;
            }
        }




        /// <summary>
        /// 设置小度的 OpenUid
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="model"></param>
        /// <param name="openUid"></param>
        public static void SetOpenUid(string accessToken, IntelligentHostCacheModel model, string openUid)
        {
            model.OpenUid = openUid;
            accessTokenCacheModel.AddOrUpdate(accessToken, model, (k, ov) => ov = model);
        }


        /// <summary>
        /// 设置 accessToken 的缓存
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="model"></param>
        public static void SetAccessTokenCache(string accessToken, IntelligentHostCacheModel model)
        {
            accessTokenCacheModel.AddOrUpdate(accessToken, model, (k, ov) => ov = model);
        }




        /// <summary>
        /// 根据旧的 refreshToken 获取新的 token 信息
        /// </summary>
        /// <param name="oldRefreshToken"></param>
        /// <returns></returns>
        public static  IntelligentHostCacheModel GetAccessTokenByOldRefreshToken(string oldRefreshToken)
        {
            var tempItem= accessTokenCacheModel.FirstOrDefault(c => c.Value.LastRefreshToken == oldRefreshToken);
            if (tempItem.Key != null)
            {
                return tempItem.Value;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 根据 accessToken 获取缓存数据
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static IntelligentHostCacheModel GetAccessTokenCache(string accessToken)
        {
            IntelligentHostCacheModel model = new IntelligentHostCacheModel();
            if (accessTokenCacheModel.TryGetValue(accessToken, out model))
            {
                return model;
            }
            else
            {
                return new IntelligentHostCacheModel();
            }
        }



        /// <summary>
        /// 刷新 token 时，重设缓存，将移除旧缓存
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="newAccessToken"></param>
        /// <param name="newRefreshToken"></param>
        public static void ReSetAccessTokenCache(string refreshToken,string newAccessToken, string newRefreshToken)
        {
            var model=new IntelligentHostCacheModel();
            var item= accessTokenCacheModel.FirstOrDefault(c => c.Value.RefreshToken == refreshToken);
            if (item.Key != null)
            {
                accessTokenCacheModel.TryRemove(item.Key, out model);
                model.AccessToken = newAccessToken;
                model.RefreshToken = newRefreshToken;
                model.TokenTimeStamp = FunctionHelper.GetTimStamp();
                model.LastRefreshToken = refreshToken;
                accessTokenCacheModel.AddOrUpdate(newAccessToken, model, (k, ov) => ov = model);
            }
        }



        /// <summary>
        /// 设置缓存中的控制器方法
        /// </summary>
        /// <param name="_controller"></param>
        /// <param name="_action"></param>
        /// <returns></returns>
        public static bool SetOperControllerAction(string _controller, string _action)
        {
            lock (_OperLogLock)
            {
                OperLogController = _controller;
                OperLogAction = _action;
            }
            return true;
        }



        /// <summary>
        /// 获取缓存中的控制器方法
        /// </summary>
        /// <param name="_action"></param>
        /// <returns></returns>
        public static string GetOperControllerAction(out string _action)
        {
            _action = OperLogAction;
            return OperLogController;
        }

        








        /// <summary>
        /// 加载系统配置参数
        /// </summary>
        private static void LoadSysParamsCacheData()
        {
            //获取数据中的数据...这儿直接写死用于测试

            SysParamsCacheData.Clear();

            #warning 自己处理相应的查数据库操作
            SysParamsCacheData.AddOrUpdate("AliGenieClientId", "text", (k, ov) => ov = "text");
            SysParamsCacheData.AddOrUpdate("AliGenieClientId_myTest", "myTest", (k, ov) => ov = "myTest");

            
            SysParamsCacheData.AddOrUpdate("AliGenieClientSecret", "text", (k, ov) => ov = "text");
            SysParamsCacheData.AddOrUpdate("AliGenieClientSecret_myTest", "myTest", (k, ov) => ov = "myTest");

            string RedisPwd = System.Configuration.ConfigurationManager.AppSettings["RedisPwd"] + "";
            SysParamsCacheData.AddOrUpdate("RedisPwd", RedisPwd,(k,ov)=>ov=RedisPwd);
            
            

            string RedisIP = System.Configuration.ConfigurationManager.AppSettings["RedisIP"] + "";
            SysParamsCacheData.AddOrUpdate("RedisIP", RedisIP, (k, ov) => ov = RedisIP);
        }



        /// <summary>
        /// 取系统参数配置值 
        /// </summary>
        /// <param name="paramCode"></param>
        /// <returns></returns>
        public static string GetSysParamValue(string paramCode)
        {
            if (SysParamsCacheData.ContainsKey(paramCode))
            {
                return SysParamsCacheData[paramCode];
            }
            return "";
        }




        public static void ReloadCacheData()
        {
            LoadSysParamsCacheData();
        }


    }
}