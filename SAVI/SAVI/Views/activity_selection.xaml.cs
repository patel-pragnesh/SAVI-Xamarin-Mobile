using SAVI.com.celcom.savi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAVI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class activity_selection : ContentPage
    {
        public activity_selection()
        {
            InitializeComponent();
            //Image image = new Image();
            //image.Source = "mobilitybackground.jpg";
            //image.Aspect = Aspect.Fill;

            

            //this.ba

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            SAVIApplication.mParams = "MOBILITY";
            
            //Application.Current.MainPage = new login();
            //Application.Current.MainPage = new NavigationPage(new login());
            await Navigation.PushAsync(new login());
            //DisplayAlert("Celcom", "mobility clicked!", "OK");
        }
    }
}