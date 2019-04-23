using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 电视频道属性
    /// </summary>
    public class TVChannelPropertieAndAction: DevicePropertiesAndActionDecorator
    {
        public TVChannelPropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "电视频道", value = "channel" });
            return base.GetProps(props);
        }


        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("SelectChannel");
            actions.Add("AdjustUpChannel");
            actions.Add("AdjustDownChannel");
            return base.GetActions(actions);
        }
    }
}