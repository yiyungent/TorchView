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
using TorchView;


[assembly: Dependency(typeof(TorchView4Droid.AndroidWebFile))]
namespace TorchView4Droid
{
    public class AndroidWebFile : IWebFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">相对路径 (相对于Web根目录)</param>
        /// <returns></returns>
        public byte[] ReadFile(string filePath)
        {
            MemoryStream memoryStream = new MemoryStream();

            Context context = Android.App.Application.Context;
            var assetManager = context.Assets;
            System.IO.Stream assetStream = null;
            byte[] rtnBuffer;
            try
            {
                string webRootPath = WebConfig.WebRootPath;
                // 使用 Path.Combine() 拼接异常, 始终是 /index.html
                //filePath = System.IO.Path.Combine(webRootPath, filePath);
                filePath = webRootPath + filePath;
                assetStream = assetManager.Open(filePath);

                assetStream.CopyTo(memoryStream);

                long len = memoryStream.Length;

                //rtnBuffer = new byte[len];

                rtnBuffer = memoryStream.ToArray();


                //using (BinaryReader reader = new BinaryReader(memoryStream))
                //{
                //    //string temp = reader.ReadString();
                //    rtnBuffer = reader.ReadBytes((int)len);
                //}
                //using (BinaryReader reader = new BinaryReader(memoryStream))
                //{
                //    rtnBuffer = ReadAllBytes(reader);
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("AndroidWebFile.ReadFile: assetManager.Open(filePath)", ex);
            }

            return rtnBuffer;
        }

        public byte[] ReadAllBytes(BinaryReader reader)
        {
            const int bufferSize = 4096;
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[bufferSize];
                int count;
                while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                    ms.Write(buffer, 0, count);
                return ms.ToArray();
            }

        }


    }
}