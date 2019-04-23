using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 远程控制状态
    /// </summary>
    public class RemotestatusPropertieAndAction: DevicePropertiesAndActionDecorator
    {
        public RemotestatusPropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "设备远程状态", value = "remotestatus" });
            return base.GetProps(props);
        }


        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("TurnOff");
            actions.Add("TurnOn");
            return base.GetActions(actions);
        }
    }
}