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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string result = await this.hybridWebView.EvaluateJavaScriptAsync("document.getElementById('name').value");

            await DisplayAlert("Alert", "Get name value: " + result, "OK");
        }
    }
}
