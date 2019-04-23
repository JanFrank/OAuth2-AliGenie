using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 电视频道号 属性
    /// </summary>
    public class TVNumberPropertieAndAction: DevicePropertiesAndActionDecorator
    {
        public TVNumberPropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "电视频道号", value = "number" });
            return base.GetProps(props);
        }


        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("Next");
            actions.Add("Previous");
            return base.GetActions(actions);
        }
    }
}