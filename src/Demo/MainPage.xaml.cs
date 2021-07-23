using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.hybridWebView.RegisterAction(data => DisplayAlert("Alert", "RegisterAction " + data, "OK"));

            this.hybridWebView.RegisterFunc(data => { return "RegisterFunc " + data; });


        }
    }
}
