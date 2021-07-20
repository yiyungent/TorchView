using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace TorchView
{
    public class WebServer : IWebServer
    {
        protected string[] _prefixes;

        public HttpListener Listener { get; set; }

        public IWebFile WebFile { get; set; }

        public WebServer(string[] prefixes, IWebFile webFile)
        {
            this._prefixes = prefixes;
            this.WebFile = webFile;
        }


        // This example requires the System and System.Net namespaces.
        public void Start()
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            // URI prefixes are required,
            // for example "http://contoso.com:8080/index/".
            if (_prefixes == null || _prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            this.Listener = new HttpListener();

            new Thread(new System.Threading.ThreadStart(() =>
            {

                #region 不断监听
                while (true)
                {
                    try
                    {
                        // Add the prefixes.
                        foreach (string s in _prefixes)
                        {
                            this.Listener.Prefixes.Add(s);
                        }
                        // 开始监听
                        this.Listener.Start();
                    }
                    catch (Exception ex)
                    {
                        // 启动失败    
                    }

                    while (true)
                    {
                        // 等待请求连接
                        // 没有请求则GetContext处于阻塞状态
                        HttpListenerContext ctx = this.Listener.GetContext();

                        ThreadPool.QueueUserWorkItem(new WaitCallback(TaskProc), ctx);
                    }

                }
                #endregion

            }))
            { IsBackground = true }.Start();

        }

        private void TaskProc(object obj)
        {
            HttpListenerContext context = (HttpListenerContext)obj;

            HttpListenerRequest request = context.Request;
            // Obtain a response object.
            HttpListenerResponse response = context.Response;
            // 设置返回给 客户端http状态代码
            response.StatusCode = 200;

            // url 解析
            // eg: /index.html
            string urlPath = request.Url.LocalPath;
            // _webBasePath: Android: file:///android_asset/Content/
            // 注意: 不能用 Path.Combine(), 无法应用于 file:///, 拼接出来的地址错误
            //string filePath = Path.Combine(_webBasePath, urlPath);
            string filePath = urlPath;

            // Construct a response.
            //string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            string responseString = string.Empty;
            try
            {
                // 无法通过这种方式访问 Assets, 由各个平台具体实现 读取文件
                //responseString = File.ReadAllText(filePath);
                responseString = this.WebFile.ReadFile(filePath);
            }
            catch (Exception ex)
            {

            }

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
        }
    }
}
