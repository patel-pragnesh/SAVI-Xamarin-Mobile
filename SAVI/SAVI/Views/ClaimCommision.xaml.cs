using Demo.Pages;
using Plugin.Toast;
using Rg.Plugins.Popup.Services;
using SAVI.com.celcom.savi;
using SAVI.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAVI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClaimCommision : ContentPage
    {
        private ClaimCommisionViewModel MyViewModel
        {
            get { return (ClaimCommisionViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            MyViewModel = new ClaimCommisionViewModel();
            BindingContext = MyViewModel;


            string balance = App.SoapService.GetBalance(SAVIApplication.mRegistrationID.ToString());
            SAVIApplication.Balance = Double.Parse(balance);

            CommisssionBalanceLabel.Text = "R" + balance;

            //spinPayementType.SelectedIndex = 0;
        }
       
        public ClaimCommision()
        {
            InitializeComponent();
            //   NavigationPage.SetHasNavigationBar(this, false);
          

        }

        private async void btnNext_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(edtMSISDN1.Text))
                {
                CrossToastPopUp.Current.ShowToastMessage("Please enter a valid MSISDN number");
                edtMSISDN1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(edtMSISDN2.Text))
            {
                CrossToastPopUp.Current.ShowToastMessage("Please enter a valid MSISDN number");
                edtMSISDN2.Focus();
                return;
            }
            if ((edtMSISDN1.Text.Trim().Length < 10) || (edtMSISDN1.Text.Trim().Length > 11))
            {
                CrossToastPopUp.Current.ShowToastMessage("Please enter a valid MSISDN number");
                edtMSISDN1.Focus();
                return;
            }
            if ((edtMSISDN2.Text.Trim().Length < 10) || (edtMSISDN2.Text.Trim().Length > 11))
            {
                CrossToastPopUp.Current.ShowToastMessage("Please enter a valid MSISDN number");
                edtMSISDN2.Focus();
                return;
            }
            if (edtMSISDN2.Text != edtMSISDN2.Text)
            {
                CrossToastPopUp.Current.ShowToastMessage("The cell pbone number is not matched!");
                return;
            }
            if (MyViewModel.SelectedPtype == null)
            {
                CrossToastPopUp.Current.ShowToastMessage("Please select a payment type!");
                spinPayementType.Focus();
                return;
            }
            SAVIApplication.PaymentTypeID = MyViewModel.SelectedPtype.ID;
            SAVIApplication.MSISDN = edtMSISDN1.Text;
            if (MyViewModel.SelectedPtype.Value == "Airtime")
            {
                await Navigation.PushAsync(new Airtime());
               
            }

            if (MyViewModel.SelectedPtype.Value == "Electricity")
            {
                await Navigation.PushAsync(new Electricity());
               
            }

            if (MyViewModel.SelectedPtype.Value == "Pay to Bank")
            {
                await Navigation.PushAsync(new Pay2Bank());
              
            }


        }

        private void btnHistory_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edtMSISDN1.Text))
            {
                CrossToastPopUp.Current.ShowToastMessage("Please enter a valid MSISDN number");
                edtMSISDN1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(edtMSISDN2.Text))
            {
                CrossToastPopUp.Current.ShowToastMessage("Please enter a valid MSISDN number");
                edtMSISDN2.Focus();
                return;
            }
            if ((edtMSISDN1.Text.Trim().Length < 10) || (edtMSISDN1.Text.Trim().Length > 11))
            {
                CrossToastPopUp.Current.ShowToastMessage("Please enter a valid MSISDN number");
                edtMSISDN1.Focus();
                return;
            }
            if ((edtMSISDN2.Text.Trim().Length < 10) || (edtMSISDN2.Text.Trim().Length > 11))
            {
                CrossToastPopUp.Current.ShowToastMessage("Please enter a valid MSISDN number");
                edtMSISDN2.Focus();
                return;
            }
            if (edtMSISDN2.Text != edtMSISDN2.Text)
            {
                CrossToastPopUp.Current.ShowToastMessage("The cell pbone number is not matched!");
                return;
            }
            var Inbox = new Inbox();
            PopupNavigation.Instance.PushAsync(Inbox);


        }
    }
}