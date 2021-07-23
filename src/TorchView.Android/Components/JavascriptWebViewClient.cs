using System;
using Android.Content.Res;
using Android.Webkit;
using TorchView;
using Xamarin.Forms.Platform.Android;

namespace TorchView4Droid.Components
{
    /// <summary>
    /// WebViewClient 主要辅助WebView执行处理各种响应请求事件的
    /// </summary>
    public class JavascriptWebViewClient : FormsWebViewClient
    {
        string _javascript;

        public JavascriptWebViewClient(HybridWebViewRenderer renderer, string javascript) : base(renderer)
        {
            _javascript = javascript;
        }

        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            view.EvaluateJavascript(_javascript, null);
        }

        #region 拦截请求
        public override WebResourceResponse ShouldInterceptRequest(WebView view, IWebResourceRequest request)
        {
            #region 从 WebRoot 中读取
            // URL: <scheme>://<host>:<port>/<path>?<query>
            // Url.Host 比较忽略大小写
            if (request.Url != null && request.Url.Path != null && request.Url.Host.ToLower() == TorchConfig.UrlHost.ToLower())
            {
                string urlPath = request.Url.Path;
                string mimeType = TorchView.Utils.HttpUtil.GetContentType(request.Url.Path);
                // TODO: 很奇怪，为什么这里写 application/octet-stream
                string fileEncoding = "application/octet-stream";
                if (urlPath.EndsWith("html") || urlPath.EndsWith("js") || urlPath.EndsWith("css"))
                {
                    // TODO: 写死了 Encoding， 可以 StreamReader 读出编码
                    fileEncoding = "UTF-8";
                }
                try
                {
                    // TODO: 强依赖
                    IWebFile webFile = new AndroidWebFile();
                    System.IO.Stream stream = webFile.ReadFileToStream(urlPath);

                    return new WebResourceResponse(mimeType, fileEncoding, stream);
                }
                catch (Exception ex)
                {
                    // ignore
                    throw ex;
                }
            }
            #endregion

            return base.ShouldInterceptRequest(view, request);
        }
        #endregion


        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            return base.ShouldOverrideUrlLoading(view, request);
        }


    }
}