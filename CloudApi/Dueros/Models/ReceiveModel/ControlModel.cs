using CloudApi.Dueros.Models.CommonModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.ReceiveModel
{
    public class ControlModel 
    {
        public Head header { get; set; }

        public JObject payload { get; set; }
    }
}