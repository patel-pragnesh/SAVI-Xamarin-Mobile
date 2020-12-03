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
    public partial class Airtime2 : ContentPage
    {
        private Airtime2ViewModel MyViewModel
        {
            get { return (Airtime2ViewModel)BindingContext; }
            set { BindingContext = value; }
        }
        private string network = string.Empty;
        protected override void OnAppearing()
        {

            DataBoundlePicker.SelectedIndex = 0;

        }

        public Airtime2( string Network)
        {
            InitializeComponent();
            MyViewModel = new Airtime2ViewModel();
            BindingContext = MyViewModel;
            network = Network;
            AirtimeAmountEntry.IsVisible = true;
            DataBoundlePicker.IsVisible = false;

            AirtimeButton.Source = "ivoice_active.png";
            DataButton.Source = "idata_.png";
            if ((SAVIApplication.MSISDN.Length == 10) && (SAVIApplication.MSISDN.StartsWith("0")))
            {
                SAVIApplication.MSISDN = "27" + SAVIApplication.MSISDN.Substring(1);
            }

          var ListGetProductResponseDataBundle= App.SoapService.GetAllDataBundles(network, "Data").ListOfDataBundles;

           
            for (int i = 0; i < ListGetProductResponseDataBundle.Count; ++i)
            {
                MyViewModel.GetProductResponseDataBundles.Add(ListGetProductResponseDataBundle[i]);
            }

        }

        private void AirtimeButton_Clicked(object sender, EventArgs e)
        {
            //SAVIApplication.MSISDN;
            AirtimeAmountEntry.IsVisible = true;
            DataBoundlePicker.IsVisible = false;


            AirtimeButton.Source = "ivoice_active.png";
            DataButton.Source = "idata_.png";

        }

        private void DataButton_Clicked(object sender, EventArgs e)
        {
            AirtimeAmountEntry.IsVisible = false;
            DataBoundlePicker.IsVisible = true;
            AirtimeButton.Source = "ivoice_.png";
            DataButton.Source = "idata_active.png";
        }

        private void DataBounblePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private async void FinishButton_Clicked(object sender, EventArgs e)
        {
            try
            {

                if (AirtimeAmountEntry.IsVisible)
                {
                    if (AirtimeAmountEntry.Text != null)
                    {
                        if (AirtimeAmountEntry.Text.Trim().Length < 1)
                        {
                            CrossToastPopUp.Current.ShowToastMessage("Please enter an Amount!");
                            AirtimeAmountEntry.Focus();
                            return;
                        }
                        else
                        {
                            Double requestValue = Double.Parse(AirtimeAmountEntry.Text.Trim());
                            if (requestValue > SAVIApplication.Balance)
                            {
                                CrossToastPopUp.Current.ShowToastMessage("You do not have enough funds to continue this transaction!");
                                return;
                            }
                            String transactionRef = "SAVIValidate_" + DateTime.Now.Millisecond.ToString();

                            var resultpinvalidate = App.SoapService.PinlessValidate(network, transactionRef, "CallAccount", SAVIApplication.MSISDN, AirtimeAmountEntry.Text.Trim());

                            if (resultpinvalidate.ResponseCode == "0")
                            {


                                String transactionRefV = "SAVIValidate_" + DateTime.Now.Millisecond.ToString();

                                var resultpinlessvend = App.SoapService.PinlessVend(SAVIApplication.mRegistrationID.ToString(), SAVIApplication.PaymentTypeID, network, transactionRefV, "CallAccount", SAVIApplication.MSISDN, AirtimeAmountEntry.Text.Trim(), AirtimeAmountEntry.Text.Trim(), AirtimeAmountEntry.Text.Trim());
                                if (resultpinlessvend.ResponseCode == "0")
                                {
                                    SAVIApplication.SlipMessage = resultpinlessvend.ResponseMessage;


                                    SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("\"", "");
                                    SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("\\n", "<br>");
                                    SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("\n", "<br>");
                                    SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("\\t", " ");
                                    SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("<b>", " ");
                                    SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("&lt;br /&gt;", "<br> ");
                                    SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("&lt;br/&gt;", "<br>");
                                    SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("&lt;b&gt;", " ");
                                    SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("&lt;/b&gt;", " ");
                                    await Navigation.PushAsync(new BrowserView(SAVIApplication.SlipMessage));

                                }
                                else
                                {
                                    CrossToastPopUp.Current.ShowToastMessage(resultpinvalidate.ResponseMessage);
                                    App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Airtime Commission", resultpinvalidate.ResponseMessage);
                                }
                            }

                        }
                    }
                }
                else
                {
                    if (MyViewModel.SelectedBundle == null)
                    {
                        DataBoundlePicker.Focus();
                        return;
                    }
                    if (DataBoundlePicker.IsVisible)
                    {
                        String transactionRef = "SAVIValidate_" + DateTime.Now.Millisecond.ToString();

                        string denom = string.Empty;
                        string bundle = string.Empty;
                        string bun = string.Empty;
                        string value = string.Empty;

                        if (network == "Vodacom")
                        {
                            bun = "SmartBundle";
                            denom = "" + MyViewModel.SelectedBundle.TSSProductBundleMegs;
                            bundle = "" + MyViewModel.SelectedBundle.TSSProductBundleName;
                            value = "" + MyViewModel.SelectedBundle.TSSProductBundleValue;
                        }
                        else if (network == "MTN")
                        {
                            bun = "" + MyViewModel.SelectedBundle.TSSProductBundleShortCode;
                            denom = "" + MyViewModel.SelectedBundle.TSSProductBundleMegs;
                            bundle = "" + MyViewModel.SelectedBundle.TSSProductBundleName;
                            value = "" + MyViewModel.SelectedBundle.TSSProductBundleValue;
                        }
                        else if (network == "8ta")
                        {
                            bun = "" + MyViewModel.SelectedBundle.TSSProductBundleShortCode;
                            denom = "" + MyViewModel.SelectedBundle.TSSProductBundleMegs;
                            bundle = "" + MyViewModel.SelectedBundle.TSSProductBundleName;
                            value = "" + MyViewModel.SelectedBundle.TSSProductBundleValue;
                        }
                        else if (network == "CellC")
                        {
                            bun = "" + MyViewModel.SelectedBundle.ProductName;
                            denom = "" + MyViewModel.SelectedBundle.TSSProductBundleMegs;
                            bundle = "" + MyViewModel.SelectedBundle.TSSProductBundleName;
                            value = "" + MyViewModel.SelectedBundle.TSSProductBundleValue;
                        }

                        var resultpinvalidate = App.SoapService.PinlessValidate(network, transactionRef, bun, SAVIApplication.MSISDN, denom);

                        if (resultpinvalidate.ResponseCode == "0")
                        {
                            String transactionRefV = "SAVIValidate_" + DateTime.Now.Millisecond.ToString();
                            var resultpinlessvend = App.SoapService.PinlessVend(SAVIApplication.mRegistrationID.ToString(), SAVIApplication.PaymentTypeID, network, transactionRefV, bun, SAVIApplication.MSISDN, denom, bundle, value);
                            if (resultpinlessvend.ResponseCode == "0")
                            {
                                SAVIApplication.SlipMessage = resultpinlessvend.ResponseMessage;


                                SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("\"", "");
                                SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("\\n", "<br>");
                                SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("\n", "<br>");
                                SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("\\t", " ");
                                SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("<b>", " ");
                                SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("&lt;br /&gt;", "<br> ");
                                SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("&lt;br/&gt;", "<br>");
                                SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("&lt;b&gt;", " ");
                                SAVIApplication.SlipMessage = SAVIApplication.SlipMessage.Replace("&lt;/b&gt;", " ");
                                await Navigation.PushAsync(new BrowserView(SAVIApplication.SlipMessage));
                            }
                        }
                        else
                        {
                            CrossToastPopUp.Current.ShowToastMessage(resultpinvalidate.ResponseMessage);
                            App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Data Bundle Commission", resultpinvalidate.ResponseMessage);
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                CrossToastPopUp.Current.ShowToastMessage("Somthing Wrong! Please try again.");
                App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Electricity", DateTime.Now.ToString() + "|" + ex.Message);
                await this.Navigation.PopAsync();
            }
        }
    }
}