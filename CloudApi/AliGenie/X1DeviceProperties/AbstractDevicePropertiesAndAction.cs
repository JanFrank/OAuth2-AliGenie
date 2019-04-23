using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 抽象设备属性
    /// </summary>
    public abstract class AbstractDevicePropertiesAndAction
    {
        //protected List<X1ReturnProperty> _props = new List<X1ReturnProperty>();


        //protected List<string> _actions = new List<string>() { "Query"};

        public abstract List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props);


        public abstract List<string> GetActions(List<string> actions);

        
    }
}