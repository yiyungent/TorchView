using System;
using TorchView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo
{
    public partial class App : Application
    {
        private IWebServer _webServer;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            var webFile = DependencyService.Get<IWebFile>();

            // 默认监听 12531 端口
            this._webServer = WebServerExtensions.Get();
        }

        protected override void OnStart()
        {
            this._webServer.Start();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
