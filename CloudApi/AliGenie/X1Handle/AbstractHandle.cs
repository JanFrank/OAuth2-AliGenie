using CloudApi.AliGenie.X1ReceviceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1Handle
{
    public abstract class AbstractHandle
    {
        public AbstractHandle nextHandle { get; set; }

        public abstract object ProcessHandel(X1ReceiveObj receviceObj);
    }
}