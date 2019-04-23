using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 设备在线状态 属性
    /// </summary>
    public class OnlinestatePropertieAndAction: DevicePropertiesAndActionDecorator
    {
        public OnlinestatePropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "设备在线状态", value = "onlinestate" });

            return _devPropItem.GetProps(props);
        }



        public override List<string> GetActions(List<string> actions)
        {
            return base.GetActions(actions);
        }
    }
}