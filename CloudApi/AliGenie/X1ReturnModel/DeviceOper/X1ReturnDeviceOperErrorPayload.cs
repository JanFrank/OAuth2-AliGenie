using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudApi.AliGenie.X1ReturnModel.DeviceOper
{

    /// <summary>
    /// 设备操作失败结果
    /// </summary>
    public class X1ReturnDeviceOperErrorPayload : X1ReturnDeviceOperSuccesspPayload
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public string errorCode { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string message { get; set; }
    }

    /*
     错误码 errorCode	            错误码说明	                对应message
    INVALIDATE_CONTROL_ORDER	  控制指令不正确	            invalidate control order
    SERVICE_ERROR	                服务异常	                服务错误原因（方便观察原因）
    DEVICE_NOT_SUPPORT_FUNCTION	  设备不支持该操作	            device not support
    INVALIDATE_PARAMS	            请求参数有误	            invalidate params
    DEVICE_IS_NOT_EXIST	            设备未找到	                device is not exist
    IOT_DEVICE_OFFLINE	            设备离线状态	            device is offline
    ACCESS_TOKEN_INVALIDATE	    access_token 无效（包括失效）	access_token is invalidate
     */

}