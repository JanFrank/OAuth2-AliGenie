using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// pm2.5属性
    /// </summary>
    public class pm25PropertieAndAction: DevicePropertiesAndActionDecorator
    {
        public pm25PropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "pm2.5", value = "pm2.5" });
            return base.GetProps(props);
        }


        public override List<string> GetActions(List<string> actions)
        {
            actions.Add("QueryPM25");
            return base.GetActions(actions);
        }
    }
}