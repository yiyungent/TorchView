using System;
using System.Collections.Generic;
using System.Text;

namespace TorchView
{
    public static class WebConfig
    {
        /// <summary>
        /// Web根目录
        /// </summary>
        public static string WebRootPath { get; set; } = "wwwroot";

        public static string Port { get; set; } = "12531";
    }
}
