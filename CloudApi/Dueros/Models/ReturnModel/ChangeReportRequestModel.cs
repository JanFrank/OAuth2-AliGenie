using CloudApi.Dueros.Models.ReturnModel.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.ReturnModel
{
    public class ChangeReportRequestModel
    {

        /// <summary>
        /// 头
        /// </summary>
        public CloudApi.Dueros.Models.CommonModel.Head header { get; set; }

        /// <summary>
        /// 体
        /// </summary>
        public ChangeReportRequestPayload payload { get; set; }
    }
}