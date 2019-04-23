using CloudApi.AliGenie.X1DeviceProperties;
using CloudApi.AliGenie.X1ReceviceModel;
using CloudApi.AliGenie.X1ReturnModel;
using CloudApi.AliGenie.X1ReturnModel.DeviceDiscover;
using CloudApi.AliGenie.X1ReturnModel.DeviceOper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudApi.AliGenie.X1CommonModel;
using CloudApi.ToolHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CloudApi.Models;

namespace CloudApi.AliGenie.X1Handle
{

    public class DevDiscover
    {
        public object DiscoverDev(X1ReceiveObj receiveObj)
        {

            X1ReturnDeviceDiscoverModel res = new X1ReturnDeviceDiscoverModel();
            res.header = receiveObj.header;
            res.header.name += "Response";
            res.payload = new DeviceDiscoverPayload();
            var devices = new List<X1ReturnDeviceModel>();



            var cacheModel= CacheData.GetAccessTokenCache(receiveObj.payload.accessToken);

            
            string hostId = cacheModel.HostId;


            if (string.IsNullOrEmpty(hostId))
            {
                X1ReturnDeviceOperErrorPayload payload = new X1ReturnDeviceOperErrorPayload()
                {
                    errorCode = "ACCESS_TOKEN_INVALIDATE",
                    message = "access_token is invalidate"
                };

                res.payload = payload;
                return res;
            }


            string tempIcoUrl = System.Configuration.ConfigurationManager.AppSettings["serverUrl"];


            var hostType = cacheModel.ClientId;
            if (!string.IsNullOrEmpty(hostType))
            {
                tempIcoUrl += "/" + hostType + "_ico.ico";
            }
            else
            {
                tempIcoUrl += "/yourIco.ico";
            }



            string resultStr = string.Empty;


            try
            {
                /*
                 * 获取设备列表具体代码位置
                 * 获取完之后，自行处理成天猫协议对应的类
                 */
                devices = new List<X1ReturnDeviceModel>();
            }
            catch (NullReferenceException ex)
            {
                FunctionHelper.writeLog("GetDevice error:", ex.Message + "   " + ex.StackTrace, "DeviceDiscoverHandleError");
            }
            catch (Exception ex)
            {
                try
                {
                    devices= GetDevListFromCache(hostId);
                }
                catch (Exception)
                {
                    FunctionHelper.writeLog("GetDevice error:", ex.Message + "   " + ex.StackTrace, "DeviceDiscoverHandleError");
                }
            }
            res.payload = new { devices = devices };

            return res;

        }



        private List<X1ReturnDeviceModel> GetDevListFromCache(string hostId)
        {
            using (var client = RedisManager.GetClient())
            {
                string cacheKey = "AliGenie_" + hostId;
                var templss = client.Get<List<X1ReturnDeviceModel>>(cacheKey);
                if (templss == null)
                {
                    templss = new List<X1ReturnDeviceModel>();
                }
                return templss;
            }
        }
    }



    

    /// <summary>
    /// 设备发现 处理类
    /// </summary>
    public class DeviceDiscoverHandle : AbstractHandle
    {
        public override object ProcessHandel(X1ReceiveObj receiveObj)
        {
            if (string.Equals(receiveObj.header.@namespace, "AliGenie.Iot.Device.Discovery", StringComparison.OrdinalIgnoreCase))
            {
                return new DevDiscover().DiscoverDev(receiveObj);
            }
            else
            {
                if (nextHandle != null)
                {
                    return nextHandle.ProcessHandel(receiveObj);
                }
                else
                {
                    return null;
                }
            }
        }






    }
}