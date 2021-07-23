using Android.Content;
using Android.OS;
using Android.Webkit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TorchView.Components;
using TorchView4Droid.Components;
using WebView = Xamarin.Forms.WebView;

// 使用该[Export]属性的Android 项目必须包含对 的引用 Mono.Android.Export，否则将导致编译器错误。
[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace TorchView4Droid.Components
{
    public class HybridWebViewRenderer : WebViewRenderer
    {
        const string JavascriptFunction = "function invokeCSharpAction(data){jsBridge.invokeAction(data);}";
        Context _context;

        public HybridWebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe from event handlers

                Control.RemoveJavascriptInterface("jsBridge");
                ((HybridWebView)Element).Cleanup();
            }
            if (e.NewElement != null)
            {
                // Configure the native control and subscribe to event handlers

                // 用于在 Chrome DevTools 调试 WebView
                Android.Webkit.WebView.SetWebContentsDebuggingEnabled(true);

                // 1.WebViewClient
                var webViewClient = new JavascriptWebViewClient(this, $"javascript: {JavascriptFunction}");
                Control.SetWebViewClient(webViewClient);
                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");


                // 2.WebSettings
                // 设置渲染优先级
                Control.Settings.SetRenderPriority(Android.Webkit.WebSettings.RenderPriority.High);
                //Control.Settings.CacheMode = Android.Webkit.CacheModes.NoCache;
                // 如果内容已经存在cache 则使用cache，即使是过去的历史记录。如果cache中不存在，从网络中获取
                //Control.Settings.CacheMode = Android.Webkit.CacheModes.CacheElseNetwork;

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    //Log.v(TAG, "版本大于21，启动setMixedContentMode(0)");
                    // 解决http及https混合情况下页面加载问题
                    Control.Settings.MixedContentMode = MixedContentHandling.AlwaysAllow;
                }
                else
                {
                    //Log.v(TAG, "版本小于21，无须启动setMixedContentMode(0)");
                }

                // 打开 WebView 的 storage 功能，这样 JS 的 localStorage,sessionStorage 对象才可以使用
                Control.Settings.DomStorageEnabled = true;

                // 设置是否打开 WebView 表单数据的保存功能
                Control.Settings.SaveFormData = false;

                // 设置是否 WebView 支持 “viewport” 的 HTML meta tag，这个标识是用来屏幕自适应的，当这个标识设置为 false 时，
                // 页面布局的宽度被一直设置为 CSS 中控制的 WebView 的宽度；如果设置为 true 并且页面含有 viewport meta tag，那么
                // 被这个 tag 声明的宽度将会被使用，如果页面没有这个 tag 或者没有提供一个宽度，那么一个宽型 viewport 将会被使用。
                Control.Settings.UseWideViewPort = true;




                // 3.WebChromeClient
                var webChromeClient = new TorchWebChromeClient();
                Control.SetWebChromeClient(webChromeClient);


                // 改为加载网络资源, 而不是本地
                //Control.LoadUrl($"file:///android_asset/Content/{((HybridWebView)Element).Uri}");
                Control.LoadUrl($"{((HybridWebView)Element).Uri}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((HybridWebView)Element).Cleanup();
            }
            base.Dispose(disposing);
        }
    }
}