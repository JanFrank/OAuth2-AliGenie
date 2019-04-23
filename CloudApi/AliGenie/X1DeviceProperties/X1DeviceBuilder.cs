using CloudApi.AliGenie.X1ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1DeviceProperties
{
    public class X1DeviceBuilder
    {
     


        public static List<string> BuildDevActions(string devType)
        {
            List<string> lss = new List<string>() { "Query" }; 
            DevicePropertiesAndAction devProp = new DevicePropertiesAndAction();
            
            switch (devType)
            {
                case "0x0001"://普通开关
                case "0002"://普通开关
                case "0004"://情景开关
                case "0202win103"://窗帘开关（没进度）
                case "0202win104"://窗帘开关（有进度）

                    lss.Add("TurnOff");
                    lss.Add("TurnOn");
                    lss.Add("QueryPowerState");
                    
                    break;
                case "scene":
                    //PowerStatePropertieAndAction powerProp2 = new PowerStatePropertieAndAction(devProp);
                    //lss = powerProp2.GetActions(lss);
                    
                    lss.Add("TurnOff");
                    lss.Add("TurnOn");
                    lss.Add("QueryPowerState");
                    break;
                default:
                    //lss = devProp.GetActions(lss);
                    break;
            }
            return lss;
        }
    }
}