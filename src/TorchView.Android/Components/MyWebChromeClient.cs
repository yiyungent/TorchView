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
    public class MyWebChromeClient : Android.Webkit.WebChromeClient
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

    }
}