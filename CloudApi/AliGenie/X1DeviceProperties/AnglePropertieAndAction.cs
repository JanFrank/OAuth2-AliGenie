using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 角度属性
    /// </summary>
    public class AnglePropertieAndAction: DevicePropertiesAndActionDecorator
    {
        public AnglePropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "角度", value = "angle" });
            return base.GetProps(props);
        }


        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("QueryAngle");
            return base.GetActions(actions);
        }

    }
}