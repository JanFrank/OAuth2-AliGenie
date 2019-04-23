using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1CommonModel
{
    public class X1Head
    {
        /// <summary>
        /// header协议中的namespace列表
        /// AliGenie.Iot.Device.Discovery	设备发现
        /// AliGenie.Iot.Device.Control 设备控制
        /// AliGenie.Iot.Device.Query 设备属性查询
        /// </summary>
        [JsonProperty("namespace")]
        
        public string @namespace { get; set; }

        /// <summary>
        /// header协议中name列表
        ///  设备发现类（与AliGenie.Iot.Device.Discovery对应）
        ///  操作类（与AliGenie.Iot.Device.Control对应）
        ///  查询类（与AliGenie.Iot.Device.Query对应）
        /// </summary>
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// payload 的版本,目前版本为 1
        /// </summary>
        [JsonProperty("payLoadVersion")]
        public int payLoadVersion { get; set; }

        /// <summary>
        /// 用于跟踪请求
        /// </summary>
        [JsonProperty("messageId")]
        public string messageId { get; set; }
    }
}