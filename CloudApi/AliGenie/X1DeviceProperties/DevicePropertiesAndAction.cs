using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 设备属性
    /// </summary>
    public class DevicePropertiesAndAction:AbstractDevicePropertiesAndAction
    {
        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            return props;
        }

        public override List<string> GetActions(List<string> actions)
        {
            return actions;
        }
    }
}