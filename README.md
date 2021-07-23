<p align="center">
<img src="docs/.vuepress/public/images/logo.png" alt="TorchView">
</p>
<h1 align="center">TorchView</h1>

> Hybrid App for Xamarin, Xamarin combined with Vue.js and more.

[![repo size](https://img.shields.io/github/repo-size/yiyungent/TorchView.svg?style=flat)]()
[![LICENSE](https://img.shields.io/github/license/yiyungent/TorchView.svg?style=flat)](https://github.com/yiyungent/TorchView/blob/main/LICENSE)



## Introduction

Hybrid App for Xamarin, Xamarin combined with Vue.js and more.

- **Simple** - enjoy 5 minutes installation, easy to get started.
- **Interactive** - Use JavaScript to call C#, use C# to call JavaScript

## Demo

- TODO

## Screenshots

- TODO



## Quick Start

> 1.Install TorchView in your Xamarin.Forms

```bash
PM> Install-Package TorchView
```



> 2.Install TorchView.Android in your Xamarin.Android

```bash
PM> Install-Package TorchView.Android
```



> __Note__
>
> If the installation is not successful through nuget, please try to download in `Releases` and manually add a reference to the dll.



> 3.Find `Xamarin.Forms` and add the following code in `App.xaml.cs`, which will start a WebServer locally to process http requests from the local.

```C#
public partial class App : Application 
{
    private IWebServer _webServer;

    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();

        //var webFile = DependencyService.Get<IWebFile>();

        // Listen on port 12531 by default
        this._webServer = WebServerExtensions.Get();
    }

    protected override void OnStart()
    {
        this._webServer.Start();
    }
}
```



> 4.Find `Xamarin.Android`, add your web file to `Assets/wwwroot` (wwwroot needs to be created)

![image-20210723093820791](screenshots/image-20210723093820791.png)



> 5.Find `Xamarin.Forms`, add `HybridWebView` to the page you need,

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="Demo.MainPage"
             xmlns:com="clr-namespace:TorchView.Components;assembly=TorchView">

    <StackLayout HorizontalOptions="Center" VerticalOptions="Center">
        <Label HorizontalOptions="Center" VerticalOptions="Center" Text="Welcome to TorchView !" FontSize="16" BackgroundColor="LightBlue"></Label>

        <com:HybridWebView x:Name="hybridWebView" Uri="http://localhost:12531/index.html" WidthRequest="1000" HeightRequest="1000"></com:HybridWebView>
    </StackLayout>

</ContentPage>
```

> 6.Finished, now you can start your app



> __Note__
>
> In fact, you can use `this.hybridWebView` in `MainPage.xaml.cs` to complete more operations





## Support

| TorchView | TorchView.Android |      |
| --------- | ----------------- | ---- |
|           | Android 5.0 (+)   |      |
|           |                   |      |
|           |                   |      |



> __Note__
>
> Currently does not support iOS.



| TorchView         | [![nuget](https://img.shields.io/nuget/v/TorchView.svg?style=flat)](https://www.nuget.org/packages/TorchView/) | [![downloads](https://img.shields.io/nuget/dt/TorchView.svg?style=flat)](https://www.nuget.org/packages/TorchView/) |
| ----------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| TorchView.Android | [![nuget](https://img.shields.io/nuget/v/TorchView.Android.svg?style=flat)](https://www.nuget.org/packages/TorchView.Android/) | [![downloads](https://img.shields.io/nuget/dt/TorchView.Android.svg?style=flat)](https://www.nuget.org/packages/TorchView.Android/) |



## Environment

- Development environment: Visual Studio Community 2019,  Xamarin Development Kit







## Related projects

- [yiyungent/OneTree.App](https://github.com/yiyungent/OneTree.App)



## Thanks






## Donate

TorchView is an Apache-2.0 licensed open source project and completely free to use. However, the amount of effort needed to maintain and develop new features for the project is not sustainable without proper financial backing.

We accept donations through these channels:

- <a href="https://afdian.net/@yiyun" target="_blank">爱发电</a>

## Author

**TorchView** © [yiyun](https://github.com/yiyungent), Released under the [Apache-2.0](./LICENSE) License.<br>
Authored and maintained by yiyun with help from contributors ([list](https://github.com/yiyungent/TorchView/contributors)).

> GitHub [@yiyungent](https://github.com/yiyungent)
