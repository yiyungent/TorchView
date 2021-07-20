using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.IO;


[assembly: Dependency(typeof(TorchView.Droid.AndroidWebFile))]
namespace TorchView.Droid
{
    public class AndroidWebFile : IWebFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">相对路径 (相对于Web根目录)</param>
        /// <returns></returns>
        public string ReadFile(string filePath)
        {
            string rtnStr = string.Empty;

            Context context = Android.App.Application.Context;
            var assetManager = context.Assets;
            System.IO.Stream stream = null;
            try
            {
                string webRootPath = WebConfig.WebRootPath;
                // 使用 Path.Combine() 拼接异常, 始终是 /index.html
                //filePath = System.IO.Path.Combine(webRootPath, filePath);
                filePath = webRootPath + filePath;
                stream = assetManager.Open(filePath);
                rtnStr = ReadDataFromStream(stream);
            }
            catch (Exception ex)
            {

            }

            return rtnStr;
        }

        private string ReadDataFromStream(Stream stream)
        {
            string content = string.Empty;
            using (StreamReader sr = new StreamReader(stream))
            {
                content = sr.ReadToEnd();
            }

            return content;
        }
    }
}