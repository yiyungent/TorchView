using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TorchView.Components
{
    public class HybridWebView : WebView
    {
        private Action<string> _action;

        private Func<string, string> _func;

        #region Uri
        public static readonly BindableProperty UriProperty = BindableProperty.Create(
            propertyName: "Uri",
            returnType: typeof(string),
            declaringType: typeof(HybridWebView),
            defaultValue: default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
        #endregion

        #region 供用户注册

        public void RegisterAction(Action<string> callback)
        {
            _action = callback;
        }

        public void RegisterFunc(Func<string, string> callback)
        {
            _func = callback;
        }

        #endregion

        /// <summary>
        /// 清除注册 的所有
        /// </summary>
        public void Cleanup()
        {
            _action = null;
            _func = null;
        }

        #region 供 JSBridge 调用 桥接

        public void InvokeAction(string data)
        {
            if (_action == null || data == null)
            {
                return;
            }
            _action.Invoke(data);
        }

        public string InvokeFunc(string data)
        {
            if (_func == null || data == null)
            {
                return null;
            }
            return _func.Invoke(data);
        }


        #endregion
    }
}
