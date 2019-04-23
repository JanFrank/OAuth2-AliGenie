using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.CommonModel
{
    public class Head
    {
        /// <summary>
        /// header协议中的namespace列表
        /// DiscoverAppliancesRequest	设备发现
        /// TurnOnRequest 设备控制 具体值要去看文档...有点多
        /// GetAirQualityIndexRequest 设备属性查询 具体值要去看文档...有点多
        /// </summary>
        public string @namespace { get; set; }

        /// <summary>
        /// header协议中name列表
        ///  设备发现类（与DuerOS.ConnectedHome.Discovery对应）
        ///  操作类（与DuerOS.ConnectedHome.Control对应）
        ///  查询类（与DuerOS.ConnectedHome.Query对应）
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// payload 的版本,目前版本为 1
        /// </summary>
        public int payloadVersion { get; set; }

        /// <summary>
        /// 用于跟踪请求
        /// </summary>
        public string messageId { get; set; }
    }
}