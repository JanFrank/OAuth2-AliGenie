using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1ReturnModel.DeviceDiscover
{

    /// <summary>
    /// 设备发现 返回的 Payload
    /// </summary>
    public class DeviceDiscoverPayload
    {
        /// <summary>
        /// 设备列表
        /// </summary>
        public List<X1ReturnDeviceModel> devices { get; set; }
    }
}