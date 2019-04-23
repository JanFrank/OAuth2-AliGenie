using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.ReturnModel
{
    public class DiscoveReturnModel
    {
        /// <summary>
        /// 头
        /// </summary>
        public CloudApi.Dueros.Models.CommonModel.Head header { get; set; }

        /// <summary>
        /// 内容体
        /// </summary>
        public DiscoverPayload payload { get; set; }
    }
}