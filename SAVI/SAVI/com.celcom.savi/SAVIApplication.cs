using SAVI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAVI.com.celcom.savi
{
    public class SAVIApplication
    {
        public static string CCMETER;
        public static string CCMETERPROD;
        public static string ns = "http://tempuri.org/";
        public static string vpsvirtualwebsite= "vpsvirtual.com";
        public static string SlipMessage;
        public static string PaymentTypeID;
        public static double Balance;
        public static string MSISDN;
        public static double mLatitude;
        public static double mLongitude;
        //public static Location mLoc;

        public static string IMEI;

        public static long mRegistrationID;
        public static long mCompanyID;
        public static string mCompany;
        public static long mStoreID;

        //public static Registration mReg;

        public static string mParams; // company 

        public static List<ValidateBarcodeReply> mProds = new List<ValidateBarcodeReply>();
        //public static PromotionProduct Prod = new PromotionProduct();
        public static bool Used = false;

        //public static PromotionProduct Gift = null;
        public static bool IsGift = false;
        //public static Redemption mReddem;
        //public static PromotionProduct mProd = null;
    }
}
