using System;
using System.Collections.Generic;
using System.Text;

namespace TorchView
{
    public interface IWebFile
    {

        /// <summary>
        /// 传入 文件相对路径 (相对于 web根目录),
        /// 返回 文件内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string ReadFile(string filePath);

    }
}
