using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 温度属性
    /// </summary>
    public class TemperaturePropertieAndAction : DevicePropertiesAndActionDecorator
    {
        public TemperaturePropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "温度", value = "temperature" });
            return base.GetProps(props);
        }

        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("SetTemperature");
            actions.Add("AdjustUpTemperature");
            actions.Add("AdjustDownTemperature");
            actions.Add("QueryTemperature");
            return base.GetActions(actions);
        }


    }
}