using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Common;
using Android.OS;
using Android.Runtime;
using Plugin.Media;
using SAVI.com.celcom.savi;
using System;
using System.Threading.Tasks;

namespace SAVI.Droid
{
    [Activity(Label = "Celcom Reward", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            // ToolbarResource = Resource.Layout.Toolbar;
            Current = this;
            base.OnCreate(savedInstanceState);

            SAVIApplication.googleApiAvailable= isGmsAvailable(ApplicationContext);

            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            await CrossMedia.Current.Initialize();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            Rg.Plugins.Popup.Popup.Init(this,savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
          



            LoadApplication(new App());
        }


        //public static bool isHmsAvailable(Context context)
        //{
        //    bool isAvailable = false;
        //    if (null != context)
        //    {
        //        int result = HuaweiApiAvailability.getInstance().isHuaweiMobileServicesAvailable(context);
        //        isAvailable = (Com.Huawei.Hms.Api.ConnectionResult.SUCCESS == result);
        //    }
        //   // Log.i(TAG, "isHmsAvailable: " + isAvailable);
        //    return isAvailable;
        //}

        public static bool isGmsAvailable(Context context)
        {
            bool isAvailable = false;
            if (null != context)
            {
                int result = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(context);
                isAvailable = (ConnectionResult.Success == result);
            }
            //Log.i(TAG, "isGmsAvailable: " + isAvailable);
            return isAvailable;
        }

        // Field, properties, and method for Video Picker
        public static MainActivity Current { private set; get; }
        public static readonly int PickImageId = 1000;
        public TaskCompletionSource<string> PickImageTaskCompletionSource { set; get; }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

          
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (data != null))
                {
                    // Set the filename as the completion of the Task
                    PickImageTaskCompletionSource.SetResult(data.DataString);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }
        }

        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                Console.WriteLine("Android back button: There are some pages in the PopupStack");
            }
            else
            {
                Console.WriteLine("Android back button: There are not any pages in the PopupStack");
                // System.Diagnostics.Process.GetCurrentProcess().Kill();
                //App.Current.MainPage.Navigation.PopAsync();
            }
           
        }

    }
}