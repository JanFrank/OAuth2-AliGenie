using CloudApi.Dueros.Models.ReturnModel;
using CloudApi.ToolHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;

namespace CloudApi.Dueros
{
    public class ThreadCheckModel
    {
        public void StartThread()
        {
            Thread thread = new Thread(new ThreadStart(ThreadGetMqttMsg.GetMqttData));
            thread.Start();
        }


        /// <summary>
        /// 
        /// </summary>
        public static class ThreadGetMqttMsg
        {
            private static string DuerOSSyncUrl = System.Configuration.ConfigurationManager.AppSettings["DuerOSSyncUrl"] + "";
            private static string DuerOSSyncBotId = System.Configuration.ConfigurationManager.AppSettings["DuerOSSyncBotId"] + "";

            private static string DuerOSChangeReportUrl = System.Configuration.ConfigurationManager.AppSettings["DuerOSChangeReportUrl"] + "";

            /// <summary>
            /// 
            /// </summary>
            public static void GetMqttData()
            {
                while (true)
                {
                    //这儿模拟一次发送请求给小度，通知小度来请求设备状态
                    var devId="000001";//假设你自己从某个渠道获取到了变化状态的设备ID
                    var uids = new string[0];//对应授权过的小度的用户OpenUid


                    for (int i = 0; i < uids.Length; i++)
                    {

                        var tempPostModel = new ChangeReportRequestModel()
                        {
                            header = new Models.CommonModel.Head()
                            {
                                messageId = FunctionHelper.GetTimStamp() + "" + i,
                                name = "ChangeReportRequest",
                                @namespace = "DuerOS.ConnectedHome.Control",
                                payloadVersion = 1
                            },
                            payload = new Models.ReturnModel.Payload.ChangeReportRequestPayload()
                            {
                                botId = DuerOSSyncBotId,
                                openUid = uids[i],
                                appliance = new Models.ReturnModel.Payload.TempAppliance()
                                {
                                    applianceId = devId,
                                    attributeName = "turnOnState"
                                }
                            }
                        };

                        var tempRes = ToolHelper.FunctionHelper.PostJsonString(DuerOSChangeReportUrl, JsonConvert.SerializeObject(tempPostModel));
                        ToolHelper.FunctionHelper.writeLog("", tempRes, "01008postResult");
                    }
                    Thread.Sleep(15000);
                }
            }
        }
    }
}