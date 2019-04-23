using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.ReturnModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportStateResponseReturnModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CommonModel.Head header { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Payload.CommonPayload payload { get; set; }
    }
}