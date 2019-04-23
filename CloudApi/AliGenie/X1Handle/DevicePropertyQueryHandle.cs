using CloudApi.AliGenie.X1ReceviceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1Handle
{

    /// <summary>
    /// 设备属性查询 处理类
    /// </summary>
    public class DevicePropertyQueryHandle : AbstractHandle
    {
        public override object ProcessHandel(X1ReceiveObj receviceObj)
        {
            if (string.Equals(receviceObj.header.@namespace, "AliGenie.Iot.Device.Query", StringComparison.OrdinalIgnoreCase))
            {
                return null;
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