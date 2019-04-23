using CloudApi.AliGenie.X1Handle;
using CloudApi.AliGenie.X1ReceviceModel;
using CloudApi.ToolHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CloudApi.Controllers
{
    /// <summary>
    /// 天猫音箱相关
    /// </summary>
    public class AliGenieController : ApiController
    {
        
        /// <summary>
        /// 天猫指令入口
        /// </summary>
        /// <param name="receiveObj"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ReceiveMsg([FromBody]X1ReceiveObj receiveObj)
        {
            ToolHelper.FunctionHelper.writeLog("receiveObj", JsonConvert.SerializeObject(receiveObj), "TestReceive");
            object res = null;

            //直接来判断具体应该怎么操作，不走原来的流程。。

            if (receiveObj.header.@namespace.Equals("AliGenie.Iot.Device.Discovery"))
            {//查询设备列表
                res = new DevDiscover().DiscoverDev(receiveObj);
            }
            else
            { //控制设备
                await Task.Run(() =>
                {
                    res = new DevControl().DealDevControl(receiveObj);
                    ToolHelper.FunctionHelper.writeLog("success", JsonConvert.SerializeObject(res), "TestReceive");
                });
            }


            return FunctionHelper.SerializerJson(res);
        }
    }
}
