using CloudApi.Dueros.Models.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.ReturnModel.Payload
{
    public class SetBrightnessPercentageReturnPayload:CommonPayload
    {
        public BrightnessModel previousState { get; set; }

        public ValueModel brightness { get; set; }
    }

    public class BrightnessModel
    {
        public ValueModel brightness { get; set; }
    }
}