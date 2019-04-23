using CloudApi.AliGenie.X1ReceviceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1Handle
{
    public class DealHead
    {
        public X1ReceiveObj ReceiveObj { get; set; }

        public DealHead(X1ReceiveObj receiveObj)
        {
            ReceiveObj = receiveObj;
        }

    }

}