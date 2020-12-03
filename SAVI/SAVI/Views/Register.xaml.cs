using Demo.Pages;
using Plugin.Toast;
using Rg.Plugins.Popup.Services;
using SAVI.com.celcom.savi;
using SAVI.com.celcom.savi.common;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAVI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {

        private string Brand = "Unassigned";
        private string BrandID = "1";


        public Register()
        {
            InitializeComponent();
          //  NavigationPage.SetHasNavigationBar(this, false);
           
         
        }

        private void BankPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MyViewModel.SelectedBank.ID;
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {

                if (editTextCelcomAccountNumber.Text.Length < 2)
                {
                    var pageMessage = new ShowMessagePopupPage("Please enter your Account number");
                    PopupNavigation.Instance.PushAsync(pageMessage);
                    editTextCelcomAccountNumber.Focus();
                    return;
                }
                if (editTextTradingName.Text.Length < 2)
                {
                    var pageMessage = new ShowMessagePopupPage("Please enter a Company Trading Name");
                    PopupNavigation.Instance.PushAsync(pageMessage);
                    editTextTradingName.Focus();
                    return;
                }
                if (editTextFirstName.Text.Length < 2)
                {
                    var pageMessage = new ShowMessagePopupPage("Please enter your Name");
                    PopupNavigation.Instance.PushAsync(pageMessage);
                    editTextFirstName.Focus();
                    return;
                }
                if (editTextSurname.Text.Length < 2)
                {
                    var pageMessage = new ShowMessagePopupPage("Please enter your Surname");
                    PopupNavigation.Instance.PushAsync(pageMessage);
                    editTextSurname.Focus();
                    return;
                }
                if (editTextCellNumber.Text.Length < 2)
                {
                    var pageMessage = new ShowMessagePopupPage("Please enter your Cell Number for 10 digits.");
                    PopupNavigation.Instance.PushAsync(pageMessage);
                    editTextCellNumber.Focus();
                    return;
                }
                if (editTextCellNumber.Text.Length != 10)
                {
                    var pageMessage = new ShowMessagePopupPage("Please enter your VALID Cell Number for 10 digits.");
                    PopupNavigation.Instance.PushAsync(pageMessage);
                    editTextCellNumber.Focus();
                    return;
                }
                if (editTextEmail.Text.Length < 2)
                {
                    var pageMessage = new ShowMessagePopupPage("Please enter your Email address");
                    PopupNavigation.Instance.PushAsync(pageMessage);
                    editTextEmail.Focus();
                    return;
                }
                if (!RegexUtilities.IsValidEmail(editTextEmail.Text))
                {
                    var pageMessage = new ShowMessagePopupPage("Please enter your Email address");
                    PopupNavigation.Instance.PushAsync(pageMessage);
                    editTextEmail.Focus();
                    return;
                }

                if (TilePicker.SelectedItem == null)
                {

                    TilePicker.Focus();
                    return;
                }

                string companyID = App.SoapService.ValidateCompany(editTextCelcomAccountNumber.Text.Trim().ToUpper());


                if (Convert.ToInt32(companyID) < 1)
                {
                    var pageMessage = new ShowMessagePopupPage("The account number does not exist!");
                    PopupNavigation.Instance.PushAsync(pageMessage);
                    return;
                }

                SAVIApplication.mCompany = editTextCelcomAccountNumber.Text;
                SAVIApplication.mCompanyID = Convert.ToInt32(companyID);

                Preferences.Set(Globals.COMPANY_ID, SAVIApplication.mCompanyID);





                int RegisteredUpdateRegistrationV5 = App.SoapService.RegisterV2(editTextTradingName.Text, editTextFirstName.Text, editTextSurname.Text, "ID", "", editTextCellNumber.Text, editTextEmail.Text, "1", editTextUsername.Text, editTextPassword.Text, TilePicker.SelectedItem.ToString(), editTextMiddleName.Text);
                if (RegisteredUpdateRegistrationV5 == -1)
                {
                    var pageMessage = new ShowMessagePopupPage("The Username already used. Please try another.");
                    PopupNavigation.Instance.PushAsync(pageMessage);

                }
                else if
                      (RegisteredUpdateRegistrationV5 == -2)
                {
                    var pageMessage = new ShowMessagePopupPage("The Username already used. Please try another.");
                    PopupNavigation.Instance.PushAsync(pageMessage);

                }
                else
                {
                    string name = string.Empty;
                    if (SAVIApplication.mParams == "SAVI") name = Preferences.Get(Globals.NAME_S, "");
                    if (SAVIApplication.mParams == "MOBILITY") name = Preferences.Get(Globals.NAME_M, "");
                    if (SAVIApplication.mParams == "CATERPILAR") name = Preferences.Get(Globals.NAME_C, "");

                    Globals.STORE = "Unassigned";
                    Preferences.Set(Globals.STORE, "Unassigned");

                    Globals.STORE_ID = "1";
                    Preferences.Set(Globals.STORE_ID, "1");

                    Globals.BRAND = "Unassigned";
                    Preferences.Set(Globals.BRAND, "Unassigned");

                    Globals.BRAND_ID = "1";
                    Preferences.Set(Globals.BRAND_ID, "1");

                    Globals.COMPANY = editTextCelcomAccountNumber.Text;
                    Preferences.Set(Globals.COMPANY, editTextCelcomAccountNumber.Text);

                    Globals.COMPANY_ID = companyID;
                    Preferences.Set(Globals.COMPANY_ID, companyID);

                    Globals.REP_NAME = editTextFirstName.Text + " " + editTextSurname.Text;
                    Preferences.Set(Globals.REP_NAME, editTextFirstName.Text + " " + editTextSurname.Text);

                    Globals.REP_MSISDN = editTextCellNumber.Text;
                    Preferences.Set(Globals.REP_MSISDN, editTextCellNumber.Text);

                    CrossToastPopUp.Current.ShowToastMessage("Registered!");
                    this.Navigation.PopAsync();

                }
            }
            catch (Exception ex)
            {
                CrossToastPopUp.Current.ShowToastMessage("Somthing Wrong! Please try again.");
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Registration", DateTime.Now.ToString() + "|" + ex.Message);
                this.Navigation.PopAsync();
            }


        }
    }
}