using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using CloudApi.ToolHelper;

namespace CloudApi.Providers
{


    public class OpenAuthorizationCodeProvider : AuthenticationTokenProvider
    {
        private readonly ConcurrentDictionary<string, string> _authenticationCodes = new ConcurrentDictionary<string, string>(StringComparer.Ordinal);



        /// <summary>
        /// 生成 authorization_code
        /// </summary>
        public override void Create(AuthenticationTokenCreateContext context)
        {
            context.SetToken(Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n"));

            string TempTicket = context.SerializeTicket();
            _authenticationCodes.AddOrUpdate(context.Token, TempTicket, (k, ov) => ov = TempTicket);
            
        }



        /// <summary>
        /// 由 authorization_code 解析成 access_token
        /// </summary>
        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            string value;
            if (_authenticationCodes.TryRemove(context.Token, out value))
            {
                context.DeserializeTicket(value);
            }
        }


    }
}