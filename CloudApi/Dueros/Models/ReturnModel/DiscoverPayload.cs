using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Models.ReturnModel
{
    public class DiscoverPayload
    {
        /// <summary>
        /// 以对象数组返回客户关联设备云帐户的设备、场景。如客户关联帐户没有设备、场景则返回空数组。如果在发现过程中出现错误，字段值设置为null, 用户允许接入的最大的设备数量是300。
        /// </summary>
        public List<DiscoveredAppliance> discoveredAppliances { get; set; }

        
        /// <summary>
        /// discoveredGroups 对象的数组，该对象包含可发现分组，与用户设备帐户相关联的。 如果没有与用户帐户关联的分组，此属性应包含一个空数组。 如果发生错误，该属性可以为空数组[]。阵列中允许的最大项目数量为10。
        /// </summary>
        public List<DiscoveredGroup> discoveredGroups { get; set; }
    }



    /// <summary>
    /// 设备或情景的类
    /// </summary>
    public class DiscoveredAppliance
    {
        /// <summary>
        /// 设备支持的操作类型数组
        /// </summary>
        public string[] actions { get; set; }

        /// <summary>
        /// 设备类型，场景类型
        /// </summary>
        public string[] applianceTypes { get; set; }

        /// <summary>
        /// 提供给设备云使用，存放设备或场景相关的附加信息，是键值对。DuerOS不了解或使用这些数据。该属性的内容不能超过5000字节。
        /// 此字段为自定义字段，可保存我们自己的东西
        /// </summary>
        public AdditionalApplianceDetails additionalApplianceDetails { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        public string applianceId { get; set; }

        /// <summary>
        /// 设备相关的描述，描述内容提需要提及设备厂商，使用场景及连接方式，长度不超过128个字符。
        /// </summary>
        public string friendlyDescription { get; set; }


        /// <summary>
        /// 用户用来识别设备的名称。 是字符串类型，不能包含特殊字符和标点符号，长度不能超过128个字符。
        /// </summary>
        public string friendlyName { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool isReachable { get; set; }

        /// <summary>
        /// 设备制造商的名称
        /// </summary>
        public string manufacturerName { get; set; }

        /// <summary>
        /// 设备型号名称，是字符串类型，长度不能超过128个字符。
        /// </summary>
        public string modelName { get; set; }

        /// <summary>
        /// 设备版本号
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// 设备的属性信息。当设备没有属性信息时，协议中不需要传入该字段。每个设备允许同步的最大的属性数量是10
        /// </summary>
        public Attribute[] attributes { get; set; }
    }

    public class AdditionalApplianceDetails
    {
        public string devType { get; set; }
    }

    /// <summary>
    /// 特征类
    /// </summary>
    public class Attribute
    {
        /// <summary>
        /// 属性名称，支持数字、字母和下划线，长度不能超过128个字符。
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 属性值，支持多种json类型。	
        /// </summary>
        public object value { get; set; }

        /// <summary>
        /// 属性值的单位名称，支持数字、字母和下划线，长度不能超过128个字符。
        /// </summary>
        public string scale { get; set; }


        /// <summary>
        /// 属性值取样的时间戳，单位是秒
        /// </summary>
        public long timestampOfSample { get; set; }

        /// <summary>
        /// 属性值取样的时间误差，单位是ms。如果设备使用的是轮询时间间隔的取样方式，那么uncertaintyInMilliseconds就等于时间间隔。如温度传感器每1秒取样1次，那么uncertaintyInMilliseconds的值就是1000。
        /// </summary>
        public int uncertaintyInMilliseconds { get; set; }

        /// <summary>
        /// 属性取值的合法范围，是字符串类型。字符串中包含的值，可以是单个值："INTEGER"，表示合法值是整数；"DOUBLE"，表示合法值是浮点数；"STRING"，表示合法值是字符串；"BOOLEAN"，表示合法值是布尔值；"OBJECT"，表示合法值是json对象；可以是集合： "(A1, B1, C1, D1)"，表示值可以取这些字符串；也可以是数字范围："[from: to]"，表示合法值是处于对应的数值范围内。
        /// </summary>
        public string legalValue { get; set; }
    }


    /// <summary>
    /// 发现分组类
    /// </summary>
    public class DiscoveredGroup
    {
        /// <summary>
        /// 用户用来识别分组的名称, 不应包含特殊字符或标点符号，长度不超过20字符。
        /// </summary>
        public string groupName { get; set; }

        /// <summary>
        /// 分组所包含设备ID的数组，要求设备ID必须是已经发现的设备中的ID，否则会同步失败，每个分组设备ID数量不超过50。
        /// </summary>
        public string[] applianceIds { get; set; }

        /// <summary>
        /// 分组备注信息，不能超过128个字符。
        /// </summary>
        public string groupNotes { get; set; }

        /// <summary>
        /// 提供给技能使用的分组相关的附加信息的键值对。该属性的内容不能超过2000字符。而且DuerOS也不了解或使用这些数据。
        /// </summary>
        public Newtonsoft.Json.Linq.JObject additionalGroupDetails { get; set; }
    }

   
}