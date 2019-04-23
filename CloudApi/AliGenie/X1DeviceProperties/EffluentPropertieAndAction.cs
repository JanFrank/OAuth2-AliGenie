using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 出水功能属性
    /// </summary>
    public class EffluentPropertieAndAction: DevicePropertiesAndActionDecorator
    {
        public EffluentPropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "出水功能", value = "effluent" });
            return base.GetProps(props);
        }


        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("OpenFunction");
            actions.Add("CloseFunction");

            return base.GetActions(actions);
        }
    }
}