using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 负离子功能属性
    /// </summary>
    public class AnionPropertieAndAction: DevicePropertiesAndActionDecorator
    {
        public AnionPropertieAndAction(AbstractDevicePropertiesAndAction prop)
            : base(prop)
        { 
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            props.Add(new X1ReturnProperty { name = "负离子功能", value = "anion" });
            return base.GetProps(props);
        }


        public override List<string> GetActions(List<string> actions)
        {
#warning 暂不知有什么功能，负离子。
            //这儿不知道有什么功能，暂留空


            return base.GetActions(actions);
        }
    }
}