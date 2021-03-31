using SAVI;
using SAVI.com.celcom.savi.common;
using SAVI.CustomControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAVI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
       List<string> listImage  = new List<string>();
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "saviconfig.txt");
        int CarouselCurrentPosition = 0;
        //private string imageBase64;
        //public string ImageBase64
        //{
        //    get { return imageBase64; }
        //    set
        //    {
        //        imageBase64 = value;
        //        OnPropertyChanged("ImageBase64");
        //        OnPropertyChanged("Image");
        //    }
        //}

        //private Xamarin.Forms.ImageSource image;
        //public Xamarin.Forms.ImageSource Image
        //{
        //    get
        //    {
        //        if (image == null)
        //        {
        //            image = Xamarin.Forms.ImageSource.FromStream(
        //                () => new MemoryStream(Convert.FromBase64String(ImageBase64)));
        //        }
        //        return image;
        //    }
        //}
        private void deleteconfigfile()
        {
          //string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "saviconfig.txt");
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try {
                if (Globals.BannerURLList[CarouselCurrentPosition] != null)
                {
                    Uri uri = new Uri(Globals.BannerURLList[CarouselCurrentPosition]);
                    await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
                }
            }
            catch
            {

            }
            
        }
        void OnPositionChanged(object sender, PositionChangedEventArgs e)
        {
            CarouselCurrentPosition= e.CurrentPosition;
         /*   int previousItemPosition = e.PreviousPosition;
            int currentItemPosition = e.CurrentPosition;*/
        }
        public Main()
        {
            InitializeComponent();
            //   NavigationPage.SetHaNavigationBar(this, false);
            TheCarousel.PositionChanged += OnPositionChanged;
            string version = Preferences.Get(Globals.version, "");



            if (version != App.SoapService.GetMobileBannersCurrentVersion())
            {

                try
                {


                   
                    var banners = App.SoapService.GetMobileBanners();
                    if (banners.Count > 0)
                    {
                        deleteconfigfile();
                        DependencyService.Get<IMediaService>().DeleteImages();
                    }
                        int count = -1;
                    string saviconfig = "";
                    foreach (var b in banners)
                    {
                        count++;
                        var byteimage = Convert.FromBase64String(b.Image);
                        DependencyService.Get<IMediaService>().SaveImageFromByte(b.ID, byteimage);
                        if (b.URL != "")
                            Globals.BannerURLList[count] = b.URL;
                        else
                            Globals.BannerURLList[count] = "https://mobility.celcom.co.za/MobilityDefault.aspx";

                        if (count == 0)
                            saviconfig = Globals.BannerURLList[count];
                        if (count>0)
                            saviconfig = saviconfig+"\n" + Globals.BannerURLList[count];
                      
                    }

                    if (banners.Count > 0)
                    {
                       
                        listImage.Clear();
                        Preferences.Set(Globals.version, App.SoapService.GetMobileBannersCurrentVersion());
                        listImage.Clear();
                        listImage = DependencyService.Get<IMediaService>().GetImages();
                        TheCarousel.ItemsSource = listImage;

                         File.WriteAllText(_fileName, saviconfig);

                    }


                }
                catch 
                {
                    Preferences.Set(Globals.version, "");
                }
            }
            else

            {
               
                listImage.Clear();
                listImage = DependencyService.Get<IMediaService>().GetImages();
                TheCarousel.ItemsSource = listImage;
                if (File.Exists(_fileName))
                {
                    string[] saviconfig = File.ReadAllLines(_fileName);
                    int c = -1;
                    foreach(var s in saviconfig)
                    {
                        c++;
                        Globals.BannerURLList[c] = s;
                    }
                }
                else
                {
                 
                    for (int i=0; i<500;i++)
                    {
                       
                        Globals.BannerURLList[i] = "https://comms.everlytic.net/public/landing-pages/mobility---iphone-12-competition-aIeR4xc4Dwex941n";

                    }

                }
            }

            if (listImage.Count<=0)
            {
                deleteconfigfile();
                listImage.Add("mobilityspivs.jpg");
                listImage.Add("mobilityspivs2.jpg");
                listImage.Add("mobilityspivs3.jpg");
                listImage.Add("mobilityspivs4.jpg");
                listImage.Add("mobilityspivs5.jpg");
                listImage.Add("mobilityspivs6.jpg");
                listImage.Add("mobilityspivs7.jpg");
                listImage.Add("mobilityspivs8.jpg");
                Globals.BannerURLList[0] = "https://comms.everlytic.net/public/landing-pages/mobility---iphone-12-competition-aIeR4xc4Dwex941n";
                Globals.BannerURLList[1] = "https://comms.everlytic.net/public/landing-pages/mobility---iphone-12-competition-aIeR4xc4Dwex941n";
                Globals.BannerURLList[2] = "https://comms.everlytic.net/public/landing-pages/mobility---iphone-12-competition-aIeR4xc4Dwex941n";
                Globals.BannerURLList[3] = "https://comms.everlytic.net/public/landing-pages/mobility---iphone-12-competition-aIeR4xc4Dwex941n";
                Globals.BannerURLList[4] = "https://comms.everlytic.net/public/landing-pages/mobility---iphone-12-competition-aIeR4xc4Dwex941n";
                Globals.BannerURLList[5] = "https://comms.everlytic.net/public/landing-pages/mobility---iphone-12-competition-aIeR4xc4Dwex941n";
                Globals.BannerURLList[6] = "https://comms.everlytic.net/public/landing-pages/mobility---iphone-12-competition-aIeR4xc4Dwex941n";
                Globals.BannerURLList[7] = "https://comms.everlytic.net/public/landing-pages/mobility---iphone-12-competition-aIeR4xc4Dwex941n";
                TheCarousel.ItemsSource = listImage;
            }


            if (listImage.Count > 0)
            {
                Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
                {
                    TheCarousel.Position = (TheCarousel.Position + 1) % listImage.Count;
                    return true;
                }));
            }
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


      


            
            
        }


        private async void btbeginWithYourClaim_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new MobilityClaim();
            //await Navigation.PushAsync(new MobilityClaim());
            await Navigation.PushAsync(new CameraVisionPage());
        }

        private async void btUploadInvoie_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new UploadInvoice();
            //Application.Current.MainPage = new NavigationPage(new UploadInvoice());
            await Navigation.PushAsync(new UploadInvoice());
        }

        private async void btAdmin_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new Admin();
           // Application.Current.MainPage = new NavigationPage(new Admin());
            await Navigation.PushAsync(new Admin());
        }

        private async void btViewClaim_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new ViewClaim();
           // Application.Current.MainPage = new NavigationPage(new ViewClaim());
            await Navigation.PushAsync(new PickDates());
        }

        private async void btClaimCommision_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new ClaimCommision();
           // Application.Current.MainPage = new NavigationPage(new ClaimCommision());
            await Navigation.PushAsync(new ClaimCommision());
        }

        private async void btHowItWorks_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HowItWorks());
        }

       
    }
}