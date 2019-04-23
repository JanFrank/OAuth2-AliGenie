using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 风速 属性
    /// </summary>
    public class WindspeedPropertieAndAction : DevicePropertiesAndActionDecorator
    {
        public WindspeedPropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "风速", value = "windspeed" });
            return base.GetProps(props);
        }



        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("SetWindSpeed");
            actions.Add("AdjustUpWindSpeed");
            actions.Add("AdjustDownWindSpeed");
            actions.Add("QueryWindSpeed");

            return base.GetActions(actions);
        }
    }
}