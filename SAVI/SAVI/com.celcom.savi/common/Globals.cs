using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.Text;

namespace SAVI.com.celcom.savi.common
{
    public class Globals
    {
        public static string version = "BannerVersion";

        public static string barcodeResult = string.Empty;

        public static string[] ClientName = new string[50];
        public static string[] BannerURLList = new string[500];

        public  static int SOCK_TIMEOUT = 90000;

        public  static string REP_NAME = "REPNAME";
        public  static string REP_MSISDN = "REPMSISDN";
        public  static string STORE = "STORE";
        public  static string STORE_ID = "STOREID";
        public  static string BRAND = "BRAND";
        public  static string BRAND_ID = "BRANDID";
        public  static string BANK_ID = "BRANKID";
        public  static string BANK = "BRANK";
        public  static string COMPANY = "COMPANY";
        public  static string COMPANY_ID = "COMPANYID";
        public  static string NAME = "USERNAME";
        public  static string PASSWORD = "PASSWORD";
        public  static string REMEMBER = "REMEMBER";

        public  static string NAME_S = "USERNAME_SAVI";
        public  static string PASSWORD_S = "PASSWORD_SAVI";
        public  static string REMEMBER_S = "REMEMBER_MOBILITY";

        public  static string NAME_M = "USERNAME_MOBILITY";
        public  static string PASSWORD_M = "PASSWORD_MOBILITY";
        public  static string REMEMBER_M = "REMEMBER_MOBILITY";

        public static string NAME_C = "USERNAME_CATERPILAR";
        public static string PASSWORD_C = "PASSWORD_CATERPILAR";
        public static string REMEMBER_C = "REMEMBER_CATERPILAR";

        public static  string BACKSTACK_CLAIM_STEP1 = "Claim Step1";
    public static  string BACKSTACK_CLAIM_STEP2 = "Claim Step2";
    public static  string BACKSTACK_CLAIM_STEP3 = "Claim Step3";
    public static  string BACKSTACK_CLAIM_STEP4 = "Claim Step4";
    public static  string BACKSTACK_CLAIM_STEP5 = "Claim Step5";

    public static bool CLAIM_COMMISSION = true;

        public static int imageWidth = 652;
        public static int imageHeight = 489;

        //public  static string URL = "https://vpstss05.vpsvirtual.com";
        public  static String URL = "https:/";


        /**************************************************************************************************/
        //  TSS
        /**************************************************************************************************/
        /**************************************************************************************************/
        //  TEST - SAVI
        //public  static String URL_WS_S = "/SAVITest/saRPWs.asmx";
        //public  static String VERSION_URL_S = "/savitest/version.json";

        /**************************************************************************************************/
        //  TEST - Mobility
        //public  static String URL_WS_M = "/CelcomMobilityTest/saRPWs.asmx";
        //public  static String VERSION_URL_M = "/CelcomMobilityTest/version.json";

        /**************************************************************************************************/

        /**************************************************************************************************/
        //  RELEASE - SAVI
         public  static String URL_WS_S = "/savi.celcom.co.za/WebService/SARPWs.asmx";
         public  static String VERSION_URL_S = "/savi/version.json";

        /**************************************************************************************************/
        //  RELEASE - Mobility
         public  static String URL_WS_M = "/mobility.celcom.co.za/WebService/saRPWs.asmx";
         public  static String VERSION_URL_M = "/celcommobility/version.json";


        /**************************************************************************************************/
        //  RELEASE Beta- Mobility
        //public  static String URL_WS_M = "/mobility.celcom.co.za/WebSvc/saRPWs.asmx";
       //public  static String VERSION_URL_M = "/celcommobility/version.json";


    }
}
