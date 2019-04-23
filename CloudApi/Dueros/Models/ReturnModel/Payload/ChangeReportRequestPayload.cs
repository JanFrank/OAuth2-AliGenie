using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.ReturnModel.Payload
{
    public class ChangeReportRequestPayload
    {
        public string botId { get; set; }

        public string openUid { get; set; }

        public TempAppliance appliance { get; set; }
    }


    public class TempAppliance
    {
        public string applianceId { get; set; }

        public string attributeName { get; set; }
    }
}