using SAVI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAVI.ViewModel
{
    public class ViewClaimViewModel 
    {
        private Redemption3 _Redemption3;

        public ViewClaimViewModel(Redemption3 Redemption3)
        {
            this._Redemption3 = Redemption3;
        }

        public string RedemptionID { get { return _Redemption3.RedemptionID; } }
        public string PromotionName { get { return _Redemption3.PromotionName; } }
        public string ProductCode { get { return _Redemption3.ProductCode; } }
        public string ProductDescription { get { return _Redemption3.ProductDescription; } }
        public string PromotionProductID { get { return _Redemption3.PromotionProductID; } }
        public string RedemtionDate { get { return _Redemption3.RedemtionDate; } }
        public string InvoiceNumber { get { return _Redemption3.InvoiceNumber; } }
        public string BrandName { get { return _Redemption3.BrandName; } }
        public string StoreID { get { return _Redemption3.StoreID; } }
        public string BrandID { get { return _Redemption3.BrandID; } }
        public string InvoiceID { get { return _Redemption3.InvoiceID; } }
        public string StoreName { get { return _Redemption3.StoreName; } }
        public string StoreRep { get { return _Redemption3.StoreRep; } }
        public string StoreRepMSISDN { get { return _Redemption3.StoreRepMSISDN; } }
        public string Imei { get { return _Redemption3.Imei; } }
        public string SubmittedDeviceLocationLatitude { get { return _Redemption3.SubmittedDeviceLocationLatitude; } }
        public string SubmittedDeviceLocationLongitude { get { return _Redemption3.SubmittedDeviceLocationLongitude; } }
        public string RetailValue { get { return _Redemption3.RetailValue; } }
        public string Verified { get { return _Redemption3.Verified; } }
        public string CompanyID { get { return _Redemption3.CompanyID; } }
        public string HasImage { get { return _Redemption3.HasImage; } }
        public string Disputed { get { return _Redemption3.Disputed; } }
        public string Paid { get { return _Redemption3.Paid; } }
        public string DisputesID { get { return _Redemption3.DisputesID; } }
        public string ImeiID { get { return _Redemption3.ImeiID; } }
        public string WindowsUser { get { return _Redemption3.WindowsUser; } }
        public string VerifiedDisputedDate { get { return _Redemption3.VerifiedDisputedDate; } }
        public string AutoProcessed { get { return _Redemption3.AutoProcessed; } }
        public string DetectCount { get { return _Redemption3.DetectCount; } }
        public string ContactName { get { return _Redemption3.ContactName; } }
        public string ContactSurname { get { return _Redemption3.ContactSurname; } }
        public string ContactMSISDN { get { return _Redemption3.ContactMSISDN; } }
        public string ContactEmail { get { return _Redemption3.ContactEmail; } }
        public string NoStock { get { return _Redemption3.NoStock; } }
        public string Pin { get { return _Redemption3.Pin; } }
        public string InvoiceDateCreated { get { return _Redemption3.InvoiceDateCreated; } }
        public string InvoiceDateModified { get { return _Redemption3.InvoiceDateModified; } }
      
        public Redemption3 Redemption3
        {
            get => _Redemption3;
        }

    }
}
