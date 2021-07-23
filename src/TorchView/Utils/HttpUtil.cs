using System;
using System.Collections.Generic;
using System.Text;

namespace TorchView.Utils
{
    public class HttpUtil
    {

        /// <summary>
        /// Content-Type(Mime-Type)
        /// </summary>
        /// <param name="url">根据 url 中的文件扩展名</param>
        /// <returns></returns>
        public static string GetContentType(string url)
        {
            // .*（ 二进制流，不知道下载文件类型）
            string contentType = "application/octet-stream";
            // https://www.cnblogs.com/SingleCat/p/5141716.html
            Dictionary<string, string> dicMimeTypes = new Dictionary<string, string>
            {
                { ".xml", "text/xml" },
                { ".woff", "application/x-font-woff" },
                { ".woff2", "application/x-font-woff" },
                { ".ttf", "application/x-font-truetype" },
                { ".js", "application/x-javascript" },
                { ".svg", "image/svg+xml" },
                { ".tif", "image/tiff" },
                { ".json", "application/json" },
                { ".html" , "text/html" },
                { ".eot", "application/vnd.ms-fontobject" },
                { ".otf", "font/opentype" },
                { ".css", "text/css" }
            };

            foreach (var mimeType in dicMimeTypes)
            {
                if (url.EndsWith(mimeType.Key))
                {
                    contentType = mimeType.Value;
                    break;
                }
            }

            return contentType;
        }

    }
}
