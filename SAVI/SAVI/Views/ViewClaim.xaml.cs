using Demo.Pages;
using Rg.Plugins.Popup.Services;
using SAVI.ViewModel;
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
    public partial class ViewClaim : ContentPage
    {
        DateTime dteFrom; DateTime dteTo;
        private ViewClaimList MyViewModel
        {
            get { return (ViewClaimList)BindingContext; }
            set { BindingContext = value; }
        }
        public ViewClaim(DateTime dteFroM, DateTime dteTO)
        {
            InitializeComponent();
            dteFrom = dteFroM;

            dteTo = dteTO;


            MyViewModel = new ViewClaimList(dteFrom, dteTo);


            MyViewModel.LoadClaimsHistory.Execute(null);
          
        }

        async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            Label L = (Label)sender;
            Grid G = (Grid)L.Parent;
            Label InvoiceNumber = (Label)G.Children[0];

            Label StoreID = (Label)G.Children[1];

            var inv = InvoiceNumber.Text;
            var strid = StoreID.Text;
            if (string.IsNullOrWhiteSpace(InvoiceNumber.Text) || string.IsNullOrWhiteSpace(StoreID.Text)) return;
            string strImage = App.SoapService.GetInvoiceImage(inv, strid).GetInvoiceImageResult;

            var pageMessage = new ImageOfClaim(strImage);
            await PopupNavigation.Instance.PushAsync(pageMessage);
        }

        }
}