using Demo.Pages;
using Rg.Plugins.Popup.Services;
using SAVI.com.celcom.savi;
using SAVI.com.celcom.savi.common;
using SAVI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAVI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Admin : ContentPage
    {
        private AdminViewModel MyViewModel
        {
            get { return (AdminViewModel)BindingContext; }
            set { BindingContext = value; }
        }


        private string nationality;

        public Admin()
        {
            InitializeComponent();
          //  NavigationPage.SetHasNavigationBar(this, false);
            MyViewModel = new AdminViewModel();
            BindingContext = MyViewModel;



          

            string name = string.Empty;
            if (SAVIApplication.mParams== "SAVI") name =Preferences.Get(Globals.NAME_S, "");
            if (SAVIApplication.mParams == "MOBILITY") name = Preferences.Get(Globals.NAME_M, "");
            if (SAVIApplication.mParams == "CATERPILAR") name = Preferences.Get(Globals.NAME_C, "");

            var reg = App.SoapService.GetRegistration(name).GetRegistrationResult;

            nationality = reg.Nationality;

            editTextCelcomAccountNumber.Text = reg.AccountNum;
            editTextTradingName.Text = reg.CompanyTradingName;
           
            TilePicker.SelectedItem = reg.Title;
            editTextFirstName.Text = reg.Name;
            editTextMiddleName.Text = reg.MiddleName;
            editTextSurname.Text = reg.Surname;
            editTextCellNumber.Text = reg.ContactNumber;
            editTextEmail.Text = reg.ContactEmail;
            editTextBrandName.Text = "";
            //editTextStoreName.Text = reg.st

         
            Preferences.Set(Globals.REP_NAME, editTextFirstName.Text + " " + editTextSurname.Text);
            Preferences.Set(Globals.REP_MSISDN, editTextCellNumber.Text);

          

           
          
            var x= App.SoapService.GetStoreAndBrand(SAVIApplication.mRegistrationID.ToString());
            
            Preferences.Set(Globals.STORE_ID, x.ID);
            Preferences.Set(Globals.STORE, x.Value);
            Preferences.Set(Globals.BRAND, x.Value1);
            Preferences.Set(Globals.BRAND_ID, x.ID1);


            var BrandIDString = Preferences.Get(Globals.BRAND_ID, "");
            int BrandID = 0;
            if (!string.IsNullOrEmpty(BrandIDString)) BrandID = Convert.ToInt32(BrandIDString);

            if ( BrandID > 0 )

            {
                var brands = App.SoapService.GetBrands().GetBrandsResult;
                for (int i=0; i<brands.Count();i++)
                {
                    if (!string.IsNullOrEmpty(brands[i].ID))
                    {
                        if (Convert.ToInt32(brands[i].ID) == BrandID) editTextBrandName.Text = brands[i].Value;
                    }
                }
            }


            var StoreIDString = Preferences.Get(Globals.STORE_ID, "");
            int StoreID = 0;
            if (!string.IsNullOrEmpty(BrandIDString)) StoreID = Convert.ToInt32(StoreIDString);

            if (StoreID > 0)

            {
                var Stores = App.SoapService.GetStores(BrandIDString).GetStoresResult;
                for (int i = 0; i < Stores.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(Stores[i].ID))
                    {
                        if (Convert.ToInt32(Stores[i].ID) == BrandID) editTextStoreName.Text = Stores[i].Value;
                    }
                }
            }





            //bank



            foreach (var l in MyViewModel.Banks) if (l.ID == reg.BankID) BankPicker.SelectedItem = l;

            //acountyype//

            MyViewModel.BankDetail = App.SoapService.GetBankingDetails(SAVIApplication.mRegistrationID.ToString());

            editTextAccountNumber.Text = MyViewModel.BankDetail.RecipientAccount;
            editTextBranchCode.Text = MyViewModel.BankDetail.BranchCode;
            if (MyViewModel.BankDetail.RecipientAccountType != null)
            {
                if (MyViewModel.BankDetail.RecipientAccountType.Contains("Cheque"))
                    AccountType.SelectedIndex = 0;
                else
                    AccountType.SelectedIndex = 1;
            }


            //editTextBrandName.Text = reg.br


        }

        private void BankPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MyViewModel.SelectedBank.ID;
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            if (editTextCelcomAccountNumber.Text.Length<2)
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
                var pageMessage = new ShowMessagePopupPage("Please enter your Cell Number");
                PopupNavigation.Instance.PushAsync(pageMessage);
                editTextCellNumber.Focus();
                return;
            }
            if (editTextCellNumber.Text.Length !=10)
            {
                var pageMessage = new ShowMessagePopupPage("Please enter your VALID Cell Number");
                PopupNavigation.Instance.PushAsync(pageMessage);
                editTextCellNumber.Focus();
                return;
            }
            if (editTextEmail.Text.Length <2)
            {
                var pageMessage = new ShowMessagePopupPage("Please enter your Email address");
                PopupNavigation.Instance.PushAsync(pageMessage);
                editTextEmail.Focus();
                return;
            }
            
            if (MyViewModel.SelectedBank.ID==null)
            {
              
                BankPicker.Focus();
                return;
            }
            if (AccountType.SelectedItem == null)
            {

                AccountType.Focus();
                return;
            }
            if (TilePicker.SelectedItem == null)
            {
              
                TilePicker.Focus();
                return;
            }
            if (editTextBranchCode.Text.Length < 1)
            {
                var pageMessage = new ShowMessagePopupPage("Please enter your Branch Code");
                PopupNavigation.Instance.PushAsync(pageMessage);
                editTextBranchCode.Focus();
                return;
            }
            if (editTextAccountNumber.Text.Length < 1)
            {
                var pageMessage = new ShowMessagePopupPage("Please enter your Account Number");
                PopupNavigation.Instance.PushAsync(pageMessage);
                editTextAccountNumber.Focus();
                return;
            }
            string companyID = App.SoapService.ValidateCompany(editTextCelcomAccountNumber.Text);
            SAVIApplication.mCompany = editTextCelcomAccountNumber.Text;
            SAVIApplication.mCompanyID = Convert.ToInt32(companyID);
           
            Preferences.Set(Globals.COMPANY_ID, SAVIApplication.mCompanyID);

            string accountType = string.Empty;
            if (AccountType.SelectedIndex == 0) accountType = "Cheque";
            if (AccountType.SelectedIndex == 1) accountType = "Savings";


            string RegisteredBankingdetailStatus = App.SoapService.UpdateBankingDetails(SAVIApplication.mRegistrationID.ToString(), MyViewModel.SelectedBank.ID, "0", "true", editTextAccountNumber.Text, AccountType.SelectedIndex.ToString(), editTextBranchCode.Text);

            if (RegisteredBankingdetailStatus.ToUpper().Trim() != "TRUE")
            {
                var pageMessage = new ShowMessagePopupPage("Something went wrong at add/update bank detail!");
                PopupNavigation.Instance.PushAsync(pageMessage);
                return;
            }


         

            bool RegisteredUpdateRegistrationV5 = App.SoapService.UpdateRegistrationV5(SAVIApplication.mRegistrationID.ToString(), editTextTradingName.Text, editTextFirstName.Text, editTextSurname.Text, "ID", "", editTextCellNumber.Text, editTextEmail.Text, Preferences.Get(Globals.STORE_ID, ""), SAVIApplication.mCompanyID.ToString(), MyViewModel.SelectedBank.ID, TilePicker.SelectedItem.ToString(), editTextMiddleName.Text, nationality);
            if (!RegisteredUpdateRegistrationV5)
            {
                var pageMessage = new ShowMessagePopupPage("Something went wrong at add/update registration!");
                PopupNavigation.Instance.PushAsync(pageMessage);
                return;
            }
            else
            {
                var pageMessage = new ShowMessagePopupPage("Saved successfully!");
                PopupNavigation.Instance.PushAsync(pageMessage);
                Navigation.PopAsync();
            }


        }
    }
}