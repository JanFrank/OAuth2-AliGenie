using CloudApi.AliGenie.X1ReceviceModel;
using CloudApi.AliGenie.X1ReturnModel.DeviceOper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudApi.ToolHelper;

namespace CloudApi.AliGenie.X1Handle
{

    public class DevControl
    {
        public object DealDevControl(X1ReceiveObj receviceObj)
        {
            var cacheModel = CacheData.GetAccessTokenCache(receviceObj.payload.accessToken);
            string hostId = cacheModel.HostId;// CloudApi.Providers.OpenAuthorizationCodeProvider.GetHostIdByTicket(receviceObj.payload.accessToken);


            if (string.IsNullOrEmpty(hostId))
            {
                X1ReturnDeviceControlPayload tempRes = new X1ReturnDeviceControlPayload();

                tempRes.header = receviceObj.header;
                tempRes.header.name += "Response";

                tempRes.payload = new X1ReturnDeviceOperErrorPayload() { deviceId = receviceObj.payload.deviceId, errorCode = "ACCESS_TOKEN_INVALIDATE", message = "access_token is invalidate" };

                return tempRes;
            }

            DeviceHandleThread.DeviceOperQueue.Enqueue(receviceObj);

            var res = new X1ReturnDeviceControlPayload()
            {
                header = receviceObj.header,
                payload = new X1ReturnDeviceOperSuccesspPayload() { deviceId = receviceObj.payload.deviceId }
            };

            res.header.name += "Response";

            return res;
        }
    }


    /// <summary>
    /// 设备控制 处理类
    /// </summary>
    public class DevControlHandle : AbstractHandle
    {

        public override object ProcessHandel(X1ReceiveObj receviceObj)
        {
            /*
             {"header":{"namespace":"AliGenie.Iot.Device.Control","name":"TurnOn","payLoadVersion":1,"messageId":"e64170d7-d064-4972-bcee-c4fd8cd032f8"},"payload":{"accessToken":"m3rj-r06xPyLLda55Ze-lPP3YkDZBJcwdKm4DWiHeaq4PYS7jCF3-TpLNbDXwZpdX3xOMlN8KI5nouiA8bUp-SL5tkIypiBCiOgJ80Uyagqdx_Y8A6drdqJL42rao1q0eeuVZgxHC0GidnevjaSTkI1T6rpAiB_uo4u__YB5p893HDQiEduNj6HkqVQ7vwerPeSKdp9Mx4LdjGU6U6QeJfC11D47slu41r1R42Ce3yQ","deviceId":"000b57fffed27bac11","deviceType":"switch","attribute":"powerstate","value":"on","extensions":null}}
             */
            if (string.Equals(receviceObj.header.@namespace, "AliGenie.Iot.Device.Control", StringComparison.OrdinalIgnoreCase))
            {
                return new DevControl().DealDevControl(receviceObj);
            }
            else
            {
                if (nextHandle != null)
                {
                    return nextHandle.ProcessHandel(receviceObj);
                }
                else
                {
                    return null;
                }
            }
        }



    }
}