﻿using CloudApi.AliGenie.X1CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1ReceviceModel
{
    public class X1ReceiveObj
    {
        /// <summary>
        /// 
        /// </summary>
        public X1Head header { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public X1ReceivePayload payload { get; set; }
    }
}