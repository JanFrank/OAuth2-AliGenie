using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.Dueros.Handle
{
    public class DetalHeadle
    {
        public string ReceiveObj { get; set; }

        public DetalHeadle(string receiveObj)
        {
            ReceiveObj = receiveObj;
        }

    }
}