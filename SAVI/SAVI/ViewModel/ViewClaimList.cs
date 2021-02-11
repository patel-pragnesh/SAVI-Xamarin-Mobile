using Demo.Pages;
using Rg.Plugins.Popup.Services;
using SAVI.com.celcom.savi;
using SAVI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SAVI.ViewModel
{
    public class ViewClaimList : BaseViewModel
    {
        public ObservableCollection<ViewClaimViewModel> ClaimsHistory { get; set; } //pump businesses list to view
        public Command LoadClaimsHistory { get; set; }
        private DateTime DteFrom;
        private DateTime DteTo;
        public StatusClass stClass { get; set; }

        public ViewClaimList(DateTime dteFrom, DateTime dteTo)
        {

            stClass = new StatusClass();
       
              DteFrom = dteFrom;
            DteTo = dteTo;
            ClaimsHistory = new ObservableCollection<ViewClaimViewModel>();
            ClaimsHistory.Clear();
            LoadClaimsHistory = new Command(async () => {

                if (DteFrom == null || DteTo == null) return;

                var k = App.SoapService.GetDisputes().GetDisputesResult;

                var companyname = App.SoapService.GetCompnyName(SAVIApplication.mRegistrationID.ToString()).GetCompnyNameResult;
                if (!string.IsNullOrWhiteSpace(companyname))
                {

                    SAVIApplication.mCompany = companyname;

                    if (dteFrom != null && dteTo != null)
                    {
                        ClaimsHistory.Clear();
                        var status = await GetClaimsHistoryAsync();
                        if (!status.checkstatus)
                        {
                            if (Device.RuntimePlatform != Device.UWP)
                            {
                                ClaimsHistory.Clear();
                                status = await  GetClaimsHistoryAsync();
                            }
                        }

                       

                    }

                }





              
            });

        }
        private async System.Threading.Tasks.Task<StatusClass> GetClaimsHistoryAsync()
        {
         
            stClass.checkstatus = false;


            if (IsBusy)
            {
                stClass.isBusy = IsBusy;
                return stClass;
            }

            IsBusy = true;
           // var pageLoading = new LoadingPopupPage();
            try
            {


              //  await PopupNavigation.Instance.PushAsync(pageLoading);
                List<Redemption3> redemption3List = App.SoapService.GetMobilityRedemptionByAccNoNoVoucher(DteFrom.ToString("yyyy-MM-dd"), DteTo.ToString("yyyy-MM-dd"), SAVIApplication.mCompany).GetMobilityRedemptionByAccNoNoVoucherResult;
               
                foreach (var cs in redemption3List)
                {
                    ClaimsHistory.Add(new ViewClaimViewModel(cs));
                }

                stClass.checkstatus = true;
              //  pageLoading.CloseMe();
            }
            catch /*(Exception ex)*/
            {
                stClass.checkstatus = false;
                stClass.isBusy = true;
            }
            finally
            {
                
                IsBusy = false;
                stClass.isBusy = IsBusy;
            }
      
            return stClass;

        }

    }

}
