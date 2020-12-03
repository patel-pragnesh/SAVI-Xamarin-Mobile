using Demo.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class PickDates : ContentPage
    {
        public PickDates()
        {
            InitializeComponent();
       //     NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //ActIndicator.IsEnabled = false;
            //ActIndicator.IsVisible = false;
            //ActIndicator.IsRunning = false;


        }

        private async void btnSelect_Clicked(object sender, EventArgs e)
        {
            //     var pageLoading = new LoadingPopupPage();
            //   await PopupNavigation.Instance.PushAsync(pageLoading);
            ActIndicator.IsEnabled = true;
            ActIndicator.IsVisible = true;
            ActIndicator.IsRunning = true;
           
            await Navigation.PushAsync(new ViewClaim(DateFromPicker.Date,DateToPicker.Date));
            ActIndicator.IsEnabled = false;
            ActIndicator.IsVisible = false;
            ActIndicator.IsRunning = false;

        }
    }
}