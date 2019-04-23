using CloudApi.Dueros.Models.ReturnModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.CommonModel
{
    public class CommonRecievePayload
    {
        public string openUid { get; set; }
        public string accessToken { get; set; }
        public Appliance appliance { get; set; }
    }



    public class Appliance
    {
        public AdditionalApplianceDetails additionalApplianceDetails { get; set; }
        public string applianceId { get; set; }
    }


}