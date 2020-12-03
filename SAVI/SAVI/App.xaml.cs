using SAVI.Utils;
using SAVI.Views;
using Xamarin.Forms;

namespace SAVI
{
    public partial class App : Application
    {
         public App()
        {
       
            InitializeComponent();
            // Configure the barcode picker through a scan settings instance by defining which
            // symbologies should be enabled.
        }
      

        protected override   void OnStart()
        {
          //  await FileAccess.CopyVideoIfNotExists("howitworks.mp4");

            //MainPage = new NavigationPage(new activity_selection());

            Device.SetFlags(new string[] { "RadioButton_Experimental" });
            var MyAppsFirstPage = new activity_selection();
            Application.Current.MainPage = new NavigationPage(MyAppsFirstPage);
            //Application.Current.MainPage.Navigation.PushAsync(new activity_selection());
            //Application.Current.MainPage.Navigation.PopAsync(); //Remove the page currently on top.
            //MainPage = new activity_selection();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private static WebServiceUtil _SoapService;
        public static WebServiceUtil SoapService
        {
            get
            {
                if (_SoapService == null)
                {
                    _SoapService = new WebServiceUtil();

                }

                return _SoapService;
            }
        }
        //private static SARPWsSoapClient _SoapService;
        //public static SARPWsSoapClient SoapService
        //{
        //    get
        //    {
        //        if (_SoapService == null)
        //        {
        //            _SoapService = DependencyService.Get<SARPWsSoapClient>();


        //            _SoapService = new SARPWsSoapClient(
        //                 new SARPWsSoapClient.EndpointConfiguration()
        //        );


        //        }

        //        return _SoapService;
        //    }
        //}

    }
}
