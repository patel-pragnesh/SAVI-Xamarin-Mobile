using Demo.Pages;
using Rg.Plugins.Popup.Services;
using SAVI.com.celcom.savi;
using SAVI.com.celcom.savi.common;
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
    public partial class ForgetPassword : ContentPage
    {
        private ShowMessagePopupPage pageMessage;
        public ForgetPassword()
        {
            InitializeComponent();
        }



        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(editTextUser.Text))
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
            if (string.IsNullOrWhiteSpace(editTextAccNo.Text))
            {
                editTextAccNo.Text = "";
                editTextAccNo.Focus();
                return;
            }
            if (editTextAccNo.Text.ToString().Trim().Length < 2)
            {
                editTextAccNo.Text = "";
                editTextAccNo.Focus();
                return;
            }

            var pageLoading = new LoadingPopupPage();
            await PopupNavigation.Instance.PushAsync(pageLoading);

            try
            {


                try
                {
                    bool forgetResult =App.SoapService.forgetpassword(editTextUser.Text, editTextAccNo.Text);
                    if (forgetResult)
                    {

                        bool answer = await DisplayAlert("", "Please monitor your Email. Do you want to proceed?", "OK", "Cancel");
                        if (answer)
                        {
                            pageLoading.CloseMe();
                            await Navigation.PushAsync(new login());

                        }

                      

                    }
                    else
                    {
                        pageLoading.CloseMe();
                        pageMessage = new ShowMessagePopupPage("Error at processing! Please try again!");
                        await PopupNavigation.Instance.PushAsync(pageMessage);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    pageLoading.CloseMe();
                    pageMessage = new ShowMessagePopupPage("Error at processing! Please try again!");
                    await PopupNavigation.Instance.PushAsync(pageMessage);
                    return;
                }


            }
            catch (FaultException ex)
            {
                pageLoading.CloseMe();
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Login", DateTime.Now.ToString() + "|" + ex.Message);
                pageMessage = new ShowMessagePopupPage("Error: " + ex.Message);
                await PopupNavigation.Instance.PushAsync(pageMessage);

            }
            catch (CommunicationException ex)
            {
                pageLoading.CloseMe();
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Login", DateTime.Now.ToString() + "|" + ex.Message);
                pageMessage = new ShowMessagePopupPage("Error: " + ex.Message);
                await PopupNavigation.Instance.PushAsync(pageMessage);

            }
            catch (TimeoutException ex)
            {
                pageLoading.CloseMe();
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Login", DateTime.Now.ToString() + "|" + ex.Message);
                pageMessage = new ShowMessagePopupPage("Error: " + ex.Message);
                await PopupNavigation.Instance.PushAsync(pageMessage);

            }
            catch (Exception ex)
            {
                pageLoading.CloseMe();
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Login", DateTime.Now.ToString() + "|" + ex.Message);
                pageMessage = new ShowMessagePopupPage("Error: " + ex.Message);
                await PopupNavigation.Instance.PushAsync(pageMessage);

            }
            finally { pageLoading.CloseMe(); }



        }


    }
}