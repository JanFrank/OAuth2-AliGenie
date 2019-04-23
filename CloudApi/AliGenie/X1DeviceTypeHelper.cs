using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie
{
    public class X1DeviceTypeHelper
    {
        /// <summary>
        /// 类型转换方法
        /// 用于将自家设备类型 转换成 天猫对应的设备类型
        /// </summary>
        /// <param name="devType"></param>
        /// <returns></returns>
        public static string GetAliGenieX1SupportType(string devType)
        {
            switch (devType)
            {
                case "0000":
                case "0001":
                    return "light";
                case "0002":
                    return "light";
                case "0003":
                case "0004":
                case "0005":
                    return "curtain";
                case "0006"://插座...
                    return "outlet";

                default:
                    return devType;
            }
        }


        /// <summary>
        /// 根据设备类型获取默认名称
        /// 此方法自行处理
        /// </summary>
        /// <param name="devType"></param>
        /// <returns></returns>
        public static string GetAliGenieX1DevName(string devType)
        {
            switch (devType)
            {
                case "0002":
                    return "灯";
                default:
                    return devType;
            }
        }

        /*
         *  中文名   类型值
            电视	television
            灯	light
            空调	aircondition
            空气净化器	airpurifier
            插座	outlet
            开关	switch
            扫地机器人	roboticvacuum
            窗帘	curtain
            加湿器	humidifier
            风扇	fan
            暖奶器	bottlewarmer
            豆浆机	soymilkmaker
            电热水壶	kettle
            饮水机	watercooler
            摄像头	camera
            路由器	router
            电饭煲	cooker
            热水器	waterheater
            烤箱	oven
            净水器	waterpurifier
            冰箱	fridge
            机顶盒	STB
            传感器	sensor
            洗衣机	washmachine
            智能床	smartbed
            香薰机	aromamachine
            窗	window
            抽油烟机	kitchenventilator
            指纹锁	fingerprintlock
            万能遥控器	telecontroller
            洗碗机	dishwasher
            除湿机	dehumidifier
            干衣机	dryer
            壁挂炉	wall-hung-boiler
         */
    }
}