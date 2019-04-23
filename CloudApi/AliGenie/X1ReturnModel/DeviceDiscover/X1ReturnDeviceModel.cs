using CloudApi.AliGenie.X1CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1ReturnModel.DeviceDiscover
{
    /// <summary>
    /// 返回 阿里开发平台的 设备类
    /// </summary>
    public class X1ReturnDeviceModel
    {
        /// <summary>
        /// 设备Id
        /// </summary>
        public string deviceId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string deviceName { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string deviceType { get; set; }


        /// <summary>
        /// 位置
        /// </summary>
        public string zone { get; set; }


        /// <summary>
        /// 品牌
        /// </summary>
        public string brand { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string model { get; set; }


        /// <summary>
        /// 产品icon(https协议的url链接),像素最好160*160 以免在app显示模糊
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 返回当前设备支持的属性状态列表，产品支持的属性列表参考2.3.2章节
        /// </summary>
        public List<X1ReturnProperty> properties { get; set; }

        /// <summary>
        /// 产品支持的操作(注：包括支持的查询操作) ,详情参照1.3.2和1.3.3章节
        /// </summary>
        public List<string> actions { get; set; }

        /// <summary>
        /// 产品扩展属性,为空返回null或者不返回该字段
        /// </summary>
        public X1Extensions extensions { get; set; }
    }
}