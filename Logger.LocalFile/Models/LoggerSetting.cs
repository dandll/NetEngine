﻿using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Logger.LocalFile.Models
{
    public class LoggerSetting
    {


        /// <summary>
        /// App标记
        /// </summary>
        public string AppSign { get; set; } = Assembly.GetEntryAssembly()?.GetName().Name!;


        /// <summary>
        /// 最低记录等级
        /// </summary>
        public LogLevel MinLogLevel { get; set; } = LogLevel.Information;

    }
}