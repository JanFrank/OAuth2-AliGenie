using CloudApi.Dueros.Models.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.ReceiveModel
{
    public class SetColorPayload : CommonRecievePayload
    {
        public ColorModel Color { get; set; }
    }


    public class ColorModel
    {
        public double hue { get; set; }
        public double saturation { get; set; }
        public double brightness { get; set; }
    }
}