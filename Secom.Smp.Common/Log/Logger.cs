/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.Log
* 文件名: Logger
* 创建者: 邹琼俊
* 创建时间: 2017/7/27 13:57:19
* 版权所有： 紫衡技术
******************************************************************/
using log4net;
using System;
using System.IO;

namespace Secom.Smp.Common.Log
{
    /// <summary>
    /// 通用日志记录器
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// 通用错误日志记录器
        /// </summary>
        private static readonly ILog Logger_Error = LogManager.GetLogger("logerror");

        /// <summary>
        /// 通用信息日志记录器
        /// </summary>
        private static readonly ILog Logger_Info = LogManager.GetLogger("loginfo");

        /// <summary>
        /// 
        /// </summary>
        static Logger()
        {
            FileInfo log4netFile =
                new FileInfo(string.Format("{0}/Configs/log4net.config", AppDomain.CurrentDomain.BaseDirectory));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(log4netFile);
        }

        /// <summary>
        /// 记录日常日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Log(string message, Exception ex)
        {
            Logger_Error.Error(message, ex);
        }

        /// <summary>
        /// 记录信息日志
        /// </summary>
        /// <param name="message"></param>
        public static void LogInfo(string message)
        {
            Logger_Error.Error(message);
        }
    }
}
