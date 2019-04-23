using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 颜色属性
    /// </summary>
    public class ColorPropertieAndAction : DevicePropertiesAndActionDecorator
    {
        public ColorPropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "颜色", value = "color" });
            return base.GetProps(props);
        }



        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("SetColor");
            actions.Add("QueryColor");

            return base.GetActions(actions);
        }
    }
}