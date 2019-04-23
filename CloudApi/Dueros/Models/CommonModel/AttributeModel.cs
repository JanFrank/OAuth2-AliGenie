using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.CommonModel
{
    /// <summary>
    /// 属性 参考 https://dueros.baidu.com/didp/doc/dueros-bot-platform/dbp-smart-home/protocol/attributes.md
    /// </summary>
    public class AttributeModel
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 属性值，支持多种json类型。
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 属性值的单位名称，支持数字、字母和下划线，长度不能超过128个字符。
        /// </summary>
        public string scale { get; set; }

        /// <summary>
        /// 属性值取样的时间戳，单位是秒。
        /// </summary>
        public long timestampOfSample { get; set; }

        /// <summary>
        /// 属性值取样的时间误差，单位是ms。
        /// </summary>
        public int uncertaintyInMilliseconds { get; set; }

        /// <summary>
        /// 属性取值的合法范围，是字符串类型。
        /// </summary>
        public string legalValue { get; set; }
    }
}