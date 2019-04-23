using CloudApi.Dueros;
using CloudApi.Dueros.Models.CommonModel;
using CloudApi.Dueros.Models.ReceiveModel;
using CloudApi.Dueros.Models.ReturnModel;
using CloudApi.Dueros.Models.ReturnModel.Payload;
using CloudApi.Models;
using CloudApi.ToolHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CloudApi.Controllers
{
    public class DuerOSController : ApiController
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveObj"></param>
        /// <returns></returns>
        public HttpResponseMessage ReceiveMsg([FromBody]JObject receiveObj)
        {
            ToolHelper.FunctionHelper.writeLog("receiveObj", JsonConvert.SerializeObject(receiveObj), "DuerOSReceiveObj");
            object res = null;


            var commonModel= JsonConvert.DeserializeObject<CommonReceiveModel>(receiveObj.ToString());

            var model = CacheData.GetAccessTokenCache(commonModel.payload.accessToken);
            if (model == null || string.IsNullOrEmpty(model.HostId))
            {//从缓存里找不到了，说明授权过期了.
                new CommonReceiveModel()
                {
                    header = new Dueros.Models.CommonModel.Head() 
                    {
                        messageId = commonModel.header.messageId,
                        name = "ExpiredAccessTokenError",
                        @namespace = commonModel.header.@namespace,
                        payloadVersion = commonModel.header.payloadVersion
                    }
                };
                return FunctionHelper.SerializerJson(res);
            }

            string receiveNamespace = commonModel.header.@namespace;

            if (receiveNamespace.Equals("DuerOS.ConnectedHome.Discovery"))
            {//发现设备,向网关查设备列表
                res = Discove(commonModel);
            }
            else if (receiveNamespace.Equals("DuerOS.ConnectedHome.Control"))
            {//控制设备
                #region 控制设备
                string devType = commonModel.payload.appliance.additionalApplianceDetails.devType + "";//设备的实际类型

                string devId = commonModel.payload.appliance.applianceId + "";

                string operName = commonModel.header.name.Replace("Request", "");

                var controlModel = JsonConvert.DeserializeObject<ControlModel>(receiveObj.ToString());


                string errmsg = "";


                object resPayload = new object();//这儿写你自己的处理逻辑，与返回的结果
               
                


               

                var tempRes = new ControlReturnModel
                {
                    header = new Head()
                    {
                        messageId = commonModel.header.messageId,
                        name = "",//操作失败时当作设备不在线处理
                        @namespace = commonModel.header.@namespace,
                        payloadVersion = commonModel.header.payloadVersion
                    },
                    payload = resPayload
                };

                //错误信息自行定义...
                if (errmsg == "0")
                {//成功 
                    tempRes.header.name = commonModel.header.name.Replace("Request", "Confirmation");
                }
                else if (errmsg == "1")
                {//操作失败
                    tempRes.header.name = "TargetOfflineError";
                }
                else if (errmsg == "2")
                {//数据解析出错 
                    tempRes.header.name = "TargetConnectivityUnstableError";
                }
                else if (errmsg == "3")
                {
                    FunctionHelper.writeLog(receiveObj.ToString(), "状态没获取到...", "DuerOSCantGetDeviceState");
                }
                else if (errmsg == "999")
                { //操作超时
                    tempRes.header.name = "TargetOfflineError";
                }

                res = tempRes;
               
                #endregion
            }
            else if (receiveNamespace.Equals("DuerOS.ConnectedHome.Query"))
            {//查询设备
                
                //获取设备当前状态返回给小度
                //逻辑自己写
                switch (commonModel.header.name)
                {
                    case "ReportStateRequest"://更新设备状态
                        //发指令去查设备状态

                        /*
                         获取设备状态的代码自己处理...
                         */
                        var devStateList = new CommonPayload();
                        var tempRes = new ReportStateResponseReturnModel()
                        {
                            header = commonModel.header,
                            payload = new CommonPayload() 
                            {
                                attributes = devStateList.attributes.ToList()
                            }
                        };
                        tempRes.header.name = tempRes.header.name.Replace("Request", "Response");
                        res = tempRes;
                        break;
                    default:
                        break;
                }
            }

            FunctionHelper.writeLog("返回的数据",JsonConvert.SerializeObject(res),"Test");
            return FunctionHelper.SerializerJson(res);
        }




        
        /// <summary>
        /// 设备发现方法
        /// </summary>
        /// <param name="receiveObj"></param>
        /// <returns></returns>
        private object Discove(CommonReceiveModel receiveObj)
        {
            DiscoveReturnModel resModel = new DiscoveReturnModel()
            {
                header = new Dueros.Models.CommonModel.Head()
                {
                    messageId = receiveObj.header.messageId,
                    name = receiveObj.header.name.Replace("Request", "Response"),
                    @namespace = receiveObj.header.@namespace,
                    payloadVersion = receiveObj.header.payloadVersion
                },
                payload = new DiscoverPayload() 
                {
                    discoveredGroups=new List<DiscoveredGroup>(),
                    discoveredAppliances=new List<DiscoveredAppliance>()
                }
            };

            var cacheModel = CacheData.GetAccessTokenCache(receiveObj.payload.accessToken);
            CacheData.SetOpenUid(cacheModel.AccessToken, cacheModel, receiveObj.payload.openUid);
            
            var hostType = cacheModel.ClientId;
          


            string resultStr = string.Empty;


            try
            {
                /*
                 * 获取设备列表具体的代码
                 */
                resModel.payload.discoveredAppliances = new List<DiscoveredAppliance>();
            }
            catch (Exception ex)
            {
                FunctionHelper.writeLog("GetDevice error:", ex.Message + "   " + ex.StackTrace, "DeviceDiscoverHandleError");
            }

            return resModel;
        }





    }
}
