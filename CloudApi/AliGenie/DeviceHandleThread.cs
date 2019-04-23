using CloudApi.AliGenie.X1Handle;
using CloudApi.AliGenie.X1ReceviceModel;
using CloudApi.ToolHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;



namespace CloudApi.AliGenie
{
    /// <summary>
    /// 获取天猫指令队列，发到具体的设备上...
    /// </summary>
    public class DeviceHandleThread
    {
        public static System.Collections.Concurrent.ConcurrentQueue<X1ReceiveObj> DeviceOperQueue=new System.Collections.Concurrent.ConcurrentQueue<X1ReceiveObj>();

        /// <summary>
        /// 
        /// </summary>
        public static void StartThread()
        {

            Task.Run(() => {
                while (true)
                {
                    Thread.Sleep(10);
                    if (DeviceOperQueue.IsEmpty)
                    {
                    }
                    else
                    {
                        X1ReceiveObj item;
                        if (DeviceOperQueue.TryDequeue(out item))
                        {
                            //具体向设备发送的代码，逻辑自己写...
                        }
                    }
                }
            });
        }
    }
}