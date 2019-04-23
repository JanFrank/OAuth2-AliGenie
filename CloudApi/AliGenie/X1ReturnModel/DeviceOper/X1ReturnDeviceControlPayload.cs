using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1ReturnModel.DeviceOper
{
    /// <summary>
    /// 设备控制结果返回的 Payload
    /// </summary>
    public class X1ReturnDeviceControlPayload : X1ReturnBaseModel
    {
        /// <summary>
        /// 直接以 objcet 去处理类的不同
        /// </summary>
        public object payload { get; set; }
    }

}
