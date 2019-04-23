using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 剩余时间属性
    /// </summary>
    public class LefttimePropertieAndAction: DevicePropertiesAndActionDecorator
    {
        public LefttimePropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "剩余时间", value = "lefttime" });
            return base.GetProps(props);
        }



        public override List<string> GetActions(List<string> actions)
        {
            return base.GetActions(actions);
        }
    }
}