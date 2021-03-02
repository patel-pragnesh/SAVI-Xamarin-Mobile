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

        public Main()
        {
            InitializeComponent();
            //   NavigationPage.SetHaNavigationBar(this, false);

            string version = Preferences.Get(Globals.version, "");



            if (version != App.SoapService.GetMobileBannersCurrentVersion())
            {

                try
                {


                    DependencyService.Get<IMediaService>().DeleteImages();
                    var banners = App.SoapService.GetMobileBanners();

                    foreach (var b in banners)
                    {
                        var byteimage = Convert.FromBase64String(b.Image);

                        DependencyService.Get<IMediaService>().SaveImageFromByte(b.ID, byteimage);
                    }

                    if (banners.Count > 0)
                    {
                        listImage.Clear();
                        Preferences.Set(Globals.version, App.SoapService.GetMobileBannersCurrentVersion());
                        listImage.Clear();
                        listImage = DependencyService.Get<IMediaService>().GetImages();
                        TheCarousel.ItemsSource = listImage;

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
            }

            if (listImage.Count<=0)
            {
                listImage.Add("mobilityspivs.jpg");
                listImage.Add("mobilityspivs2.jpg");
                listImage.Add("mobilityspivs3.jpg");
                listImage.Add("mobilityspivs4.jpg");
                listImage.Add("mobilityspivs5.jpg");
                listImage.Add("mobilityspivs6.jpg");
                listImage.Add("mobilityspivs7.jpg");
                listImage.Add("mobilityspivs8.jpg");
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