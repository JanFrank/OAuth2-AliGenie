using System;
using System.Globalization;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Collections;
using CloudApi.Models;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Security.Cryptography;


namespace CloudApi.ToolHelper
{
    public static class FunctionHelper
    {


        /// <summary>
        /// 序列化一个对象 成为 json 格式返回..
        /// </summary>
        /// <param name="obj"> 对象 </param>
        /// <returns></returns>
        public static HttpResponseMessage SerializerJson(BaseInfo obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = serializer.Serialize(obj);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }



        /// <summary>
        /// 序列化一个对象 成为 json 格式返回..
        /// </summary>
        /// <param name="obj"> 对象 </param>
        /// <returns></returns>
        public static HttpResponseMessage SerializerJson(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = serializer.Serialize(obj);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }



        /// <summary>
        /// 时间转时间戳
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        public static long GetTimStamp( )
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
            long timeStamp = (long)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数
            //Debug.Log("\n 当前 时间戳为：" + timeStamp);
            return timeStamp;
        }



     


        /// <summary>
        /// 写日志的函数
        /// </summary>
        /// <param name="headtype"></param>
        /// <param name="logmsg"></param>
        /// <param name="DevID"></param>
        public static void writeLog(string headtype, string logmsg, string DevID)
        {
            //return;

            System.Threading.Tasks.Task.Run(() =>
            {
                string datedire = DateTime.Now.ToString("yyyyMMdd"); //每天一个文件夹
                // string path = @"c:\WebApi\" + datedire;
                string path = System.AppDomain.CurrentDomain.BaseDirectory + "log\\" + datedire;


                string pathfile = path + "\\" + DevID + ".log";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                try
                {
                    if (File.Exists(pathfile))
                    {
                        using (StreamWriter tw = File.AppendText(pathfile))
                        {
                            tw.WriteLine("\r\nStart");
                            tw.WriteLine("--t:" + GetDateTimeCodeString());
                            tw.WriteLine("--h：" + headtype);
                            tw.WriteLine("--b：" + logmsg);
                            tw.WriteLine("End");
                            tw.Flush();
                            tw.Close();

                        }

                    }
                    else
                    {
                        using (StreamWriter tw = File.AppendText(pathfile))
                        {
                            tw.WriteLine("\r\nStart");
                            tw.WriteLine("--t:" + GetDateTimeCodeString());
                            tw.WriteLine("--h：" + headtype);
                            tw.WriteLine("--b：" + logmsg);
                            tw.WriteLine("End");
                            tw.Flush();
                            tw.Close();
                        }
                    }
                }
                catch
                {
                }
            });
        }




        #region MD5加密

        /// <summary>
        /// MD5加密
        /// </summary>
        public static string Md532(this string value)
        {
            var encoding = Encoding.UTF8;
            MD5 md5 = MD5.Create();
            return HashAlgorithmBase(md5, value, encoding);
        }


        /// <summary>
        /// HashAlgorithm 加密统一方法
        /// </summary>
        private static string HashAlgorithmBase(HashAlgorithm hashAlgorithmObj, string source, Encoding encoding)
        {
            byte[] btStr = encoding.GetBytes(source);
            byte[] hashStr = hashAlgorithmObj.ComputeHash(btStr);
            return hashStr.Bytes2Str();
        }


        /// <summary>
        /// 转换成字符串
        /// </summary>
        private static string Bytes2Str(this IEnumerable<byte> source, string formatStr = "{0:X2}")
        {
            StringBuilder pwd = new StringBuilder();
            foreach (byte btStr in source) { pwd.AppendFormat(formatStr, btStr); }
            return pwd.ToString();
        }


        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsonData"></param>
        /// <param name="timeOut">默认超时时间为10秒</param>
        /// <returns></returns>
        public static string PostJsonString(string url, string jsonData, int timeOut = 10)
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/json";
                byte[] postBytes = Encoding.UTF8.GetBytes(jsonData);
                myRequest.ContentLength = postBytes.Length;
                //  myRequest.Proxy = null;

                myRequest.Timeout = 1000 * timeOut; // 1分种
                myRequest.KeepAlive = true;
                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(postBytes, 0, postBytes.Length);
                newStream.Close();

                // Get response
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();

                using ( StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8) )
                {
                    string content = reader.ReadToEnd();
                    return content;
                }

            }
            catch ( System.Exception ex )
            {
                return ex.Message;
            }
        }





        /// <summary>
        /// 整型数组转成 字符串
        /// </summary>
        /// <param name="intArray">整型数组</param>
        /// <returns></returns>
        public static string IntArrayToStr(int[] intArray)
        {
            string result = "";
            for ( int i = 0; i < intArray.Length; i++ )
            {
                result += intArray[i].ToString() + ",";
            }

            return result.Substring(0, result.Length - 1);
        }



        /// <summary>
        /// 字符串 转在 整型数组
        /// </summary>
        /// <param name="strvalue">字符串如： "1,2,3"</param>
        /// <returns></returns>
        public static int[] StrToIntArray(string strvalue)
        {
            string[] tempresult = strvalue.Split(',');

            int[] result = new int[tempresult.Length];

            for ( int i = 0; i < tempresult.Length; i++ )
            {
                result[i] = int.Parse(tempresult[i]);
            }

            return result;

        }








        /// <summary>
        /// 取得以日期时间为编码的字符串   精确到秒
        /// </summary>
        /// <returns></returns>

        public static string GetDateTimeCodeString()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }




        /// <summary>
        /// 取得以日期时间为编码的字符串  精确到毫秒, + 5位随机数
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeCodeLongString()
        {
            Random rd = new Random(unchecked((int)DateTime.Now.Ticks));
            int rdvalue = rd.Next(10000, 99999);
            return DateTime.Now.ToString("yyyyMMddHHmmssfff") + rdvalue.ToString();
        }


        /// <summary>
        /// 取得以日期时间为编码的字符串  精确到毫秒, + 6位随机数
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeCodeMoreLongString()
        {
            Random rd = new Random(unchecked((int)DateTime.Now.Ticks));
            int rdvalue = rd.Next(100000, 999999);
            return DateTime.Now.ToString("yyyyMMddHHmmssfff") + rdvalue.ToString();
        }



        /// <summary>
        /// 取得以日期时间为编码的字符串  精确到毫秒, + 7位随机数
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeCodeMoreMoreLongLongString()
        {
            Random rd = new Random(unchecked((int)DateTime.Now.Ticks));
            int rdvalue = rd.Next(1000000, 9999999);
            return DateTime.Now.ToString("yyyyMMddHHmmssfff") + rdvalue.ToString();
        }


        /// <summary>
        /// 取得以日期时间为编码的字符串  + 6位随机数
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeCodeShotString()
        {
            Random rd = new Random(unchecked((int)DateTime.Now.Ticks));
            int rdvalue = rd.Next(100000, 999999);
            return DateTime.Now.ToString("yyyyMMdd") + rdvalue.ToString();
            //string newstr="";
            //for(int i=0;i<str.Length;i+=2)
            //{

            //    newstr += Convert.ToString(int.Parse(str[i].ToString() + str[i+1].ToString()), 16);
            //    ClsFun.writeLog(newstr + "   ", str[i].ToString() + str[i + 1].ToString(), "chu");
            //}
            //return newstr;
        }


        /// <summary>
        /// 取得设备类型编码
        /// </summary>
        /// <param name="devid"></param>
        /// <returns></returns>
        public static string GetDeviceTypeCode(string devid)
        {
            string tablename = "Device";
            string where = " where c_DeviceID = " + OPHelper.Operation.AddQuot(devid);
            string result = "";
            System.Data.DataTable dt = DBHelper.SqlHelper.GetDataTable(tablename, where);
            foreach ( DataRow dr in dt.Rows )
            {
                result = dr["c_DeviceTypeCode"].ToString();
            }

            return result;
        }


        public static bool IsBlueBoothDevice(string devTypeCode)
        {
            bool result = false;

            if ( devTypeCode == "801" )
            {
                return true;

            }

            if ( devTypeCode == "802" )
            {
                return true;
            }

            if ( devTypeCode == "803" )
            {
                return true;
            }


            if ( devTypeCode == "804" )
            {
                return true;
            }


            return result;
        }


        public static bool Is485Dev(string typeCode)
        {
            if ( typeCode == "481" || typeCode == "482" || typeCode == "483" ||
                typeCode == "441" || typeCode == "442" || typeCode == "443" ||
                typeCode == "444" || typeCode == "248" || typeCode == "355" )
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// 取得情景图标 路径
        /// </summary>
        /// <param name="sceneImgCode"></param>
        /// <returns></returns>
        public static string GetSceneImgPath(string sceneImgCode)
        {
            string tablename = "SceneImageList";
            string where = " where c_ImgCode = " + OPHelper.Operation.AddQuot(sceneImgCode);

            System.Data.DataTable dt = DBHelper.SqlHelper.GetDataTable(tablename, where);

            string result = "";
            foreach ( DataRow dr in dt.Rows )
            {
                result = dr["c_ImgPath"].ToString();
            }
            if ( result == "" )
            {
                result = "no exists " + sceneImgCode;
            }

            return result;
        }







        /// <summary>
        /// 根据所传的不同的命令取得ParameCode
        /// </summary>
        /// <param name="OperCode"></param>
        /// <returns></returns>
        public static string GetAutoLockParamCode(string OperAddress)
        {
            string ParameCode = "";
            switch ( OperAddress )
            {
                case "10"://远程增加用户
                {
                    ParameCode = "Type#User#Pwd";
                    break;
                }
                case "11"://远程删除用户
                {
                    ParameCode = "Type#Code";
                    break;
                }
                case "13"://远程设置门锁
                {
                    ParameCode = "Type#Info";
                    break;
                }
                case "14"://用户设置常开
                {
                    ParameCode = "Open";
                    break;
                }
                case "20"://用户远程开/关门
                {
                    ParameCode = "State";
                    break;
                }
                case "21"://门锁状态查询
                case "24"://产品信息查询
                case "27"://查询存储状态
                {
                    ParameCode = "Type";
                    break;
                }
                case "22"://门锁电量查询
                {
                    ParameCode = "Power";
                    break;
                }
                case "25"://系统时间查询
                {
                    ParameCode = "GetTime";
                    break;
                }
                case "26"://设置系统时间
                {
                    ParameCode = "Time";
                    break;
                }
                case "29":
                {
                    ParameCode = "GetLockState";
                    break;
                }
                default:
                break;
            }
            return ParameCode;
        }



        public static string DataTableToJson(DataTable dt)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
            ArrayList arrayList = new ArrayList();

            foreach ( DataRow dataRow in dt.Rows )
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>(); //实例化一个参数集合
                foreach ( DataColumn dataColumn in dt.Columns )
                {
                    // dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToStr());
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToString());
                }
                arrayList.Add(dictionary); //ArrayList集合中添加键值

            }

            return javaScriptSerializer.Serialize(arrayList);  //返回一个json字符串

        }



        public static DataTable ToDataTable(string json)
        {
            DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if ( arrayList.Count > 0 )
                {
                    foreach ( Dictionary<string, object> dictionary in arrayList )
                    {
                        if ( dictionary.Keys.Count<string>() == 0 )
                        {
                            result = dataTable;
                            return result;
                        }

                        if ( dataTable.Columns.Count == 0 )
                        {
                            foreach ( string current in dictionary.Keys )
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }

                        DataRow dataRow = dataTable.NewRow();
                        foreach ( string current in dictionary.Keys )
                        {
                            dataRow[current] = dictionary[current];
                        }

                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
            }

            result = dataTable;
            return result;

        }



        public static string ToJsonStr(object s, string format = "")
        {
            string result = "";
            try
            {
                if ( format == "" )
                {
                    result = s.ToString();
                }
                else
                {
                    result = string.Format("{0:" + format + "}", s);
                }
            }
            catch
            {
            }
            return result;
        }



        /// <summary>
        /// 取得情景名称
        /// </summary>
        /// <param name="devID"></param>
        /// <returns></returns>
        public static string GetSceneName(string sceneCode)
        {
            string result = "";
            string where = " where  c_SceneCode = " + OPHelper.Operation.AddQuot(sceneCode);
            DataTable dt = DBHelper.SqlHelper.GetDataTable("SceneInfo", where);
            foreach ( DataRow dr in dt.Rows )
            {
                result = dr["c_SceneName"].ToString();
            }

            return result;
        }



        /// <summary>
        /// 主机的动作，如升级，取版本号，添加设备，删除设备等，都需将主机号 作为设备号下发
        /// </summary>
        /// <param name="actionID"></param>
        /// <returns></returns>
        public static bool IsHostAction(string actionID)
        {
            bool result = false;

            if ( actionID == "900" )
            {
                return true;

            }

            if ( actionID == "901" )
            {
                return true;
            }

            if ( actionID == "902" )
            {
                return true;
            }

            if ( actionID == "903" )
            {
                return true;
            }

            if ( actionID == "100" )
            {
                return true;
            }

            if ( actionID == "101" )
            {
                return true;
            }

            return result;
        }







        public static string GetRightStr_(string str)
        {
            int posti = str.LastIndexOf('_');
            if ( posti != -1 )
            {
                return str.Substring(posti + 1, str.Length - posti - 1);
            }

            return "";
        }


        public static string GetLeftStr_(string str)
        {
            int posti = str.LastIndexOf('_');
            if ( posti != -1 )
            {
                return str.Substring(0, posti);
            }
            return "";
        }


        public static bool IsHostDevice(string devID)
        {
            return ( devID.LastIndexOf('_') > 0 );
        }




        /// <summary>
        /// 红外设备
        /// </summary>
        /// <param name="devTypeCode"></param>
        /// <returns></returns>
        public static bool IsInfrareadDevice(string devTypeCode)
        {
            bool result = false;

            if ( devTypeCode == "301" )
            {
                return true;

            }

            if ( devTypeCode == "309" )
            {
                return true;
            }

            if ( devTypeCode == "310" )
            {
                return true;
            }


            return result;

        }



        /// <summary>
        /// 情景 设备--随意贴
        /// </summary>
        /// <param name="devTypeCode"></param>
        /// <returns></returns>
        public static bool IsSceneDevice(string devTypeCode)
        {
            bool result = false;

            switch ( devTypeCode )
            {
                case "421":
                case "422":
                case "423":
                case "424":
                case "441":
                case "442":
                case "443":
                case "444":
                case "483":
                case "2103":
                {
                    result = true;
                    break;
                }
                default:
                break;
            }
            return result;
        }


        public static bool IsHostLightDevice(string devTypeCode)
        {
            bool result = false;
            switch ( devTypeCode )
            {
                case "2101":
                case "2106":
                case "248":
                case "355":
                case "481":
                {
                    result = true;
                    break;
                }
                default:
                break;
            }
            return result;
        }


        /// <summary>
        /// 需统计电量 的设备
        /// </summary>
        /// <param name="devTypeCode"></param>
        /// <returns></returns>
        public static bool IsCountPowerDevice(string devTypeCode)
        {
            bool result = false;

            if ( devTypeCode == "301" )
            {
                return true;

            }

            if ( devTypeCode == "302" )
            {
                return true;
            }

            if ( devTypeCode == "303" )
            {
                return true;
            }

            return result;
        }







        /// <summary>
        /// 扩展 string方法 加上''号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AddQuot(this string str)
        {
            return "'" + str + "'";
        }



        /// <summary>
        /// 将时间格式化成"yyyy-MM-dd HH:mm:ss"的格式 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DateTimeFormat(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }


       




        /// <summary>
        /// 反序列化xml 数据到一个对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="xmlData">xml数据</param>
        /// <returns></returns>
        public static T DeSerializerXml<T>(string xmlData)
        {
            StringReader rdr = new StringReader(xmlData);
            //声明序列化对象实例serializer 
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            T obj = (T)serializer.Deserialize(rdr);
            return obj;

        }


        /// <summary>
        /// 序列化一个对象 到xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializerXml<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            System.IO.MemoryStream mmstream = new System.IO.MemoryStream();
            serializer.Serialize(mmstream, obj);
            return  System.Text.Encoding.Default.GetString(mmstream.GetBuffer());
        }





        /// <summary>
        /// 16进制转成字符串
        /// </summary>
        /// <param name="mHex"></param>
        /// <returns></returns>
        public static string HexToStr(string mHex) // 返回十六进制代表的字符串
        {
            mHex = mHex.Replace(" ", "");
            if ( mHex.Length <= 0 ) return "";
            byte[] vBytes = new byte[mHex.Length / 2];
            for ( int i = 0; i < mHex.Length; i += 2 )
                if ( !byte.TryParse(mHex.Substring(i, 2), NumberStyles.HexNumber, null, out vBytes[i / 2]) )
                    vBytes[i / 2] = 0;
            return ASCIIEncoding.Default.GetString(vBytes);
        }


    }
}