/*
 *  1、App  全局的缓存 与服务
 *  2、
 * 
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudApi.Controllers;

namespace CloudApi
{
    public static  class AppGlobalServerStart
    {
        public static void Register()
        {
            //加载缓存
            CloudApi.ToolHelper.CacheData.LoadCacheData();

            //启动定时检查指令
            CloudApi.AliGenie.DeviceHandleThread.StartThread();
        }
    }
}