/*
 * 
 *  1:用户 操作返回  具体类型   
 * 
 * 
 * 
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace CloudApi.Models
{



    /// <summary>
    /// 用户注册返回 类型
    /// </summary>
    
    public class UserRegRet : AppInfoDataRet
    {

        /// <summary>
        /// 会话标识
        /// </summary>
        [DataMember(Order = 0)]
        public string sessionID { get; set; }

        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 1)]
        public int errcode { get; set; }


        /// <summary>
        /// 错误内容
        /// </summary>
        [DataMember(Order = 2)]
        public string errmsg { get; set; }




    }





    /// <summary>
    /// 用户登陆返回 类型
    /// </summary>
    
    public class UserLoginRet : AppInfoDataRet
    {

        [DataMember(Order = 0)]
        public string sessionID { get; set; }

        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 1)]
        public int errcode { get; set; }

        [DataMember(Order = 2)]
        public string errmsg { get; set; }


    }




    /// <summary>
    /// 设备状态结构 
    /// </summary>
    public class InstStruct
    {
        public string fanSpeed { get; set; }

        public string fanDirection { get; set; }

        public string mode { get; set; }

        public string temperature { get; set; }

        public string onOff { get; set; }


    }




    /// <summary>
    /// App 指令 信息返回 类型
    /// </summary>
    
    public class ActionInfoRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public string lastInst { get; set; }

        [DataMember(Order = 1)]
        public InstStruct instStruct { get; set; }

        /// <summary>
        /// 设备状态 A002: 离线失联， A003：在线等待 A004: 在线负载平衡， A005:在线负载波动
        /// </summary>
        [DataMember(Order = 2)]
        public string devStatus { get; set; }

        [DataMember(Order = 3)]
        public int errcode { get; set; }

        [DataMember(Order = 4)]
        public string errmsg { get; set; }

    }


    #region 用户设备查询 信息返回类

    /// <summary>
    /// 设备组合信息
    /// </summary>
    
    public class UniteDevice
    {


        public string lastInst { get; set; }

        public string devType { get; set; }

        public string infraTypeID { get; set; }

        public string bigType { get; set; }

        public string infraName { get; set; }


    }



    /// <summary>
    /// 用户设备清单 信息返回 类型
    /// </summary>
    
    public class DevicelistRet : AppInfoDataRet
    {

        [DataMember(Order = 0)]
        public DeviceData[] device { get; set; }
        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 1)]
        public int errcode { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        [DataMember(Order = 2)]
        public string errmsg { get; set; }


    }


    /// <summary>
    /// 用户主机列表
    /// </summary>
    
    public class HostListRet : AppInfoDataRet
    {
        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 1)]
        public int errcode { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        [DataMember(Order = 2)]
        public string errmsg { get; set; }

        
        public List<HostMd> lss { get; set; }
    }


    
    public class HostMd
    {
        
        public string devStatus { get; set; }
        
        
        public string HostID { get; set; }

        
        public string Name { get; set; }

        
        public string IP { get; set; }
        
        /// <summary>
        /// 户型
        /// </summary>
        
        public string HX { get; set; }

        
        public string TypeCode { get; set; }

        
        public string MacAddr { get; set; }

        
        public string devOwner { get; set; }
    }



    
    public class HostMd2
    {
        
        public string devStatus { get; set; }

        
        public string HostID { get; set; }

        
        public string Name { get; set; }

        
        public string IP { get; set; }

        /// <summary>
        /// 户型
        /// </summary>
        
        public string HX { get; set; }

        
        public string TypeCode { get; set; }

        
        public string MacAddr { get; set; }

        
        public string OwnerID { get; set; }

        
        public string UserID { get; set; }

        
        public string addNetTime { get; set; }
    }


    
    public class DeviceArealistRet : AppInfoDataRet
    {

        [DataMember(Order = 0)]
        public AreaDeviceData[] device { get; set; }
        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 1)]
        public string errcode { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        [DataMember(Order = 2)]
        public string errmsg { get; set; }


    }









    
    public class HostOpenOrCloseSortRet:AppInfoDataRet
    {
        
        public string errcode { get; set; }

        
        public string errmsg { get; set; }

        
        public List<AreaDevSortData> lss { get; set; }
    }


    /// <summary>
    /// 所有展开的开关的列表
    /// </summary>
    
    public class DeviceAreaAlllistRet : AppInfoDataRet
    {

        [DataMember(Order = 0)]
        public AreaChildDeviceData[] device { get; set; }
        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 1)]
        public string errcode { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        [DataMember(Order = 2)]
        public string errmsg { get; set; }


    }





    
    public class AreaDeviceData : AppInfoDataRet
    {
        
        public string devStatus { get; set; }

        
        public string devID { get; set; }

        
        public string token { get; set; }

        
        public string devName { get; set; }

        
        public string seed { get; set; }

        
        public string logoSet { get; set; }

        
        public string devTypeID { get; set; }

        
        public string devTypeCn { get; set; }



        /// <summary>
        /// 设备所有人标识
        /// </summary>
        public string devOwnerID { get; set; }


        /// <summary>
        /// 入网时间
        /// </summary>
        public string addNetTime { get; set; }

        /// <summary>
        /// 设备所有人标识： 0表示所以人，1表示使用人
        /// </summary>
        
        public string devOwner { get; set; }


        /// <summary>
        /// 子设备ID
        /// </summary>
        
        public string devChildID { get; set; }

        
        public string wifisignal { get; set; }

        
        public string wifissid { get; set; }


        
        public string parentareacode { get; set; }
        
        public string parentareaname { get; set; }
        
        public string areacode { get; set; }
        
        public string areaname { get; set; }


    }




    
    public class AreaChildDeviceData : AppInfoDataRet
    {
        
        public string devStatus { get; set; }

        
        public string devID { get; set; }

        
        public string token { get; set; }

        /// <summary>
        /// 当前设备名称
        /// </summary>
        
        public string devName { get; set; }

        
        public string seed { get; set; }

        
        public string logoSet { get; set; }

        
        public string devTypeID { get; set; }

        
        public string devTypeCn { get; set; }



        /// <summary>
        /// 设备所有人标识
        /// </summary>
        public string devOwnerID { get; set; }


        /// <summary>
        /// 入网时间
        /// </summary>
        public string addNetTime { get; set; }

        /// <summary>
        /// 设备所有人标识： 0表示所以人，1表示使用人
        /// </summary>
        
        public string devOwner { get; set; }

        /// <summary>
        /// 父级设备名称
        /// </summary>
        public string ParentName { get; set; }



        /// <summary>
        /// 子设备ID
        /// </summary>
        
        public string devChildID { get; set; }

        
        public string wifisignal { get; set; }

        
        public string wifissid { get; set; }


        
        public string parentareacode { get; set; }
        
        public string parentareaname { get; set; }
        
        public string areacode { get; set; }
        
        public string areaname { get; set; }


        
        public string Pwd { get; set; }

        
        public bool IsLock { get; set; }


        /// <summary>
        /// 是否推送
        /// </summary>
        
        public bool IsPush { get; set; }


        
        public string HostName { get; set; }


        /// <summary>
        /// 是否显示在首页
        /// </summary>
        
        public bool IsDeskTop { get; set; }

    }



 

    
    public class AreaDevSortData : AppInfoDataRet
    {
        
        public string devID { get; set; }

        
        public string devName { get; set; }

        
        public string devTypeID { get; set; }

        
        public string OrderNum { get; set; }

    }




    /// <summary>
    /// 主机 区域下 所有 灯光类 设备的列表
    /// </summary>
    
    public class HostDevAreaAlllistRet : AppInfoDataRet
    {

        [DataMember(Order = 0)]
        public HostAreaChildDevData[] device { get; set; }
       

        [DataMember(Order = 1)]
        public string errcode { get; set; }
       

        [DataMember(Order = 2)]
        public string errmsg { get; set; }


    }



    
    public class HostAreaChildDevData : AreaChildDeviceData
    {
        
        public string State { get; set; }
    }




    /// <summary>
    /// 设备功能描述
    /// </summary>
    
    public class DeviceData : AppInfoDataRet
    {
        
        public string devStatus { get; set; }

        
        public string devID { get; set; }

        
        public string token { get; set; }

        
        public string devName { get; set; }

        
        public string seed { get; set; }

        
        public string logoSet { get; set; }

        
        public string devTypeID { get; set; }

        
        public string devTypeCn { get; set; }



        /// <summary>
        /// 设备所有人标识
        /// </summary>
        public string devOwnerID { get; set; }

        public string devOwnerName { get; set; }


        /// <summary>
        /// 入网时间
        /// </summary>
        public string addNetTime { get; set; }

        /// <summary>
        /// 设备所有人标识： 0表示所以人，1表示使用人
        /// </summary>
        
        public string devOwner { get; set; }


        /// <summary>
        /// 子设备ID
        /// </summary>
        
        public string devChildID { get; set; }

        
        public string wifisignal { get; set; }

        
        public string wifissid { get; set; }

    }



    /// <summary>
    /// 设备功能列表 返回类型
    /// </summary>

    
    public class FeatuData : AppInfoDataRet
    {
        
        public string devTypeID { get; set; }

        
        public string devTypeCn { get; set; }

        
        public string devID { get; set; }


        
        public string devName { get; set; }

        
        public string token { get; set; }


        
        public string devFeatuID { get; set; }

        /// <summary>
        /// 设备功能 操作码
        /// </summary>
        
        public string operCode { get; set; }

        /// <summary>
        /// 设备功能名
        /// </summary>
        
        public string devFeatuName { get; set; }


    }



    /// <summary>
    /// 设备功能列表 返回类型
    /// </summary>
    
    public class DeviceFeatuRet : AppInfoDataRet
    {

        [DataMember(Order = 0)]
        public FeatuData[] featu { get; set; }
        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 1)]
        public int errcode { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        [DataMember(Order = 2)]
        public string errmsg { get; set; }


    }



    
    public class StateData : AppInfoDataRet
    {
        
        public string operCode { get; set; }

        
        public string operValue { get; set; }

    }

    
    public class DeviceStateRet : AppInfoDataRet
    {

        [DataMember(Order = 0)]
        public StateData[] state { get; set; }
        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 1)]
        public int errcode { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        [DataMember(Order = 2)]
        public string errmsg { get; set; }


    }


    /// <summary>
    /// 红外固定码
    /// </summary>

    
    public class InfraFixCodeRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public string CMD { get; set; }

        [DataMember(Order = 1)]
        public string param { get; set; }
    }



    /// <summary>
    /// 取红外类型 返回
    /// </summary>

    
    public class InfraTypeRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        [DataMember(Order = 1)]
        public string errmsg { get; set; }


        [DataMember(Order = 2)]
        public string typeid { get; set; }


        [DataMember(Order = 3)]
        public string typename { get; set; }

    }






    /// <summary>
    /// 用户查询 单个设备 信息返回 类型
    /// </summary>
    
    public class DeviceQryRet : AppInfoDataRet
    {
        public string socketOut_upTime { get; set; }

        /// <summary>
        /// 设备状态 A002: 离线失联， A003：在线等待 A004: 在线负载平衡， A005:在线负载波动
        /// </summary>
        public string devStatus { get; set; }

        public string devID { get; set; }

        public string thisMonth { get; set; }

        public string socketOut_W { get; set; }

        public string devName { get; set; }
        public int errcode { get; set; }

        public string socketOut_P { get; set; }

        public string socketOutY_W { get; set; }

        public string devType { get; set; }

        public string lastMonth { get; set; }

        public UniteDevice[] unitedevice { get; set; }

        public string lastInst { get; set; }

        /// <summary>
        /// 设备状态结构描述
        /// </summary>
        public InstStruct instStruct { get; set; }

        public string errmsg { get; set; }


    }




    #endregion


    #region 设备类型清单
    public class DevTypeID
    {
        public string devType { get; set; }

        public string id { get; set; }

    }

    /// <summary>
    /// 设备类型清单返回类型
    /// </summary>
    public class DevTypeListRet : AppInfoDataRet
    {
        public string[] devTypeList { get; set; }
        public int errcode { get; set; }
        public string errmsg { get; set; }

        public DevTypeID[] devTypeID { get; set; }

    }


    #endregion


    #region 设备可用操作查询


    /// <summary>
    /// 指令 与说明
    /// </summary>
    public class InstList
    {
        public string inst { get; set; }
        public string describe { get; set; }

    }

    /// <summary>
    /// 业务指令列表
    /// </summary>
    public class ActionIDList
    {
        public string actionID { get; set; }

        public string describe { get; set; }

        public InstList[] instList { get; set; }

    }

    public class DevActionListRet : AppInfoDataRet
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public ActionIDList[] actionIDList { get; set; }

    }



    #endregion



    /// <summary>
    /// 捆绑设备 返回信息类
    /// </summary>

    
    public class DeviceBindRet : AppInfoDataRet
    {
        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 0)]
        public int errcode { get; set; }

        /// <summary>
        /// 错误内容
        /// </summary>
        [DataMember(Order = 1)]
        public string errmsg { get; set; }

    }




    /// <summary>
    /// 设备删除 返回 类
    /// </summary>
    
    public class DeviceRemoveRet : AppInfoDataRet
    {
        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 0)]
        public int errcode { get; set; }

        /// <summary>
        /// 错误内容
        /// </summary>
        [DataMember(Order = 1)]
        public string errmsg { get; set; }

    }



    /// <summary>
    /// 设备类型变更 返回类
    /// </summary>
    
    public class DeviceChangeTypeRet : AppInfoDataRet
    {
        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 0)]
        public int errcode { get; set; }

        /// <summary>
        /// 错误内容
        /// </summary>
        [DataMember(Order = 1)]
        public string errmsg { get; set; }

    }






    
    public class InfraTypeIDAbilityRec : AppInfoDataRet
    {


    }


    
    public class CMD1002Ret : AppInfoDataRet
    {
        
        public List<string> DevIDList { get; set; }

        
        public List<bool> IsOkList { get; set; }

        
        public List<string> TypeCodeList { get; set; }
    }


    
    public class MqttCMD3001Ret : AppInfoDataRet
    {
        /// <summary>
        /// 指令标识
        /// </summary>
        [DataMember(Order = 0)]
        public string CMD { get; set; }

        [DataMember(Order = 1)]
        public string connInterval { get; set; }

        [DataMember(Order = 2)]
        public string devID { get; set; }



        [DataMember(Order = 3)]
        public string OrderNo
        {
            get;
            set;

        }


        [DataMember(Order = 4)]
        public devTodoAction[] devTodo { get; set; }

    }
    // APP指令：

    
    public class CMD3001Ret : AppInfoDataRet
    {
        /// <summary>
        /// 指令标识
        /// </summary>
        [DataMember(Order = 0)]
        public string CMD { get; set; }

        [DataMember(Order = 1)]
        public string connInterval { get; set; }

        [DataMember(Order = 2)]
        public string devID { get; set; }



        [DataMember(Order = 3)]
        public string OrderNo
        {
            get;
            set;

        }


        [DataMember(Order = 4)]
        public devTodoAction[] devTodo { get; set; }

    }

    /// <summary>
    /// 指令具体动作  "devTodo":[{"actionID":"2","delay":"0","param":"","sub":[3]}]}",
    ///               "devTodo":[{"actionID":"2","delay":"0","param":"","sub":[3]}]}",
    /// </summary>
    /// 

    
    public class devTodoAction
    {

        [DataMember(Order = 0)]
        public string actionID { get; set; }

        [DataMember(Order = 1)]
        public string delay { get; set; }

        /// <summary>
        ///  动作的 参数值： 如 调温度：动作actionId: 801,  param: 温度值 如 26
        /// </summary>
        [DataMember(Order = 2)]
        public string param { get; set; }

        [DataMember(Order = 3)]
        public int[] sub { get; set; }


    }




    
    public class UserDeviceRelationRet : AppInfoDataRet
    {
        
        public Dictionary<string, List<string>> UserRelation;

    }




    /// <summary>
    /// App 指令 下发 到 wifi 返回
    /// </summary>
    
    public class AppOrderRet : AppInfoDataRet
    {
        /// <summary>
        ///  返回结果：0:成功， 其他失败
        /// </summary>
        [DataMember(Order = 0)]
        public int errcode { get; set; }


        /// <summary>
        ///  结果描述 （一般是失败描述）
        /// </summary>
        [DataMember(Order = 1)]
        public string errmsg { get; set; }

    }



    #region 通用 返回类型

    /// <summary>
    /// 通用 返回类型
    /// </summary>
    
    public class CommandRet : AppInfoDataRet
    {
        /// <summary>
        ///  返回结果：0:成功， 其他失败
        /// </summary>
        [DataMember(Order = 0)]
        public int errcode { get; set; }


        /// <summary>
        ///  结果描述 （一般是失败描述）
        /// </summary>
        [DataMember(Order = 1)]
        public string errmsg { get; set; }

    }
    #endregion


    
    public class HostLocationRes : CommandRet
    {

        public string HostIP { get; set; }

        public string HostPort { get; set; }

        public string HostID { get; set; }

        

    }

    /// <summary>
    /// 不包含errmsg,errcode的主机服务类
    /// </summary>
    
    public class HostLocationRes2 
    {

        public string HostIP { get; set; }

        public string HostPort { get; set; }

        public string HostID { get; set; }



    }


    /// <summary>
    /// 用户键康数据查询返回
    /// </summary>

    
    public class HealthDataQryRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }


        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public HealthData[] msg { get; set; }

    }


    
    public class HealthData : AppInfoDataRet
    {
        
        public string sessionID { get; set; }

        
        public string height { get; set; }

        
        public string weight { get; set; }

        
        public string age { get; set; }

        
        public string sex { get; set; }

        
        public string waistline { get; set; }

        
        public string hipline { get; set; }

        
        public string BMI { get; set; }

        
        public string fat { get; set; }

        
        public string water { get; set; }

        
        public string bmr { get; set; }

        
        public string bone { get; set; }

        
        public string visceralfat { get; set; }

        
        public string muscle { get; set; }

        
        public string bodyage { get; set; }

        
        public string time { get; set; }

    }




    /// <summary>
    /// 键康参数 返回类型
    /// </summary>
    
    public class HealthParamQryRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }


        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public HealthParam[] msg { get; set; }

    }


    
    public class HealthParam : AppInfoDataRet
    {
        
        public string size { get; set; }

        
        public string lowStandard { get; set; }

        
        public string highStandard { get; set; }

        
        public string fat { get; set; }

    }



    /// <summary>
    /// 统计类型返回
    /// </summary>

    
    public class SessCountRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public string averageWeight { get; set; }

    }






    /// <summary>
    /// 用户键康数据统计返回
    /// </summary>

    
    public class HealthDataStatRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }


        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public StatData msg { get; set; }

    }


    /// <summary>
    /// 统计数据类型
    /// </summary>
    
    public class StatData : AppInfoDataRet
    {
        
        public StatDataDeatail[] data { get; set; }

        
        public string average { get; set; }

        
        public string lasttime { get; set; }

    }

    /// <summary>
    /// 统计数据类型 明细
    /// </summary>

    
    public class StatDataDeatail : AppInfoDataRet
    {
        
        public string date { get; set; }

        
        public string value { get; set; }

    }


    #region 用户信息

    /// <summary>
    /// 用户信息返回类
    /// </summary>

    
    public class UserInfoRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }


        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public UserInfoData[] content { get; set; }

    }


    /// <summary>
    /// 用户信息 数据集
    /// </summary>
    
    public class UserInfoData : AppInfoDataRet
    {
        
        public string fuserId { get; set; }

        
        public string fname { get; set; }

        
        public string tpicurl { get; set; }


        
        public string fhight { get; set; }

        
        public string fweight { get; set; }

        
        public string fbust { get; set; }

        
        public string fhipcir { get; set; }


        
        public string fwaistline { get; set; }

        
        public string fsex { get; set; }

        
        public string birth { get; set; }


        
        public string frealName { get; set; }

        
        public string fphoneNum { get; set; }

        
        public string ftelNum { get; set; }

        
        public string faddress { get; set; }

        
        public string femail { get; set; }

        
        public string PhotoAddr { get; set; }


    }


    #endregion




    
    public class AppVersionRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public string verionCode { get; set; }


        [DataMember(Order = 1)]
        public string updateUrl { get; set; }

        
        public string remark { get; set; }

    }




    /// <summary>
    ///  找回密码
    /// </summary>
    
    public class FindPwdRet : AppInfoDataRet
    {
        /// <summary>
        ///  返回结果：0:成功， 其他失败
        /// </summary>
        [DataMember(Order = 0)]
        public int errcode { get; set; }


        /// <summary>
        ///  结果描述 （一般是失败描述）
        /// </summary>
        [DataMember(Order = 1)]
        public string errmsg { get; set; }


        /// <summary>
        /// 生成的sessionID
        /// </summary>
        [DataMember(Order = 2)]
        public string sessionID { get; set; }
    }



    /// <summary>
    /// 用户下的设备清单 ： 查询用户所拥有设备列表，仅管理员属于用户，不包括分享和申请控制器的设备；
    /// </summary>

    
    public class HtmlOwnerDeviceList : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }


        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public HtmlOwnerDevieData[] content { get; set; }

    }


    /// <summary>
    /// html 5设备的信息：
    /// </summary>
    
    public class HtmlOwnerDevieData : AppInfoDataRet
    {
        
        public string sencepage { get; set; }

        
        public string title { get; set; }

        
        public string tpicurl { get; set; }

        
        public string deviceid { get; set; }

        
        public string state { get; set; }

        
        public string devtypecode { get; set; }

        
        public string token { get; set; }



    }



    /// <summary>
    ///  html 用户 所有设备设备信息  包括所有人，分享，申请分享的
    /// </summary>
    
    public class HtmlAllDeviceList : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public HtmlAllDevieData[] content { get; set; }

    }


    
    public class HtmlAllDevieData : AppInfoDataRet
    {

        
        public string ownertype { get; set; }

        
        public string deviceid { get; set; }

        
        public string devicestate { get; set; }

        
        public string title { get; set; }

        
        public string tpicurl { get; set; }


        
        public string dusersnum { get; set; }

        
        public string dapplayingnum { get; set; }

        
        public string detailpage { get; set; }


        //  分享，与申请分享
        
        public string state { get; set; }


        
        public string partner { get; set; }

        
        public string time { get; set; }

        
        public string devtypeid { get; set; }

        
        public string devtypename { get; set; }


        
        public string wifissid { get; set; }

        
        public string wifisignal { get; set; }


        
        public string devtypegroupcode { get; set; }

        
        public string devtypegroupname { get; set; }


        
        public string token { get; set; }


        
        public string devownerid { get; set; }


        
        public string devownername { get; set; }


        
        public string parentareaname { get; set; }

        
        public string childareaname { get; set; }


        
        public string parentareacode { get; set; }

        
        public string childareacode { get; set; }



    }




    /// <summary>
    ///  html 设备使用者信息
    /// </summary>
    
    public class HtmlDevUserList : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public DevUserData[] content { get; set; }

    }


    
    public class DevUserData : AppInfoDataRet
    {
        
        public string deviceid { get; set; }

        
        public string userid { get; set; }

        
        public string usernike { get; set; }


    }



    /// <summary>
    ///  html 设备使用者信息
    /// </summary>
    
    public class HtmlDevApplyUserList : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public DevApplyUserData[] content { get; set; }

    }


    
    public class DevApplyUserData : AppInfoDataRet
    {
        
        public string deviceid { get; set; }

        
        public string userid { get; set; }

        
        public string time { get; set; }

    }



    /// <summary>
    /// 设备使用都统计信息
    /// </summary>


    
    public class DevUserCount : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public UserCountData[] content { get; set; }

    }


    
    public class UserCountData : AppInfoDataRet
    {
        
        public string deviceid { get; set; }

        
        public string devicestate { get; set; }

        
        public string title { get; set; }

        
        public string tpicurl { get; set; }


        
        public string dusersnum { get; set; }

        
        public string dapplayingnum { get; set; }

        
        public string partner { get; set; }

        
        public string debelongtype { get; set; }


        
        public string devtypeid { get; set; }



    }




    
    public class ServerListRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public ServerUrlRet[] list { get; set; }

    }



    /// <summary>
    /// 服务器地址列表
    /// </summary>
    
    public class ServerUrlRet : AppInfoDataRet
    {
        
        public string Application { get; set; }

        
        public string ServerType { get; set; }

        
        public string VersionCode { get; set; }


        public string UpDate { get; set; }

        
        public string ServerAddr { get; set; }

        
        public string Remark { get; set; }


    }



    /// <summary>
    ///  设备使用统计 返回类型
    /// </summary>
    
    public class DeviceUseStatRet : AppInfoDataRet
    {
        
        public int errcode { get; set; }

        
        public string errmsg { get; set; }

        
        public string cumuFrqofUse { get; set; }

        
        public string cumuTime { get; set; }

        
        public string cumuRedLine { get; set; }

        
        public string cumuStartLight { get; set; }

        
        public string cumuAnion { get; set; }

        
        public string cumuStartFan { get; set; }



        
        public string usageTime { get; set; }

        
        public string usageTemp { get; set; }

    }



    
    public class UseDevStateRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public string state { get; set; }

    }


    /// <summary>
    /// 检查用户是否有设备的控制权
    /// </summary>

    
    public class ExistsUseDevRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public string errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public UseDevStateRet[] content { get; set; }

    }





    /// <summary>
    ///  红外码 返回类型 格式 {"CMD":"IDB0","param":[{"delay":"0","actionID":"6","param":"016000FF00FF00FE01FF00FF002AD50000"}]}
    /// </summary>

    
    public class InfraTypCodeDevRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public string CMD { get; set; }

        
        public InfraTypCodeData[] param { get; set; }

    }

    
    public class InfraTypCodeData : AppInfoDataRet
    {
        
        public string delay { get; set; }

        
        public string actionID { get; set; }

        
        public string param { get; set; }
    }


    #region   //TV 功能列表红外码类型


    public class InfraFunListRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public string errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public InfraTypTVRet content { get; set; }

    }


    
    public class InfraTypTVRet : AppInfoDataRet
    {
        
        public string CMD { get; set; }

        
        public InfraTypTVParam param { get; set; }
    }



    
    public class InfraTypTVParam : AppInfoDataRet
    {
        
        public string _id { get; set; }

        
        public InfraTypTVLogoSet logoSet { get; set; }

        
        public int keyRow { get; set; }


        
        public int[] keyRowNum { get; set; }

        
        public string keyswitch { get; set; }


        
        public InfraTypTVKeysSet keysSet { get; set; }

        
        public string dirURL { get; set; }

        
        public int keyCount { get; set; }

        
        public int keyCol { get; set; }

        
        public string panelType { get; set; }

        
        public InfraTypTVOnOff ONOFF { get; set; }


    }

    
    public class InfraTypTVKeysSet : AppInfoDataRet
    {
        
        public InfraTypTVkeysSet key_11 { get; set; }

        
        public InfraTypTVkeysSet key_12 { get; set; }

        
        public InfraTypTVkeysSet key_13 { get; set; }

        
        public InfraTypTVkeysSet key_14 { get; set; }

        
        public InfraTypTVkeysSet key_21 { get; set; }

        
        public InfraTypTVkeysSet key_22 { get; set; }

        
        public InfraTypTVkeysSet key_23 { get; set; }

        
        public InfraTypTVkeysSet key_24 { get; set; }

        
        public InfraTypTVkeysSet key_31 { get; set; }

        
        public InfraTypTVkeysSet key_32 { get; set; }

        
        public InfraTypTVkeysSet key_33 { get; set; }

        
        public InfraTypTVkeysSet key_34 { get; set; }


        
        public InfraTypTVkeysSet key_41 { get; set; }

        
        public InfraTypTVkeysSet key_42 { get; set; }

        
        public InfraTypTVkeysSet key_43 { get; set; }

        
        public InfraTypTVkeysSet key_44 { get; set; }


    }


    
    public class InfraTypTVOnOff : AppInfoDataRet
    {
        
        public string ON { get; set; }

        
        public string OFF { get; set; }
    }


    
    public class InfraTypTVLogoSet : AppInfoDataRet
    {
        
        public string off { get; set; }

        
        public string onl { get; set; }

        
        public string act { get; set; }
    }


    
    public class InfraTypTVkeysSet : AppInfoDataRet
    {
        
        public int instCount { get; set; }

        
        public string img { get; set; }

        
        public string[] text { get; set; }


        
        public string timer { get; set; }

        
        public string[] tag { get; set; }

        
        public string[] inst { get; set; }

        
        public string type { get; set; }


    }



    
    public class InfraTypeListRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public int errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public InfraTypeListData[] content { get; set; }

    }


    
    public class InfraTypeListData : AppInfoDataRet
    {
        
        public string typeid { get; set; }

        
        public string typename { get; set; }

        
        public bool IsCoolControl { get; set; }

        
        public string ControlType { get; set; }
        

    }



    #endregion




    #region 取一个值 的 返回类型

    /// <summary>
    /// 通用 返回类型
    /// </summary>
    
    public class GegValueRet : AppInfoDataRet
    {
        /// <summary>
        ///  返回结果：0:成功， 其他失败
        /// </summary>
        [DataMember(Order = 0)]
        public int errcode { get; set; }


        /// <summary>
        ///  结果描述 （一般是失败描述）
        /// </summary>
        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        [DataMember(Order = 2)]
        public string value { get; set; }

    }
    #endregion






    /// <summary>
    /// 用户的设备状态数据
    /// </summary>

    
    public class UserDeviceStateData : AppInfoDataRet
    {

        
        public string deviceId { get; set; }

        
        public string operCode { get; set; }

        
        public string operValue { get; set; }

    }

    
    public class UserDeviceStateRet : AppInfoDataRet
    {

        [DataMember(Order = 0)]
        public UserDeviceStateData[] state { get; set; }
        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 1)]
        public int errcode { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        [DataMember(Order = 2)]
        public string errmsg { get; set; }


    }





    
    public class DevicePowerRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public string errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public DevicePowerData[] content { get; set; }

    }


    
    public class DevicePowerData : AppInfoDataRet
    {
        
        public string deviceID { get; set; }

        
        public string c_SocketOut_P { get; set; }

        
        public string c_SocketOut_W { get; set; }

        
        public string c_SocketOutY_W { get; set; }

        
        public string LastMonthUserPower { get; set; }
        
        public string ThisMonthUserPower { get; set; }


    }





    
    public class UserShortcutInfo : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public string errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public UserShortcutData[] content { get; set; }

    }


    
    public class UserShortcutData : AppInfoDataRet
    {
        
        public string username { get; set; }

        
        public string objcode { get; set; }

        
        public string objtype { get; set; }

        
        public string location { get; set; }

        
        public string addtime { get; set; }

    }




    /// <summary>
    /// 设备版本信息
    /// </summary>
    
    public class DeviceVersionRet : AppInfoDataRet
    {

        [DataMember(Order = 0)]
        public string errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        [DataMember(Order = 2)]
        public string selfver { get; set; }


        [DataMember(Order = 3)]
        public string serverver { get; set; }
    }





    /// <summary>
    /// 设备类型组返回结构---
    /// </summary>
    
    public class DeviceTypeGroupRet : AppInfoDataRet
    {
        [DataMember(Order = 0)]
        public string errcode { get; set; }

        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        
        public DeviceTypeGroupData[] content { get; set; }

    }


    
    public class DeviceTypeGroupData : AppInfoDataRet
    {
        
        public string typeGroupCode { get; set; }

        
        public string typeGroupName { get; set; }

        
        public int orderIndex { get; set; }


    }


    
    public class CameraListRet : AppInfoDataRet
    {
        
        public string errcode { get; set; }
        
        public string errmsg { get; set; }
        
        public CameraData[] content { get; set; }
    }
    
    public class CameraData : AppInfoDataRet
    {
        
        public bool bIsMRMode { get; set; }
        
        public bool isCheck { get; set; }
        
        public bool isRecvMsg { get; set; }
        
        public bool isReverse { get; set; }
        
        public int lLastMsgFreshTime { get; set; }
        
        public int lLastMsgGetTime { get; set; }
        
        public int lOnLineStatChaneTime { get; set; }
        
        public int nDevID { get; set; }
        
        public int nID { get; set; }
        
        public int nMRPort { get; set; }
        
        public int nNewMsgCount { get; set; }
        
        public int nOnLineStat { get; set; }
        
        public int nPort { get; set; }
        
        public int nSaveType { get; set; }
        
        public string strDomain { get; set; }
        
        public string strIP { get; set; }
        
        public string strMac { get; set; }
        
        public string strName { get; set; }
        
        public string strPassword { get; set; }
        
        public string strUsername { get; set; }
        
        public string nickName { get; set; }
    }






    
    public class ConnectObj
    {
        
        public string ObjID { get; set; }

        
        public string ObjType { get; set; }
    }

    
    public class CameraListRec : AppInfoDataRet
    {
        
        public string sessionID { get; set; }
        
        public CameraData[] content { get; set; }
    }


    /// <summary>
    /// 设备类型变更 返回类
    /// </summary>
    
    public class UserBindCodeRet : AppInfoDataRet
    {
        /// <summary>
        /// 0: 表示成功， 其他表示失败
        /// </summary>
        [DataMember(Order = 0)]
        public int errcode { get; set; }

        /// <summary>
        /// 错误内容
        /// </summary>
        [DataMember(Order = 1)]
        public string errmsg { get; set; }

        [DataMember(Order = 2)]
        public string c_Email { get; set; }
        [DataMember(Order = 3)]
        public string c_QQ { get; set; }
        [DataMember(Order = 4)]
        public string c_Wechat { get; set; }

    }




    
    public class DeviceShareListRet : AppInfoDataRet
    {
        
        public string errcode { get; set; }
        
        public string errmsg { get; set; }
        
        public Sharedevlist[] ShareDevList { get; set; }
    }

    
    public class Sharedevlist
    {
        
        public string deviceid { get; set; }
        
        public string devicename { get; set; }
        
        public string userid { get; set; }
        
        public string nickname { get; set; }

        
        public string date { get; set; }
    }

    
    public class DevSceneStatelistRet : AppInfoDataRet
    {
        
        public int errcode { get; set; }
        
        public string errmsg { get; set; }
        
        public DevSceneStatelist[] content { get; set; }
    }

    
    public class DevSceneStatelist
    {
        
        public string DeviceCode { get; set; }
        
        public string StateCode { get; set; }
        
        public string StateValue { get; set; }
        
        public string StartTime { get; set; }
        
        public string EndTime { get; set; }
        
        public string time { get; set; }
    }


    
    public class DeviceUserListRet : AppInfoDataRet
    {
        
        public string errcode { get; set; }
        
        public string deviceid { get; set; }

        
        public string ownerusername { get; set; }
        
        public DeviceUserlist[] userlist { get; set; }
    }

    
    public class DeviceUserlist
    {
        
        public string userid { get; set; }
        
        public string username { get; set; }
    }

    
    public class DevUserDetailRet : AppInfoDataRet 
    {
        
        public int errcode { get; set; }
        
        public string errmsg { get; set; }
        
        public DevUserDetail Devuserdetail { get; set; }
    }
    
    public class DevUserDetail
    {
        
        public string devid { get; set; }
        
        public List<DevFunName> fun { get; set; }

    }

    
    public class DevFunName 
    {
        
        public string funcode { get; set; }
        
        public string funname { get; set; }
    }
    
    public class BindAccoundRet : AppInfoDataRet
    {
        
        public int errcode { get; set; }
        
        public string errmsg { get; set; }
        
        public bool state { get; set; }
        
        public string sessionID { get; set; }
        
        public string userName { get; set; }
    }
    public class GetUserID : AppInfoDataRet
    {
        
        public int errcode { get; set; }
        
        public string errmsg { get; set; }
        
        public string username { get; set; }
    }

    public class GetDeviceCount : AppInfoDataRet
    {
        
        public int errcode { get; set; }
        
        public string errmsg { get; set; }
        
        public int  DeviceStateCount { get; set; }
    }

    public class QueryDevCtlRef : AppInfoDataRet
    {
        
        public int errcode { get; set; }
        
        public string errmsg { get; set; }
        
        public DevcieCtlRef[] content { get; set; }
    }

    public class DevcieCtlRef
    {
        
        public string c_DeviceCode { get; set; }//源设备编码
        
        public string c_DeviceKey { get; set; }//源设备键位
        
        public string c_OperUserID { get; set; }//加入操作人
        
        public string c_CtrlGrpNo { get; set; }
    }


    public class QueryDevCtlRefNEW : AppInfoDataRet
    {
        
        public int errcode { get; set; }
        
        public string errmsg { get; set; }
        
        public DevcieCtlRefNEW[] content { get; set; }
    }
    public class DevcieCtlRefNEW
    {
        
        public string c_DeviceCode { get; set; }//源设备编码
        
        public string c_DeviceKey { get; set; }//源设备键位
        
        public string c_OperUserID { get; set; }//加入操作人
        
        public string c_CtrlGrpNo { get; set; }
        
        public string c_DeviceKeyAttr { get; set; }//是否是主控
    }


    
    public class UserDeskTopList:AppOrderRet
    {
        
        public List<DeskTopDev> DevList { get; set; }

        
        public List<DeskTopScene> SceneList { get; set; }

        
        public List<DeskTopZone> ZoneList { get; set; }

    }

    
    public class UserDeskTopList2 : AppOrderRet
    {
        
        public List<DeskTopObj> ObjList { get; set; }
    }


   

    
    public class DeskTopObj
    {
        
        public string ObjCode { get; set; }

        
        public string ObjType { get; set; }

        
        public string locationID { get; set; }
    }


    
    public class DeskTopZone
    {
        
        public string zoneID { get; set; }


        
        public string locationID { get; set; }
 
    }


    
    public class DeskTopDev
    {
        //
        //public string DeviceName { get; set; }

        
        public string DeviceID { get; set; }


        
        public string locationID { get; set; }

        //
        //public string DeviceTypeCode { get; set; }

        //
        //public string Token { get; set; }
    }


    
    public class DeskTopScene
    {
        
        public string SceneCode { get; set; }


        
        public string locationID { get; set; }

        //
        //public string SceneName { get; set; }


        //
        //public string ScenePicUrl { get; set; }

        //
        //public string SceneImgCode { get; set; }
    }


    
    public class QueryHostPrioAreaRet : AppInfoDataRet
    {
        
        public int errcode { get; set; }
        
        public string errmsg { get; set; }
        
        public List<HostPrioAreas> content { get; set; }
    }

    
    public class HostPrioAreas
    {
        
        public string LocationCode { get; set; }
        
        public string LocationName { get; set; }


        
        public string OrderNum { get; set; }

        
        public List<HostSecoAreas> ChildAreas { get; set; }
    }



    
    public class QueryHostSecoAreaRet : AppInfoDataRet
    {
        
        public int errcode { get; set; }
        
        public string errmsg { get; set; }
        
        public List<HostSecoAreas> content { get; set; }
    }

    
    public class HostSecoAreas
    {
        
        public string AreaCode { get; set; }
        
        public string AreaName { get; set; }
        
        public string LocationCode { get; set; }

        
        public string OrderNum { get; set; }

        
        public string PhotoAddr { get; set; }

        
        public string PicCode { get; set; }

    }

    
    public class ZigbeeRename : CommandRet 
    {
        
        public List<gateway> geteways { get; set; }
    }

    
    public class  gateway
    {
        
        public string getwayID { get; set; }
        
        public string getwayName { get; set; }
    }
}