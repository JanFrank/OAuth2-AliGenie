using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 电源状态属性
    /// </summary>
    public class PowerStatePropertieAndAction:DevicePropertiesAndActionDecorator
    {

        public PowerStatePropertieAndAction(AbstractDevicePropertiesAndAction prop):base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "电源状态", value = "powerstate" });
            return _devPropItem.GetProps(props);
        }



        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("TurnOff");
            actions.Add("TurnOn");
            actions.Add("QueryPowerState");
            return base.GetActions(actions);
        }
    }
}