using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TorchView.Components;
using TorchView4Droid.Components;

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

                // WebViewClient
                var webViewClient = new JavascriptWebViewClient(this, $"javascript: {JavascriptFunction}");
                Control.SetWebViewClient(webViewClient);
                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");


                // WebSettings
                // 设置渲染优先级
                Control.Settings.SetRenderPriority(Android.Webkit.WebSettings.RenderPriority.High);
                //Control.Settings.CacheMode = Android.Webkit.CacheModes.NoCache;
                // 如果内容已经存在cache 则使用cache，即使是过去的历史记录。如果cache中不存在，从网络中获取
                //Control.Settings.CacheMode = Android.Webkit.CacheModes.CacheElseNetwork;


                // WebChromeClient
                var webChromeClient = new MyWebChromeClient();
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