using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 方向属性
    /// </summary>
    public class DrectionPropertieAndAction: DevicePropertiesAndActionDecorator
    {
        public DrectionPropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "方向", value = "direction" });
            return base.GetProps(props);
        }



        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("QueryDirection");

            return base.GetActions(actions);
        }
    }
}