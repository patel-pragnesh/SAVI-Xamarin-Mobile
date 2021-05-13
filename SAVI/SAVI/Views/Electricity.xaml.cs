using Plugin.Toast;
using SAVI.com.celcom.savi;
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
    public partial class Electricity : ContentPage
    {
        private ElectricityViewModel MyViewModel
        {
            get { return (ElectricityViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        protected override void OnAppearing()
        {

          //  ElectricityPicker.SelectedIndex = 0;
        }


        public Electricity()
        {
            InitializeComponent();
            MyViewModel = new ElectricityViewModel();
            BindingContext = MyViewModel;
            var result = App.SoapService.GetBankingDetails(SAVIApplication.mRegistrationID.ToString());
            string accountNumber = string.Empty;
            string bankName = string.Empty;
            if (result!=null)
            {
                accountNumber = result.RecipientAccount;
                bankName = result.BankName;
            }
            if (string.IsNullOrWhiteSpace(accountNumber) || string.IsNullOrWhiteSpace(bankName))
            {
                CrossToastPopUp.Current.ShowToastMessage("No EFT setup ");
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Electricity", "No EFT setup ");
                return;
            }
            else
            {
                var _productLists = App.SoapService.GetProductList("3");
                for (int i = 0; i < _productLists.Count; ++i)
                {
                    MyViewModel.ProductLists.Add(_productLists[i]);
                }

            }

        }

        private void ElectricityPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void buttonNext_Clicked(object sender, EventArgs e)
        {
            if (editMeter.Text != null)
            {
                if (editMeter.Text.Trim().Length < 2)
                {
                    CrossToastPopUp.Current.ShowToastMessage("Please enter a Meter Number");
                    editMeter.Focus();
                    return;
                }
            }
            if (editAmount.Text != null)
            {
                if (editAmount.Text.Trim().Length < 2)
                {
                    CrossToastPopUp.Current.ShowToastMessage("Please enter an Amount");
                    editAmount.Focus();
                    return;
                }
            }

            if (MyViewModel.ProductLists==null)
            {
                CrossToastPopUp.Current.ShowToastMessage("Provider error! Please try again later.");
                return;
            }
            if (MyViewModel.SelectedProductList ==null)
            {
                CrossToastPopUp.Current.ShowToastMessage("Please select Municipality!");
                ElectricityPicker.Focus();
                return;
            }

            String transactionRef = "SAVIValidate_" + DateTime.Now.Millisecond.ToString();
            try
            {
                var resultTSS = App.SoapService.TSSProductPreVend(transactionRef, "Electricity", MyViewModel.SelectedProductList.ProductCode, editMeter.Text.Trim(), editAmount.Text.Trim());
                if (resultTSS.ResponseCode == "0")
                {
                    SAVIApplication.CCMETER = editMeter.Text.Trim();
                    SAVIApplication.CCMETERPROD = MyViewModel.SelectedProductList.ProductCode;
                    await Navigation.PushAsync(new Electricity2(resultTSS.ResponseMessage, MyViewModel.SelectedProductList.ProductCode, transactionRef, editMeter.Text.Trim(), editAmount.Text.Trim()));
                }
                else
                {
                    CrossToastPopUp.Current.ShowToastMessage(resultTSS.ResponseMessage);
                    App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Electricity", resultTSS.ResponseMessage);
                }

            }
            catch (Exception ex)
            {
                CrossToastPopUp.Current.ShowToastMessage("Invalid session! Please login.");
               // App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Electricity", "Invalid session! Please login.");
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Electricity", ex.Message);

            }

        }
    }
}