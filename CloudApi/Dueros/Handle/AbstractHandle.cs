using CloudApi.Dueros.Models.CommonModel;
using CloudApi.Dueros.Models.ReceiveModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Handle
{
    public abstract class AbstractHandle
    {
        public AbstractHandle nextHandle { get; set; }

        public abstract object ProcessHandel(CommonReceiveModel receiveObj);
    }
}