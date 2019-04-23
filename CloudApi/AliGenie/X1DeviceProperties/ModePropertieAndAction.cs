using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 模式属性
    /// </summary>
    public class ModePropertieAndAction: DevicePropertiesAndActionDecorator
    {
        public ModePropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "模式", value = "mode" });
            return base.GetProps(props);
        }


        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("CancelMode");
            actions.Add("SetMode");
            actions.Add("QueryMode");


            return base.GetActions(actions);
        }
    }
}