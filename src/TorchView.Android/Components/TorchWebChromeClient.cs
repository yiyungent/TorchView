using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorchView4Droid.Components
{
    /// <summary>
    /// WebChromeClient 主要辅助 WebView 处理 JavaScript 的对话框、网站 Logo、网站 title、load 进度等处理
    /// </summary>
    public class TorchWebChromeClient : Android.Webkit.WebChromeClient
    {

        public override void OnProgressChanged(WebView view, int newProgress)
        {
            // TODO: WebView 顶部进度条
            // https://blog.csdn.net/wuqingsen1/article/details/82622010
            //显示进度条
            //progressBar.setProgress(newProgress);
            //if (newProgress == 100)
            //{
            //    //加载完毕隐藏进度条
            //    progressBar.setVisibility(View.GONE);
            //}


            base.OnProgressChanged(view, newProgress);
        }

        #region js 三对话框

        public override bool OnJsAlert(WebView view, string url, string message, JsResult result)
        {
            return base.OnJsAlert(view, url, message, result);
        }

        public override bool OnJsConfirm(WebView view, string url, string message, JsResult result)
        {
            return base.OnJsConfirm(view, url, message, result);
        }

        public override bool OnJsPrompt(WebView view, string url, string message, string defaultValue, JsPromptResult result)
        {
            // 注意: js 传过来的数据在 message
            // message = "js://openActivity?arg1=111&arg2=222"
            Android.Net.Uri uri = Android.Net.Uri.Parse(message);
            string scheme = uri.Scheme;
            if (scheme != null && scheme.ToLower() == "js")
            {
                IList<string> queryPars = uri.QueryParameterNames?.ToList();
                // TODO: 调用C#方法

                // 代表应用内部处理完成
                result.Confirm("success");

                return true;
            }

            return base.OnJsPrompt(view, url, message, defaultValue, result);
        }

        #endregion



    }
}