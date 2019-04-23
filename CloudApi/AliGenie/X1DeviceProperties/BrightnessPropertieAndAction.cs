using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 亮度属性
    /// </summary>
    public class BrightnessPropertieAndAction : DevicePropertiesAndActionDecorator
    {
        public BrightnessPropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "亮度", value = "brightness" });
            return base.GetProps(props);
        }



        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("SetBrightness");
            actions.Add("AdjustUpBrightness");
            actions.Add("AdjustDownBrightness");
            actions.Add("QueryBrightness");
            return base.GetActions(actions);
        }
    }
}