using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TorchView
{
    public static class WebServerExtensions
    {
        public static IWebServer Get()
        {
            return Get(TorchConfig.Port);
        }

        public static IWebServer Get(string port)
        {
            IWebFile webFile = DependencyService.Get<IWebFile>();
            if (webFile == null)
            {
                throw new Exception("No instance of IWebFile was found, you may not have injected through DependencyService");
            }
            WebServer webServer = new WebServer(new string[] { $"http://*:{port}/" }, webFile);

            return webServer;
        }

    }
}
