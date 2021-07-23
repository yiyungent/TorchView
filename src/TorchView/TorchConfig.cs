using System;
using System.Collections.Generic;
using System.Text;

namespace TorchView
{
    public static class TorchConfig
    {
        /// <summary>
        /// Web根目录
        /// </summary>
        public static string WebRootPath { get; set; } = "wwwroot";

        public static string Port { get; set; } = "12531";


        /// <summary>
        /// 采用区分: Host， 而不是 Scheme， 不推荐使用 Scheme 区分
        /// </summary>
        public static string UrlHost { get; set; } = "torchview";
    }
}
