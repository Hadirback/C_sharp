using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Slotlogic.MobileApp.Droid.Renderers;

namespace Slotlogic.MobileApp.Droid
{
    [Activity(Label = "Slotlogic.MobileApp", 
        Icon = "@drawable/icon", 
        Theme = "@style/MainTheme",
        MainLauncher = false, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            PullToRefreshLayoutRenderer.Init();
            LoadApplication(new App());
        }
    }
}