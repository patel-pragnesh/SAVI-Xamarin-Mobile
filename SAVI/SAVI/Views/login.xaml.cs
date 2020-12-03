using Demo.Pages;
using Rg.Plugins.Popup.Services;
using SAVI.com.celcom.savi;
using SAVI.com.celcom.savi.common;
using SAVI.Utils;
//using ServiceReferenceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SAVI.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        //SARPWsSoapClient ws = WebServiceUtil.GetVPSService();


      

        private ShowMessagePopupPage pageMessage;

        public login()
        {
            InitializeComponent();
            
            NavigationPage.SetHasNavigationBar(this, false);
            //editTextUser.Text = "benmtd";
            //editTextPassword.Text = "benmtdmob";
            if (SAVIApplication.mParams=="SAVI")
            {
                if (Preferences.Get(Globals.REMEMBER_S, false))
                {
                    editTextUser.Text = Preferences.Get(Globals.NAME_S, "");
                    editTextPassword.Text = Preferences.Get(Globals.PASSWORD_S, "");
                    checkRemember.IsChecked = true;

                }
            }
            if (SAVIApplication.mParams == "MOBILITY")
            {
                if (Preferences.Get(Globals.REMEMBER_M, false))
                {
                    editTextUser.Text = Preferences.Get(Globals.NAME_M, "");
                    editTextPassword.Text = Preferences.Get(Globals.PASSWORD_M, "");
                    checkRemember.IsChecked = true;
                }
            }
            if (SAVIApplication.mParams == "CATERPILAR")
            {
                if (Preferences.Get(Globals.REMEMBER_C, false))
                {
                    editTextUser.Text = Preferences.Get(Globals.NAME_C, "");
                    editTextPassword.Text = Preferences.Get(Globals.PASSWORD_C, "");
                    checkRemember.IsChecked = true;
                }
            }
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            
            if ( string.IsNullOrWhiteSpace(editTextUser.Text))
            {
                editTextUser.Text = "";
                editTextUser.Focus();
                return;
            }
            if (editTextUser.Text.ToString().Trim().Length < 2)
            {
                editTextUser.Text = "";
                editTextUser.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(editTextPassword.Text))
            {
                editTextPassword.Text = "";
                editTextPassword.Focus();
                return;
            }
            if (editTextPassword.Text.ToString().Trim().Length < 2)
            {
                editTextPassword.Text = "";
                editTextPassword.Focus();
                return;
            }

            var pageLoading = new LoadingPopupPage();
            await PopupNavigation.Instance.PushAsync(pageLoading);

            try
            {
                

                    try
                    {
                        SAVIApplication.mRegistrationID =long.Parse(App.SoapService.login(editTextUser.Text, editTextPassword.Text).LoginResult);
                    if (SAVIApplication.mRegistrationID > 0)
                    {
                        SAVIApplication.mStoreID = long.Parse(App.SoapService.GetStoreID(SAVIApplication.mRegistrationID.ToString()).GetStoreIDResult.ToString());

                        var GetStoreAndBrand = App.SoapService.GetStoreAndBrand(SAVIApplication.mStoreID.ToString());
                            Preferences.Set(Globals.STORE, GetStoreAndBrand.Value);
                            Preferences.Set(Globals.STORE_ID, GetStoreAndBrand.ID);
                            Preferences.Set(Globals.BRAND, GetStoreAndBrand.Type);
                            Preferences.Set(Globals.BRAND_ID, GetStoreAndBrand.ID1);

                            SAVIApplication.mCompanyID = long.Parse(App.SoapService.GetCompnyID(SAVIApplication.mRegistrationID.ToString()).GetCompnyIDResult);
                        if (SAVIApplication.mParams == "SAVI")
                        {

                            Preferences.Set(Globals.NAME_S, editTextUser.Text);
                            Preferences.Set(Globals.PASSWORD_S, editTextPassword.Text);

                            if (checkRemember.IsChecked)
                            {
                                Preferences.Set(Globals.REMEMBER_S, true);
                                checkRemember.IsChecked = true;
                            }
                            else
                            {
                                Preferences.Set(Globals.REMEMBER_S, false);
                                checkRemember.IsChecked = false;
                            }
                        }
                        if (SAVIApplication.mParams == "MOBILITY")
                        {

                            Preferences.Set(Globals.NAME_M, editTextUser.Text);
                            Preferences.Set(Globals.PASSWORD_M, editTextPassword.Text);


                            if (checkRemember.IsChecked)
                            {
                                Preferences.Set(Globals.REMEMBER_M, true);
                                checkRemember.IsChecked = true;
                            }
                            else
                            {
                                Preferences.Set(Globals.REMEMBER_M, false);
                                checkRemember.IsChecked = false;
                            }
                        }
                        if (SAVIApplication.mParams == "CATERPILAR")
                        {

                            Preferences.Set(Globals.NAME_C, editTextUser.Text);
                            Preferences.Set(Globals.PASSWORD_C, editTextPassword.Text);

                            if (checkRemember.IsChecked)
                            {
                                Preferences.Set(Globals.REMEMBER_C, true);
                                checkRemember.IsChecked = true;
                            }
                            else
                            {
                                Preferences.Set(Globals.REMEMBER_C, false);
                                checkRemember.IsChecked = false;
                            }
                        }
                            //Application.Current.MainPage = new Main();
                      //  Application.Current.MainPage = new NavigationPage(new Main());
                        await Navigation.PushAsync(new Main());

                    }
                    else
                    {
                        pageLoading.CloseMe();
                         pageMessage = new ShowMessagePopupPage("Unable to login with the details you have provided. Please register if you haven't. Please try again.");
                        await PopupNavigation.Instance.PushAsync(pageMessage);

                    }
                    }
                    catch (Exception ex)
                    {
                        pageLoading.CloseMe();
                        pageMessage = new ShowMessagePopupPage(ex.Message);
                        await PopupNavigation.Instance.PushAsync(pageMessage);
                    }
                

            }
            catch (FaultException ex)
            {
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Login", DateTime.Now.ToString() + "|" + ex.Message);
                pageMessage = new ShowMessagePopupPage("Error: "+ex.Message);
                await PopupNavigation.Instance.PushAsync(pageMessage);
             
            }
            catch (CommunicationException ex)
            {
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Login", DateTime.Now.ToString() + "|" + ex.Message);
                pageMessage = new ShowMessagePopupPage("Error: " + ex.Message);
                await PopupNavigation.Instance.PushAsync(pageMessage);
            
            }
            catch (TimeoutException ex)
            {
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Login", DateTime.Now.ToString() + "|" + ex.Message);
                pageMessage = new ShowMessagePopupPage("Error: " + ex.Message);
                await PopupNavigation.Instance.PushAsync(pageMessage);
              
            }
            catch (Exception ex)
            {
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Login", DateTime.Now.ToString() + "|" + ex.Message);
                pageMessage = new ShowMessagePopupPage("Error: " + ex.Message);
                await PopupNavigation.Instance.PushAsync(pageMessage);
             
            }
            finally { pageLoading.CloseMe(); }



        }



        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private void checkRemember_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (SAVIApplication.mParams == "SAVI")
            {

                Preferences.Set(Globals.NAME_S, editTextUser.Text);
                Preferences.Set(Globals.PASSWORD_S, editTextPassword.Text);

                if (checkRemember.IsChecked)
                {
                    Preferences.Set(Globals.REMEMBER_S, true);
                    checkRemember.IsChecked = true;
                }
                else
                {
                    Preferences.Set(Globals.REMEMBER_S, false);
                    checkRemember.IsChecked = false;
                }
            }
            if (SAVIApplication.mParams == "MOBILITY")
            {

                Preferences.Set(Globals.NAME_M, editTextUser.Text);
                Preferences.Set(Globals.PASSWORD_M, editTextPassword.Text);


                if (checkRemember.IsChecked)
                {
                    Preferences.Set(Globals.REMEMBER_M, true);
                    checkRemember.IsChecked = true;
                }
                else
                {
                    Preferences.Set(Globals.REMEMBER_M, false);
                    checkRemember.IsChecked = false;
                }
            }
            if (SAVIApplication.mParams == "CATERPILAR")
            {

                Preferences.Set(Globals.NAME_C, editTextUser.Text);
                Preferences.Set(Globals.PASSWORD_C, editTextPassword.Text);

                if (checkRemember.IsChecked)
                {
                    Preferences.Set(Globals.REMEMBER_C, true);
                    checkRemember.IsChecked = true;
                }
                else
                {
                    Preferences.Set(Globals.REMEMBER_C, false);
                    checkRemember.IsChecked = false;
                }
            }
        }

        //private bool ValidateEntries()
        //{
        //    bool IsValid = true;

        //    UserNameErrorLabel.Hidden = !string.IsNullOrEmpty(editTextUser.Text);
        //    PasswordErrorLabel.Hidden = !string.IsNullOrEmpty(editTextPassword.Text);

        //    IsValid = UserNameErrorLabel.Hidden && PasswordErrorLabel.Hidden ? true : false;

        //    return IsValid;
        //}
    }
}