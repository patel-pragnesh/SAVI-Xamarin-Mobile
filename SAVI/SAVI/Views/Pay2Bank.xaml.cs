using Demo.Pages;
using Plugin.Toast;
using Rg.Plugins.Popup.Services;
using SAVI.com.celcom.savi;
using SAVI.com.celcom.savi.common;
using SAVI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SAVI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pay2Bank : ContentPage
    {
        private string name = string.Empty;
        private string cellnumber = string.Empty;

        private string year = string.Empty;
        private string month = string.Empty;

        private string accountNumber = string.Empty;
        private string bankName = string.Empty;


        private IdValue parms= new IdValue();
        public Pay2Bank()
        {
            InitializeComponent();
            try
            {

                if (SAVIApplication.mParams == "SAVI") name = Preferences.Get(Globals.NAME_S, "");
                if (SAVIApplication.mParams == "MOBILITY") name = Preferences.Get(Globals.NAME_M, "");
                if (SAVIApplication.mParams == "CATERPILAR") name = Preferences.Get(Globals.NAME_C, "");

                var reg = App.SoapService.GetRegistration(name).GetRegistrationResult;

                if (reg != null)
                {
                    if (reg.RegistrationID != null)
                    {
                        if (int.Parse(reg.RegistrationID) > 0) cellnumber = reg.ContactNumber;

                    }


                     parms = App.SoapService.GeteWalletParms().GeteWalletParmsResult;

                    if (parms != null)
                    {
                        textMinimum.Text = "Min payment Amonut: R" + parms.ID;
                        year = DateTime.Now.Year.ToString();
                        month = DateTime.Now.Month.ToString();

                        if (month.Length == 1) month = "0" + month;

                        int resultBalance = App.SoapService.GeteWalletBalance(SAVIApplication.mRegistrationID.ToString(), year, month);
                        textBalance.Text = "EFT Balance Payments Remaining For Current Month: R" + (Double.Parse(parms.ID1) - SAVIApplication.Balance).ToString();

                    }

                    var result = App.SoapService.GetBankingDetails(SAVIApplication.mRegistrationID.ToString());

                    if (result != null)
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
                       
                        if (Double.Parse(editAmount.Text.Trim()) > SAVIApplication.Balance)
                        {
                            CrossToastPopUp.Current.ShowToastMessage("You do not have enough funds to continue this transaction!");
                            App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Pay2Bank", "You do not have enough funds to continue this transaction!");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //CrossToastPopUp.Current.ShowToastMessage("Somthing wrong! please try again");
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Pay2Bank", DateTime.Now.ToString()+"|"+ex.Message);
                //this.Navigation.PopAsync();
            }

        }

        private async void buttonPay_Clicked(object sender, EventArgs e)
        {
            try
            {
               
                if (editAmount.Text != null)
                {
                    if (editAmount.Text.Trim().Length < 1)
                    {
                        CrossToastPopUp.Current.ShowToastMessage("Please enter an Amount");
                        editAmount.Focus();
                        return;
                    }
                    if (Double.Parse(editAmount.Text.Trim())< Double.Parse(parms.ID))
                    {
                        CrossToastPopUp.Current.ShowToastMessage("Min Payment Amount: R" + parms.ID);
                        return;
                    }

                    year = DateTime.Now.Year.ToString();
                    month = (DateTime.Now.Month + 1).ToString();
                    if (month.Length == 1) month = "0" + month;

                    DateTime.Now.ToString("yyyy-MM-dd  HH:mm");


                    string detail = "Pay to Bank|" + DateTime.Now.ToString("yyyy-MM-dd  HH:mm") + "|" + bankName + "|" + editAmount.Text.Trim();

                    var boolResult = App.SoapService.EFTPay(SAVIApplication.mRegistrationID.ToString(), SAVIApplication.PaymentTypeID, editAmount.Text.Trim(), cellnumber, detail);

                    if (boolResult)
                    {
//                        CrossToastPopUp.Current.ShowToastMessage("You have successfully requested a Pay2Bank transaction. This will take 2-3 business days.");
  //                      await Navigation.PushAsync(new ClaimCommision());

                        var pageMessage = new ShowMessagePopupPage("You have successfully requested a Pay2Bank transaction. This will take 2-3 business days.");
                        await PopupNavigation.Instance.PushAsync(pageMessage);

                        await Navigation.PopAsync();
                        return;

                    }
                    else
                    {
                        //await Navigation.PushAsync(new ClaimCommision());
                        // CrossToastPopUp.Current.ShowToastMessage("Not Successful payment!");
                        var pageMessage = new ShowMessagePopupPage("Not Successful payment!");
                        await PopupNavigation.Instance.PushAsync(pageMessage);

                        App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Pay2Bank", "PaymentId = " + SAVIApplication.PaymentTypeID + "Amount = " + editAmount.Text.Trim() + "cellnumber = " + cellnumber + " Somthing wrong for paying!");


                        return;


                        //var currentPage = Navigation.NavigationStack[Navigation.NavigationStack.IndexOf(this)];
                        //Navigation.RemovePage(currentPage);
                    }



                }
            }
            catch (Exception ex)
            {
              //  CrossToastPopUp.Current.ShowToastMessage("Somthing Wrong! Please try again.");
                var pageMessage = new ShowMessagePopupPage("Somthing Wrong! Please try again.");
                await PopupNavigation.Instance.PushAsync(pageMessage);
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Pay2Bank", DateTime.Now.ToString() + "|" + ex.Message);
                return;
            }
            
        }
    }
}