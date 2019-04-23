using CloudApi.Dueros.Models.ReceiveModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.ReturnModel.Payload
{
    public class SetColorReturnPayload : CommonPayload
    {
        public achievedColorState achievedState { get; set; }
    }

    public class achievedColorState
    {
        public ColorModel Color { get; set; }
    }
}