using CloudApi.AliGenie.X1ReturnModel.DeviceOper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1ReturnModel.DevicePropetyQuery
{
    public class X1ReturnDevicePropetyQuery : X1ReturnBaseModel
    {
        public X1ReturnDeviceOperSuccesspPayload payload { get; set; }

        public List<X1ReturnProperty> properties { get; set; }
    }
}