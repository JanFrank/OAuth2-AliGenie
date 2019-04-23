using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.CommonModel
{
    public class CommonReceiveModel
    {
        public Head header { get; set; }

        public CommonRecievePayload payload { get; set; }
    }
}