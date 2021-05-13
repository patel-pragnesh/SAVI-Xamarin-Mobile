using Plugin.Toast;
using SAVI.com.celcom.savi;
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
    public partial class Electricity2 : ContentPage
    {
        string _Address; string _productCode; string _transactionRef; string _Meter; string _Amount;
        public Electricity2(string Address,string productCode, string transactionRef, string Meter , string Amount)
        {
            _Address = Address;
            _productCode = productCode;
            _transactionRef = transactionRef;
            _Meter = Meter;
            _Amount = Amount;
           
            InitializeComponent();
            textViewAddress.Text = "Is the address correct?\n\n"+_Address;
        }

        private async void buttonFinish_Clicked(object sender, EventArgs e)
        {
            if (!checkBox.IsChecked)
            {
                CrossToastPopUp.Current.ShowToastMessage("Please make sure of the Meter Number and Provider!");
                return;
            }
            else
            {
                try
                {
                    var resultTSS = App.SoapService.TSSProductVend(SAVIApplication.mRegistrationID.ToString(), _transactionRef, "Electricity", _productCode, _Meter, _Amount, _Address);
                    if (resultTSS.ResponseCode == "0")
                    {
                        SAVIApplication.SlipMessage = resultTSS.ResponseMessage;


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
                        CrossToastPopUp.Current.ShowToastMessage(resultTSS.ResponseMessage);
                        App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Electricity", resultTSS.ResponseMessage);
                    }
                }
                catch (Exception ex)
                {
                    CrossToastPopUp.Current.ShowToastMessage("Invalid session! Please login.");
                    App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Electricity", "Invalid session! Please login.");
                    App.SoapService.WriteError(SAVIApplication.mRegistrationID.ToString(), "Electricity", DateTime.Now.ToString() + "|" + ex.Message);
                }

            }

        }
    }
}