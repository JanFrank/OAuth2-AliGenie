using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    /// <summary>
    /// 属性装饰器
    /// </summary>
    public abstract class DevicePropertiesAndActionDecorator : AbstractDevicePropertiesAndAction
    {
        protected AbstractDevicePropertiesAndAction _devPropItem;

        public DevicePropertiesAndActionDecorator(AbstractDevicePropertiesAndAction devPropItem)
        {
            this._devPropItem = devPropItem;
        }


        public override List<X1ReturnProperty> GetProps(List<X1ReturnProperty> props)
        {
            if (_devPropItem != null)
            {
                return _devPropItem.GetProps(props);
            }
            else
            {
                return null;
            }
        }


        public override List<string> GetActions(List<string> actions)
        {
            if (_devPropItem != null)
            {
                return _devPropItem.GetActions(actions);
            }
            else
            {
                return new List<string>();
            }
        }

    }
}