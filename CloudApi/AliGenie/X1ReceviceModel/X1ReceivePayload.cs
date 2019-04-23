using CloudApi.AliGenie.X1CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1ReceviceModel
{
    /// <summary>
    /// 接收时的 Payload
    /// </summary>
    public class X1ReceivePayload
    {
        /// <summary>
        /// 授权码 固定有的
        /// </summary>
        public string accessToken { get; set; }


        /// <summary>
        /// 设备Id 操作设备、查询设备属性时会有
        /// </summary>
        public string deviceId { get; set; }


        /// <summary>
        /// 设备类型 操作设备、查询设备属性时会有
        /// </summary>
        public string deviceType { get; set; }


        /// <summary>
        /// 属性值，操作设备时会有
        /// </summary>
        public string attribute { get; set; }


        /// <summary>
        /// 值 操作设备时会有
        /// </summary>
        public string value { get; set; }


        /// <summary>
        ///  额外属性  操作设备、查询设备属性时会有
        /// </summary>
        public X1Extensions extensions { get; set; }
    }
}