using SAVI.com.celcom.savi;
using SAVI.com.celcom.savi.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAVI.wSClientLib
{
    public class WebServiceUtil
    {
        private static CLIGenericListenerAsync service = new CLIGenericListenerAsync();
        public static CLIGenericListenerAsync getVPSService()
        {
           

            if (SAVIApplication.mParams)
            {
                service.setUrl(Globals.URL_WS_S);
            }
            else
            {
                service.setUrl(Globals.URL_WS_M);
            }

            service.setBaseUrl(Globals.URL);

        

            return service;
        }
    }
}
