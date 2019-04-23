using CloudApi.Dueros.Models.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.ReturnModel.Payload
{
    /// <summary>
    /// 通用的消息体类
    /// </summary>
    public class CommonPayload
    {
        /// <summary>
        /// 状态集合
        /// </summary>
        public List<Attribute> attributes { get; set; }
    }
}