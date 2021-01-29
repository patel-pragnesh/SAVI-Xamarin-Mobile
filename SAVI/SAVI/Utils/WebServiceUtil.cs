using SAVI.com.celcom.savi;
using SAVI.com.celcom.savi.common;
using SAVI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SAVI.Utils
{
    public  class WebServiceUtil
    {
        static XNamespace ns = SAVIApplication.ns;

        public HttpWebRequest CreateSOAPWebRequest()
        {
            //Making Web Request    
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(Globals.URL + Globals.URL_WS_M);
            //Content_type    
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method    
            Req.Method = "POST";
            //return HttpWebRequest    
            return Req;
        }


        public LoginReply login(string Username, string Password)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <Login  xmlns=""http://tempuri.org/"">  
                  <Username>" + Username + @"</Username>  
                  <Password>" + Password + @"</Password>  
                </Login >  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);

                   
                    IEnumerable<XElement> resultes = soap.Descendants(ns + "LoginResponse");

                    LoginReply LoginResult = new LoginReply();

                    foreach (XElement result in resultes)
                    {
                        LoginResult.LoginResult = (string)result.Element(ns + "LoginResult");
                      
                    }


                    return LoginResult;
                }
            }
        }

        public ValidVoucherAndPromotion2Reply ValidVoucherAndPromotion2(string barcode, string ignorePromotion)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <ValidVoucherAndPromotion2 xmlns=""http://tempuri.org/"">  
                  <Barcode>" + barcode + @"</Barcode>  
                  <IgnorePromotion>" + ignorePromotion + @"</IgnorePromotion>  
                </ValidVoucherAndPromotion2>  
              </soap:Body>  
            </soap:Envelope>");    

                     using (Stream stream = request.GetRequestStream())
                    {
                        SOAPReqBody.Save(stream);
                    }
                    //Geting response from request    
                    using (WebResponse Serviceres = request.GetResponse())
                    {
                        using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                        {
                            //reading stream    
                            var ServiceResult = rd.ReadToEnd();
                            var soap = XDocument.Parse(ServiceResult);
                            IEnumerable<XElement> results = soap.Descendants(ns + "ValidVoucherAndPromotion2Result");

                            ValidVoucherAndPromotion2Reply ValidVoucherAndPromotion2Result = new ValidVoucherAndPromotion2Reply();
                    ValidVoucherAndPromotion2Result.IdValue = new IdValue();
                             foreach (XElement result in results)
                                {


                        ValidVoucherAndPromotion2Result.IdValue.ID = (string)result.Element(ns + "ID");
                        ValidVoucherAndPromotion2Result.IdValue.Value= (string)result.Element(ns + "Value");
                        ValidVoucherAndPromotion2Result.IdValue.ID1 = (string)result.Element(ns + "ID1");
                        ValidVoucherAndPromotion2Result.IdValue.ID2 = (string)result.Element(ns + "ID2");
                        ValidVoucherAndPromotion2Result.IdValue.Amount = (string)result.Element(ns + "Amount");
                        ValidVoucherAndPromotion2Result.IdValue.PromotionID = (string)result.Element(ns + "PromotionID");
                        ValidVoucherAndPromotion2Result.IdValue.TimeStamp = (string)result.Element(ns + "TimeStamp");
                        ValidVoucherAndPromotion2Result.IdValue.Value1 = (string)result.Element(ns + "Value1");
                        ValidVoucherAndPromotion2Result.IdValue.Used = (string)result.Element(ns + "Used");

                                }
                                    return ValidVoucherAndPromotion2Result;

                        }
                    }
        }

        public GetStoreIDReply GetStoreID(string registrationId)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetStoreID  xmlns=""http://tempuri.org/"">  
                  <registrationId>" + registrationId + @"</registrationId>  
                </GetStoreID>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetStoreIDResponse");

                    GetStoreIDReply GetStoreIDReply = new GetStoreIDReply();

                    foreach (XElement result in resultes)
                    {
                        GetStoreIDReply.GetStoreIDResult = (string)result.Element(ns + "GetStoreIDResult");

                    }


                    return GetStoreIDReply;
                }
            }
        }

        public GetCompanyIDReply GetCompnyID(string registrationId)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetCompnyID  xmlns=""http://tempuri.org/"">  
                  <registrationId>" + registrationId + @"</registrationId>  
                </GetCompnyID>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetCompnyIDResponse");

                    GetCompanyIDReply GetCompanyIDReply = new GetCompanyIDReply();

                    foreach (XElement result in resultes)
                    {
                        GetCompanyIDReply.GetCompnyIDResult = (string)result.Element(ns + "GetCompnyIDResult");

                    }


                    return GetCompanyIDReply;
                }
            }
        }


        public GetCompanyNameReply GetCompnyName(string registrationId)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetCompnyName  xmlns=""http://tempuri.org/"">  
                  <registrationId>" + registrationId + @"</registrationId>  
                </GetCompnyName>  
              </soap:Body>
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetCompnyNameResponse");

                    GetCompanyNameReply GetCompanyNameReply = new GetCompanyNameReply();

                    foreach (XElement result in resultes)
                    {
                        GetCompanyNameReply.GetCompnyNameResult = (string)result.Element(ns + "GetCompnyNameResult");

                    }


                    return GetCompanyNameReply;
                }
            }
        }


        public GetStoreAndBrandReply GetStoreAndBrand(string registrationId)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetStoreAndBrand   xmlns=""http://tempuri.org/"">  
                  <StoreID>" + registrationId + @"</StoreID>  
                </GetStoreAndBrand >  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetStoreAndBrandResult");

                    GetStoreAndBrandReply GetStoreAndBrandReply = new GetStoreAndBrandReply();

                    foreach (XElement result in resultes)
                    {
                        GetStoreAndBrandReply.ID = (string)result.Element(ns + "ID");
                        GetStoreAndBrandReply.Value = (string)result.Element(ns + "Value");
                        GetStoreAndBrandReply.ID1 = (string)result.Element(ns + "ID1");
                        GetStoreAndBrandReply.ID2 = (string)result.Element(ns + "ID2");
                        GetStoreAndBrandReply.Amount = (string)result.Element(ns + "Amount");
                        GetStoreAndBrandReply.PromotionID = (string)result.Element(ns + "PromotionID");
                        GetStoreAndBrandReply.TimeStamp = (string)result.Element(ns + "TimeStamp");
                        GetStoreAndBrandReply.Type = (string)result.Element(ns + "Type");
                        GetStoreAndBrandReply.Value1 = (string)result.Element(ns + "Value1");
                        GetStoreAndBrandReply.Used = (string)result.Element(ns + "Used");
                        GetStoreAndBrandReply.WindowsUser = (string)result.Element(ns + "WindowsUser");

                    }


                    return GetStoreAndBrandReply;
                }
            }
        }


        public GetMobilityRedemptionByAccNoNoVoucherReply GetMobilityRedemptionByAccNoNoVoucher(string fromDate, string toDate, string AccNum)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetMobilityRedemptionByAccNoNoVoucher xmlns=""http://tempuri.org/""> 
                    <dteFrom>" + fromDate + @"</dteFrom>
                    <dteTo>" + toDate + @"</dteTo>
                    <AccountNumber>" + AccNum + @"</AccountNumber>
                </GetMobilityRedemptionByAccNoNoVoucher>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetMobilityRedemptionByAccNoNoVoucherResponse");

                    GetMobilityRedemptionByAccNoNoVoucherReply GetMobilityRedemptionByAccNoNoVoucherReply = new GetMobilityRedemptionByAccNoNoVoucherReply();

                    GetMobilityRedemptionByAccNoNoVoucherReply.GetMobilityRedemptionByAccNoNoVoucherResult = new List<Redemption3>();


                    foreach (XElement result in resultes)
                    {

                        var redemption3 = result.Descendants(ns + "Redemption3");
                        foreach (XElement idv in redemption3)
                        {
                            Redemption3 redemption = new Redemption3();
                            redemption.RedemptionID = (string)idv.Element(ns + "RedemptionID");
                            redemption.PromotionName = (string)idv.Element(ns + "PromotionName");
                            redemption.ProductCode = (string)idv.Element(ns + "ProductCode");
                            redemption.ProductDescription = (string)idv.Element(ns + "ProductDescription");
                            redemption.PromotionProductID = (string)idv.Element(ns + "PromotionProductID");
                            redemption.RedemtionDate = (string)idv.Element(ns + "RedemtionDate");
                            redemption.InvoiceNumber = (string)idv.Element(ns + "InvoiceNumber");
                            redemption.BrandName = (string)idv.Element(ns + "BrandName");
                            redemption.StoreID = (string)idv.Element(ns + "StoreID");
                            redemption.BrandID = (string)idv.Element(ns + "BrandID");
                            redemption.InvoiceID = (string)idv.Element(ns + "InvoiceID");
                            redemption.StoreName = (string)idv.Element(ns + "StoreName");
                            redemption.StoreRep = (string)idv.Element(ns + "StoreRep");
                            redemption.StoreRepMSISDN = (string)idv.Element(ns + "StoreRepMSISDN");
                            redemption.Imei = (string)idv.Element(ns + "Imei");
                            redemption.SubmittedDeviceLocationLatitude = (string)idv.Element(ns + "SubmittedDeviceLocationLatitude");
                            redemption.SubmittedDeviceLocationLongitude = (string)idv.Element(ns + "SubmittedDeviceLocationLongitude");
                            redemption.RetailValue = (string)idv.Element(ns + "RetailValue");
                            redemption.Verified = (string)idv.Element(ns + "Verified");
                            redemption.CompanyID = (string)idv.Element(ns + "CompanyID");
                            redemption.HasImage = (string)idv.Element(ns + "HasImage");
                            redemption.Disputed = (string)idv.Element(ns + "Disputed");
                            redemption.Paid = (string)idv.Element(ns + "Paid");
                            redemption.DisputesID = (string)idv.Element(ns + "DisputesID");
                            redemption.ImeiID = (string)idv.Element(ns + "ImeiID");
                            redemption.WindowsUser = (string)idv.Element(ns + "WindowsUser");
                            redemption.VerifiedDisputedDate = (string)idv.Element(ns + "VerifiedDisputedDate");
                            redemption.AutoProcessed = (string)idv.Element(ns + "AutoProcessed");
                            redemption.DetectCount = (string)idv.Element(ns + "DetectCount");
                            redemption.ContactName = (string)idv.Element(ns + "ContactName");
                            redemption.ContactSurname = (string)idv.Element(ns + "ContactSurname");
                            redemption.ContactMSISDN = (string)idv.Element(ns + "ContactMSISDN");
                            redemption.ContactEmail = (string)idv.Element(ns + "ContactEmail");
                            redemption.NoStock = (string)idv.Element(ns + "NoStock");
                            redemption.Pin = (string)idv.Element(ns + "Pin");
                            redemption.InvoiceDateCreated = (string)idv.Element(ns + "InvoiceDateCreated");
                            redemption.InvoiceDateModified = (string)idv.Element(ns + "InvoiceDateModified");
                            GetMobilityRedemptionByAccNoNoVoucherReply.GetMobilityRedemptionByAccNoNoVoucherResult.Add(redemption);
                        }
                    }
                    return GetMobilityRedemptionByAccNoNoVoucherReply;
                }
            }

        }


        public GetDisputesReply GetDisputes()
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetDisputes   xmlns=""http://tempuri.org/""/>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);

                  
                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetDisputesResult");

                    GetDisputesReply GetDisputesReply = new GetDisputesReply();

                    GetDisputesReply.GetDisputesResult = new List<IdValue>();

                    

                    foreach (XElement result in resultes)
                    {

                       var idvalue = result.Descendants(ns + "IdValue");
                        foreach (XElement idv in idvalue)
                        {
                            IdValue idValue = new IdValue();
                            idValue.ID = (string)idv.Element(ns + "ID");
                            idValue.Value = (string)idv.Element(ns + "Value");
                            idValue.ID1 = (string)idv.Element(ns + "ID1");
                            idValue.ID2 = (string)idv.Element(ns + "ID2");
                            idValue.Amount = (string)idv.Element(ns + "Amount");
                            idValue.PromotionID = (string)idv.Element(ns + "PromotionID");
                            idValue.TimeStamp = (string)idv.Element(ns + "TimeStamp");
                            idValue.Value1 = (string)idv.Element(ns + "Value1");
                            idValue.Used = (string)idv.Element(ns + "Used");
                            GetDisputesReply.GetDisputesResult.Add(idValue);
                        }
                    }

                    return GetDisputesReply;
                }
            }
        }



        public GetInvoiceImageReply GetInvoiceImage(string invoiceNumber, string storeID)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetInvoiceImage   xmlns=""http://tempuri.org/"">  
                  <InvoiceNumber>" + invoiceNumber + @"</InvoiceNumber>  
                  <StoreID>" + storeID + @"</StoreID>  
                </GetInvoiceImage>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetInvoiceImageResponse");

                    GetInvoiceImageReply GetInvoiceImageReply = new GetInvoiceImageReply();

                   
                    foreach (XElement result in resultes)
                    {
                        GetInvoiceImageReply.GetInvoiceImageResult = (string)result.Element(ns + "GetInvoiceImageResult");
                    }

                    return GetInvoiceImageReply;
                }
            }
        }



        public GetRegistrationReply GetRegistration(string name)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetRegistrationV3  xmlns=""http://tempuri.org/"">  
                  <Username>" + name + @"</Username>  
                </GetRegistrationV3>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetRegistrationV3Response");

                    GetRegistrationReply GetRegistrationResult = new GetRegistrationReply();
                    GetRegistrationResult.GetRegistrationResult = new Registration();

                   
                    
                    var registrationResult = resultes.Descendants(ns + "GetRegistrationV3Result");

                

                    foreach (XElement idv in registrationResult)
                    {
                        Registration registration = new Registration();
                        registration.AccountNum = (string)idv.Element(ns + "AccountNum");
                        registration.AddressDisputed = (string)idv.Element(ns + "AddressDisputed");
                        registration.AddressImage = (string)idv.Element(ns + "AddressImage");
                        registration.AddressVerified = (string)idv.Element(ns + "AddressVerified");
                        registration.AdvertCounter= (string)idv.Element(ns + "AdvertCounter");
                        registration.BankID= (string)idv.Element(ns + "BankID");
                        registration.CompanyID = (string)idv.Element(ns + "CompanyID");
                        registration.CompanyTradingName = (string)idv.Element(ns + "CompanyTradingName");
                        registration.ContactEmail = (string)idv.Element(ns + "ContactEmail");
                        registration.ContactNumber = (string)idv.Element(ns + "ContactNumber");
                        registration.IdDisputed = (string)idv.Element(ns + "IdDisputed");
                        registration.IdImage = (string)idv.Element(ns + "IdImage");
                        registration.IdNumber = (string)idv.Element(ns + "IdNumber");
                        registration.IdType = (string)idv.Element(ns + "IdType");
                        registration.IdVerified = (string)idv.Element(ns + "IdVerified");
                        registration.MiddleName = (string)idv.Element(ns + "MiddleName");
                        registration.Name = (string)idv.Element(ns + "Name");
                        registration.Nationality = (string)idv.Element(ns + "Nationality");
                        registration.Password = (string)idv.Element(ns + "Password");
                        registration.RegistrationID = (string)idv.Element(ns + "RegistrationID");
                        registration.StoreID = (string)idv.Element(ns + "StoreID");
                        registration.Surname = (string)idv.Element(ns + "Surname");
                        registration.Title = (string)idv.Element(ns + "Title");
                        registration.Username = (string)idv.Element(ns + "Username");


                        GetRegistrationResult.GetRegistrationResult = registration;
                    }



                    return GetRegistrationResult;
                }
            }
        }




        public GetBrandsReply GetBrands()
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetBrands xmlns=""http://tempuri.org/""/>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetBrandsResult");

                    GetBrandsReply getBrandsReply = new GetBrandsReply();

                    getBrandsReply.GetBrandsResult = new List<IdValue>();



                    foreach (XElement result in resultes)
                    {

                        var idvalue = result.Descendants(ns + "IdValue");
                        foreach (XElement idv in idvalue)
                        {
                            IdValue idValue = new IdValue();
                            idValue.ID = (string)idv.Element(ns + "ID");
                            idValue.Value = (string)idv.Element(ns + "Value");
                            idValue.ID1 = (string)idv.Element(ns + "ID1");
                            idValue.ID2 = (string)idv.Element(ns + "ID2");
                            idValue.Amount = (string)idv.Element(ns + "Amount");
                            idValue.PromotionID = (string)idv.Element(ns + "PromotionID");
                            idValue.TimeStamp = (string)idv.Element(ns + "TimeStamp");
                            idValue.Value1 = (string)idv.Element(ns + "Value1");
                            idValue.Type = (string)idv.Element(ns + "Type");
                            idValue.Used = (string)idv.Element(ns + "Used");
                            idValue.WindowsUser = (string)idv.Element(ns + "WindowsUser");
                            getBrandsReply.GetBrandsResult.Add(idValue);
                        }
                    }

                    return getBrandsReply;
                }
            }
        }



        public GetStoresReply GetStores(string BrandID)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetStores xmlns=""http://tempuri.org/""/>  

                <GetStores  xmlns=""http://tempuri.org/"">  
                  <BrandID>" + BrandID + @"</BrandID>  
                </GetStores>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetStoresResult");

                    GetStoresReply getStoresReply = new GetStoresReply();

                    getStoresReply.GetStoresResult = new List<IdValue>();



                    foreach (XElement result in resultes)
                    {

                        var idvalue = result.Descendants(ns + "IdValue");
                        foreach (XElement idv in idvalue)
                        {
                            IdValue idValue = new IdValue();
                            idValue.ID = (string)idv.Element(ns + "ID");
                            idValue.Value = (string)idv.Element(ns + "Value");
                            idValue.ID1 = (string)idv.Element(ns + "ID1");
                            idValue.ID2 = (string)idv.Element(ns + "ID2");
                            idValue.Amount = (string)idv.Element(ns + "Amount");
                            idValue.PromotionID = (string)idv.Element(ns + "PromotionID");
                            idValue.TimeStamp = (string)idv.Element(ns + "TimeStamp");
                            idValue.Value1 = (string)idv.Element(ns + "Value1");
                            idValue.Type = (string)idv.Element(ns + "Type");
                            idValue.Used = (string)idv.Element(ns + "Used");
                            idValue.WindowsUser = (string)idv.Element(ns + "WindowsUser");
                            getStoresReply.GetStoresResult.Add(idValue);
                        }
                    }

                    return getStoresReply;
                }
            }
        }



        public GetBanksReply GetBanks()
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetBanks xmlns=""http://tempuri.org/""/>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetBanksResult");

                    GetBanksReply getBanksReply = new GetBanksReply();

                    getBanksReply.GetBanksResult = new List<IdValue>();



                    foreach (XElement result in resultes)
                    {

                        var idvalue = result.Descendants(ns + "IdValue");
                        foreach (XElement idv in idvalue)
                        {
                            IdValue idValue = new IdValue();
                            idValue.ID = (string)idv.Element(ns + "ID");
                            idValue.Value = (string)idv.Element(ns + "Value");
                            idValue.ID1 = (string)idv.Element(ns + "ID1");
                            idValue.ID2 = (string)idv.Element(ns + "ID2");
                            idValue.Amount = (string)idv.Element(ns + "Amount");
                            idValue.PromotionID = (string)idv.Element(ns + "PromotionID");
                            idValue.TimeStamp = (string)idv.Element(ns + "TimeStamp");
                            idValue.Value1 = (string)idv.Element(ns + "Value1");
                            idValue.Type = (string)idv.Element(ns + "Type");
                            idValue.Used = (string)idv.Element(ns + "Used");
                            idValue.WindowsUser = (string)idv.Element(ns + "WindowsUser");
                            getBanksReply.GetBanksResult.Add(idValue);
                        }
                    }

                    return getBanksReply;
                }
            }
        }




        public GetBankingDetailReply GetBankingDetails(string RegistrationID)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetBankingDetails  xmlns=""http://tempuri.org/"">  
                  <RegistrationID>" + RegistrationID + @"</RegistrationID>  
                </GetBankingDetails>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetBankingDetailsResponse");

                    GetBankingDetailReply GetBankingDetailResult = new GetBankingDetailReply();
                  



                    var GetBankingDetailsResult = resultes.Descendants(ns + "GetBankingDetailsResult");



                    foreach (XElement idv in GetBankingDetailsResult)
                    {

                        GetBankingDetailResult.BankID = (string)idv.Element(ns + "BankID");
                        GetBankingDetailResult.BankName = (string)idv.Element(ns + "BankName");
                        GetBankingDetailResult.BankSourceID = (string)idv.Element(ns + "BankSourceID");
                        GetBankingDetailResult.DateCreated = (string)idv.Element(ns + "DateCreated");
                        GetBankingDetailResult.Active = (string)idv.Element(ns + "Active");
                        GetBankingDetailResult.RecipientAccount = (string)idv.Element(ns + "RecipientAccount");
                        GetBankingDetailResult.RecipientAccountType = (string)idv.Element(ns + "RecipientAccountType");
                        GetBankingDetailResult.BranchCode = (string)idv.Element(ns + "BranchCode");


                       
                    }



                    return GetBankingDetailResult;
                }
            }
        }



        public string ValidateCompany(string CelcomAccNo)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <ValidateCompany  xmlns=""http://tempuri.org/"">  
                  <CelcomAccNo>" + CelcomAccNo + @"</CelcomAccNo>  
                </ValidateCompany>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "ValidateCompanyResponse");

                    LoginReply LoginResult = new LoginReply();
                    string ValidateCompanyResult=string.Empty;
                    foreach (XElement result in resultes)
                    {
                        ValidateCompanyResult = (string)result.Element(ns + "ValidateCompanyResult");

                    }


                    return ValidateCompanyResult;
                }
            }
        }




        public string UpdateBankingDetails(string RegistrationID, string BankID, string BankSourceID, string Active, string RecipientAccount, string RecipientAccountType, string BranchCode)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <UpdateBankingDetails xmlns=""http://tempuri.org/"">  
                  <RegistrationID>" + RegistrationID + @"</RegistrationID>  
                  <BankID>" + BankID + @"</BankID>  
                  <BankSourceID>" + BankSourceID + @"</BankSourceID>  
                  <Active>" + Active + @"</Active>  
                  <RecipientAccount>" + RecipientAccount + @"</RecipientAccount>  
                  <RecipientAccountType>" + RecipientAccountType + @"</RecipientAccountType>  
                  <BranchCode>" + BranchCode + @"</BranchCode>  
                </UpdateBankingDetails>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "UpdateBankingDetailsResponse");

                    LoginReply LoginResult = new LoginReply();
                    string UpdateBankingDetailsResult = string.Empty;
                    foreach (XElement result in resultes)
                    {
                        UpdateBankingDetailsResult = (string)result.Element(ns + "UpdateBankingDetailsResult");

                    }


                    return UpdateBankingDetailsResult;
                }
            }
        }


        public bool UpdateRegistrationV5(string RegistrationID, string CompanyTradingName, string Name, string Surname, string IdType, string IdNumber, string ContactNumber, string ContactEmail, string StoreID, string CompanyID, string BankID, string Title, string Middlename, string Nationality)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <UpdateRegistrationV5 xmlns=""http://tempuri.org/"">  
                  <RegistrationID>" + RegistrationID + @"</RegistrationID>  
                  <CompanyTradingName>" + CompanyTradingName + @"</CompanyTradingName>  
                  <Name>" + Name + @"</Name>  
                  <Surname>" + Surname + @"</Surname>  
                  <IdType>" + IdType + @"</IdType>  
                  <IdNumber>" + IdNumber + @"</IdNumber>  
                  <ContactNumber>" + ContactNumber + @"</ContactNumber>  
                  <ContactEmail>" + ContactEmail + @"</ContactEmail>
                  <StoreID>" + StoreID + @"</StoreID>
                  <CompanyID>" + CompanyID + @"</CompanyID>
                  <BankID>" + BankID + @"</BankID>
                  <Title>" + Title + @"</Title>
                  <Middlename>" + Middlename + @"</Middlename>
                  <Nationality>" + Nationality + @"</Nationality>
                </UpdateRegistrationV5>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();

                   
                    bool ok = false;
                    if (ServiceResult.Contains("UpdateRegistrationV5Response")) ok = true; else ok = false;

                    return ok;
                }
            }
        }


        public string CaptureMobilityBasketCustomer(List<Basket> Baskets, string InvoiceNumber, string RegistrationID, string Name, string Surname, string Number, string Email, string Address1, string Address2, string Address3, string Address4, string Address5, string PostCode)
        {
            String BasketString = String.Empty;
            foreach (var b in Baskets)
            {
                if (b.RedemptionID == null) b.RedemptionID = string.Empty;
                if (b.PromotionProductID == null) b.PromotionProductID = string.Empty;
                if (b.ImeiID == null) b.ImeiID = string.Empty;
                if (b.VoucherID == null) b.VoucherID = string.Empty;
                if (b.Imei == null) b.Imei = string.Empty;
                if (b.Voucher == null) b.Voucher = string.Empty;
                if (b.InvoiceID == null) b.InvoiceID = string.Empty;
                if (b.RedemtionDate == null) b.RedemtionDate = string.Empty;
                if (b.RedemtionDate != null)
                {
                    var _date = DateTime.Parse(b.RedemtionDate);
                    b.RedemtionDate = string.Format("{0:yyyy-MM-ddThh:mm:ss}", _date);
                }
                if (b.StoreName == null) b.StoreName = string.Empty;
                if (b.StoreRep == null) b.StoreRep = string.Empty;
                if (b.StoreRepMSISDN == null) b.StoreRepMSISDN = string.Empty;
                if (b.SubmittedDeviceLocationLatitude == null) b.SubmittedDeviceLocationLatitude = string.Empty;
                if (b.SubmittedDeviceLocationLongitude == null) b.SubmittedDeviceLocationLongitude = string.Empty;

                if (b.StoreID == null) b.StoreID = string.Empty;
                if (b.CompanyID == null) b.CompanyID = string.Empty;
                if (b.Company == null) b.Company = string.Empty;
                if (b.NoStock == null) b.NoStock = string.Empty;
                if (b.Pin == null) b.Pin = string.Empty;
                BasketString = BasketString + "<Basket>" +
          "<RedemptionID>" + b.RedemptionID + "</RedemptionID>" +
          "<PromotionProductID>" + b.PromotionProductID + "</PromotionProductID>" +
          "<ImeiID>" + b.ImeiID + "</ImeiID>" +
          "<VoucherID>" + b.VoucherID + "</VoucherID>" +
          "<Imei>" + b.Imei + "</Imei>" +
          "<Voucher>" + b.Voucher + "</Voucher>" +
          "<InvoiceID>" + b.InvoiceID + "</InvoiceID>" +
          "<RedemtionDate>" + b.RedemtionDate + "</RedemtionDate>" +
          "<StoreName>" + b.StoreName + "</StoreName>" +
          "<StoreRep>" + b.StoreRep + "</StoreRep>" +
          "<StoreRepMSISDN>" + b.StoreRepMSISDN + "</StoreRepMSISDN>" +
          "<SubmittedDeviceLocationLatitude>" + b.SubmittedDeviceLocationLatitude + "</SubmittedDeviceLocationLatitude>" +
          "<SubmittedDeviceLocationLongitude>" + b.SubmittedDeviceLocationLongitude + "</SubmittedDeviceLocationLongitude>" +
          "<StoreID>" + b.StoreID + "</StoreID>" +
          "<CompanyID>" + b.CompanyID + "</CompanyID>" +
          "<Company>" + b.Company + "</Company>" +
          "<NoStock>" + b.NoStock + "</NoStock>" +
          "<Pin>" + b.Pin + "</Pin >" +
        "</Basket>";

            }

            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();


            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <CaptureMobilityBasketCustomer xmlns=""http://tempuri.org/"">  
                  <BasketArray>" + BasketString + @"</BasketArray>  
                  <InvoiceNumber>" + InvoiceNumber + @"</InvoiceNumber>  
                  <RegistrationID>" + RegistrationID + @"</RegistrationID>  
                  <Name>" + Name + @"</Name>
                  <Surname>" + Surname + @"</Surname>  
                  <Number>" + Number + @"</Number>  
                  <Email>" + Email + @"</Email>  
                  <Address1>" + Address1 + @"</Address1> 
                  <Address2>" + Address2 + @"</Address2>
                  <Address3>" + Address3 + @"</Address3>
                  <Address4>" + Address4 + @"</Address4>
                  <Address5>" + Address5 + @"</Address5>
                  <PostCode>" + PostCode + @"</PostCode>
                </CaptureMobilityBasketCustomer>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "CaptureMobilityBasketCustomerResponse");

                    LoginReply LoginResult = new LoginReply();
                    string UpdateBankingDetailsResult = string.Empty;
                    foreach (XElement result in resultes)
                    {
                        UpdateBankingDetailsResult = (string)result.Element(ns + "CaptureMobilityBasketCustomerResult");

                    }


                    return UpdateBankingDetailsResult;
                }
            }
        }


        public string UpdateInvoiceNew(string base64Invoice, string InvoiceNumber, string StoreID, string extension, string AutoValidated)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <UpdateInvoiceNew xmlns=""http://tempuri.org/"">  
                  <base64Invoice>" + base64Invoice + @"</base64Invoice>  
                  <InvoiceNumber>" + InvoiceNumber + @"</InvoiceNumber>  
                  <StoreID>" + StoreID + @"</StoreID>  
                  <extension>" + extension + @"</extension>
                  <AutoValidated>" + AutoValidated + @"</AutoValidated>  
                </UpdateInvoiceNew>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "UpdateInvoiceNewResponse");

                  
                    string UpdateInvoiceNewResult = string.Empty;
                    foreach (XElement result in resultes)
                    {
                        UpdateInvoiceNewResult = (string)result.Element(ns + "UpdateInvoiceNewResult");

                    }


                    return UpdateInvoiceNewResult;
                }
            }
        }

        public ValidateBarcodeReply  ValidateBarcode(string barcode, string PromotionID)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <ValidateBarcode xmlns=""http://tempuri.org/"">  
                  <Barcode>" + barcode + @"</Barcode>  
                  <PromotionID>" + PromotionID + @"</PromotionID>  
                </ValidateBarcode>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);
                    IEnumerable<XElement> results = soap.Descendants(ns + "ValidateBarcodeResponse");


                    var ValidateBarcodeResult = results.Descendants(ns + "ValidateBarcodeResult");


                    ValidateBarcodeReply ValidateBarcodeReply = new ValidateBarcodeReply();
                    foreach (XElement result in ValidateBarcodeResult)
                    {

                       
                        ValidateBarcodeReply.Barcode = (string)result.Element(ns + "Barcode");
                        ValidateBarcodeReply.base64String = (string)result.Element(ns + "base64String");
                        ValidateBarcodeReply.DateAdded = (string)result.Element(ns + "DateAdded");
                        ValidateBarcodeReply.Deleted = (string)result.Element(ns + "Deleted");
                        ValidateBarcodeReply.Description = (string)result.Element(ns + "Description");
                        ValidateBarcodeReply.Gift = (string)result.Element(ns + "Gift");
                        ValidateBarcodeReply.GiftMaxLimit = (string)result.Element(ns + "GiftMaxLimit");
                        ValidateBarcodeReply.GiftStoreValue = (string)result.Element(ns + "GiftStoreValue");
                        ValidateBarcodeReply.GiftSupplyValue = (string)result.Element(ns + "GiftSupplyValue");
                        ValidateBarcodeReply.ImeiID = (string)result.Element(ns + "ImeiID");
                        ValidateBarcodeReply.ModifiedDate = (string)result.Element(ns + "ModifiedDate");
                        ValidateBarcodeReply.NoStock = (string)result.Element(ns + "NoStock");
                        ValidateBarcodeReply.PastelQuantity = (string)result.Element(ns + "PastelQuantity");
                        ValidateBarcodeReply.ProductCode = (string)result.Element(ns + "ProductCode");
                        ValidateBarcodeReply.ProductDetail = (string)result.Element(ns + "ProductDetail");
                        ValidateBarcodeReply.PromotionID = (string)result.Element(ns + "PromotionID");
                        ValidateBarcodeReply.PromotionProductID = (string)result.Element(ns + "PromotionProductID");
                        ValidateBarcodeReply.RedeemPortalPrice = (string)result.Element(ns + "RedeemPortalPrice");
                        ValidateBarcodeReply.RedemtionCount = (string)result.Element(ns + "RedemtionCount");
                        ValidateBarcodeReply.RetailValue = (string)result.Element(ns + "RetailValue");
                        ValidateBarcodeReply.RewardAmount = (string)result.Element(ns + "RewardAmount");
                        ValidateBarcodeReply.RewardCode = (string)result.Element(ns + "RewardCode");
                        ValidateBarcodeReply.VoucherID = (string)result.Element(ns + "VoucherID");
                       

                    }
                    return ValidateBarcodeReply;

                }
            }
        }



        public GetPromotionByIDReply GetPromotionByID(string PromotionID)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetPromotionByID xmlns=""http://tempuri.org/"">  
                  <PromotionID>" + PromotionID + @"</PromotionID>  
                </GetPromotionByID>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);
                    IEnumerable<XElement> results = soap.Descendants(ns + "GetPromotionByIDResponse");

                    var GetPromotionByIDResult = results.Descendants(ns + "GetPromotionByIDResult");
                    GetPromotionByIDReply GetPromotionByIDReply = new GetPromotionByIDReply();
                    foreach (XElement result in GetPromotionByIDResult)
                    {


                        GetPromotionByIDReply.AboveThreshold = (string)result.Element(ns + "Barcode");
                        GetPromotionByIDReply.BelowThreshold = (string)result.Element(ns + "base64String");
                        GetPromotionByIDReply.CelcomPayAccount = (string)result.Element(ns + "DateAdded");
                        GetPromotionByIDReply.CreatedDate = (string)result.Element(ns + "Deleted");
                        GetPromotionByIDReply.Deleted = (string)result.Element(ns + "Description");
                        GetPromotionByIDReply.Discount = (string)result.Element(ns + "Gift");
                        GetPromotionByIDReply.GiftAccount = (string)result.Element(ns + "GiftMaxLimit");
                        GetPromotionByIDReply.IMEI = (string)result.Element(ns + "GiftStoreValue");
                        GetPromotionByIDReply.ModifiedDate = (string)result.Element(ns + "GiftSupplyValue");
                        GetPromotionByIDReply.OnlinePayAccount = (string)result.Element(ns + "ImeiID");
                        GetPromotionByIDReply.PastelOrders = (string)result.Element(ns + "ModifiedDate");
                        GetPromotionByIDReply.PromotionEndDate = (string)result.Element(ns + "NoStock");
                        GetPromotionByIDReply.PromotionID = (string)result.Element(ns + "PastelQuantity");
                        GetPromotionByIDReply.PromotionIndefinitly = (string)result.Element(ns + "ProductCode");
                        GetPromotionByIDReply.PromotionName = (string)result.Element(ns + "ProductDetail");
                        GetPromotionByIDReply.PromotionProduct = (string)result.Element(ns + "PromotionID");
                        GetPromotionByIDReply.PromotionStartDate = (string)result.Element(ns + "PromotionProductID");
                        GetPromotionByIDReply.PromotionValue = (string)result.Element(ns + "RedeemPortalPrice");
                        GetPromotionByIDReply.Voucher = (string)result.Element(ns + "RedemtionCount");
                        GetPromotionByIDReply.VoucherCode = (string)result.Element(ns + "RetailValue");
                        
                    }
                    return GetPromotionByIDReply;

                }
            }
        }

        public GetPaymentTypesReply GetPaymentTypes()
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetPaymentTypes  xmlns=""http://tempuri.org/""/>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetPaymentTypesResult");

                    GetPaymentTypesReply GetPaymentTypesReply = new GetPaymentTypesReply();

                    GetPaymentTypesReply.GetPaymentTypesResult = new List<IdValue>();



                    foreach (XElement result in resultes)
                    {

                        var idvalue = result.Descendants(ns + "IdValue");
                        foreach (XElement idv in idvalue)
                        {
                            IdValue idValue = new IdValue();
                            idValue.ID = (string)idv.Element(ns + "ID");
                            idValue.Value = (string)idv.Element(ns + "Value");
                            idValue.ID1 = (string)idv.Element(ns + "ID1");
                            idValue.ID2 = (string)idv.Element(ns + "ID2");
                            idValue.Amount = (string)idv.Element(ns + "Amount");
                            idValue.PromotionID = (string)idv.Element(ns + "PromotionID");
                            idValue.TimeStamp = (string)idv.Element(ns + "TimeStamp");
                            idValue.Type = (string)idv.Element(ns + "Type");
                            idValue.Value1 = (string)idv.Element(ns + "Value1");
                            idValue.Used = (string)idv.Element(ns + "Used");
                            idValue.WindowsUser = (string)idv.Element(ns + "WindowsUser");
                            GetPaymentTypesReply.GetPaymentTypesResult.Add(idValue);
                        }
                    }

                    return GetPaymentTypesReply;
                }
            }
        }


        public string GetBalance(string RegistrationID)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetBalance  xmlns=""http://tempuri.org/"">  
                  <RegistrationID>" + RegistrationID + @"</RegistrationID>  
                </GetBalance >  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetBalanceResponse");


                    string GetBalanceResult = string.Empty;
                    foreach (XElement result in resultes)
                    {
                        GetBalanceResult = (string)result.Element(ns + "GetBalanceResult");

                    }


                    return GetBalanceResult;
                }
            }
        }
        public GetInboxReply GetInbox(string RegistrationID)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
          <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetInbox xmlns=""http://tempuri.org/"">  
                  <RegistrationID>" + RegistrationID + @"</RegistrationID>  
                </GetInbox>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetInboxResult");

                    GetInboxReply GetInboxReply = new GetInboxReply();

                    GetInboxReply.GetInboxResult = new List<IdValue>();



                    foreach (XElement result in resultes)
                    {

                        var idvalue = result.Descendants(ns + "IdValue");
                        foreach (XElement idv in idvalue)
                        {
                            IdValue idValue = new IdValue();
                            idValue.ID = (string)idv.Element(ns + "ID");
                            idValue.Value = (string)idv.Element(ns + "Value");
                            idValue.ID1 = (string)idv.Element(ns + "ID1");
                            idValue.ID2 = (string)idv.Element(ns + "ID2");
                            idValue.Amount = (string)idv.Element(ns + "Amount");
                            idValue.PromotionID = (string)idv.Element(ns + "PromotionID");
                            idValue.TimeStamp = (string)idv.Element(ns + "TimeStamp");
                            idValue.Type = (string)idv.Element(ns + "Type");
                            idValue.Value1 = (string)idv.Element(ns + "Value1");
                            idValue.Used = (string)idv.Element(ns + "Used");
                            idValue.WindowsUser = (string)idv.Element(ns + "WindowsUser");
                            GetInboxReply.GetInboxResult.Add(idValue);
                        }
                    }

                    return GetInboxReply;
                }
            }
        }



        public void DeleteInbox(string InboxID)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <DeleteInbox  xmlns=""http://tempuri.org/"">  
                  <InboxID>" + InboxID + @"</InboxID>  
                </DeleteInbox>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                  //  var soap = XDocument.Parse(ServiceResult);


                 //   IEnumerable<XElement> resultes = soap.Descendants(ns + "DeleteInboxResponse");




                 
                }
            }
        }



        public DataBundlesReply GetAllDataBundles(string network, string smsOrBundle)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
          <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetAllDataBundles xmlns=""http://tempuri.org/"">  
                  <smsOrBundle>" + smsOrBundle + @"</smsOrBundle>  
                  <network>" + network + @"</network>  
                </GetAllDataBundles>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                   
                 
                    var soapPr = XElement.Parse(ServiceResult);
                    XNamespace vpsvirtual = SAVIApplication.vpsvirtualwebsite;
                    var result = soapPr.Descendants(vpsvirtual + "GetProductResponseDataBundles").ToList();
                    var SmsOrBundlePackage = soapPr.Descendants(vpsvirtual + "SmsOrBundlePackage").ToList();
                    var ProductName = soapPr.Descendants(vpsvirtual + "ProductName").ToList();
                    var TSSProductBundleShortCode = soapPr.Descendants(vpsvirtual + "TSSProductBundleShortCode").ToList();
                    var TSSProductBundleName = soapPr.Descendants(vpsvirtual + "TSSProductBundleName").ToList();
                    var TSSProductBundleValue = soapPr.Descendants(vpsvirtual + "TSSProductBundleValue").ToList();
                    var TSSProductBundleMegs = soapPr.Descendants(vpsvirtual + "TSSProductBundleMegs").ToList();



                    DataBundlesReply DataBundlesReply = new DataBundlesReply();

                    DataBundlesReply.ListOfDataBundles = new List<GetProductResponseDataBundles>();

                    for (int i = 0; i < result.Count; ++i)
                    {
                    
                    
                        GetProductResponseDataBundles GetProductResponseDataBundles = new GetProductResponseDataBundles();
                        GetProductResponseDataBundles.SmsOrBundlePackage = (string)SmsOrBundlePackage[i].Value;
                        GetProductResponseDataBundles.ProductName = (string)ProductName[i].Value;
                        GetProductResponseDataBundles.TSSProductBundleShortCode = (string)TSSProductBundleShortCode[i].Value;
                        GetProductResponseDataBundles.TSSProductBundleName = (string)TSSProductBundleName[i].Value;
                        GetProductResponseDataBundles.TSSProductBundleValue = (string)TSSProductBundleValue[i].Value;
                        GetProductResponseDataBundles.TSSProductBundleMegs = (string)TSSProductBundleMegs[i].Value;

                        DataBundlesReply.ListOfDataBundles.Add(GetProductResponseDataBundles);

                     
                    }
              
                  

                
                    return DataBundlesReply;
                }
            }
        }

        public PinlessValidateReply PinlessValidate(string network,string transactionRef,string rechargeType,string msisdn,string denomination)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
          <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <PinlessValidate xmlns=""http://tempuri.org/"">  
                  <network>" + network + @"</network>  
                  <transactionRef>" + transactionRef + @"</transactionRef>  
                  <rechargeType>" + rechargeType + @"</rechargeType>  
                  <msisdn>" + msisdn + @"</msisdn>  
                  <denomination>" + denomination + @"</denomination>  
                </PinlessValidate>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "PinlessValidateResult");

                    PinlessValidateReply PinlessValidateReply = new PinlessValidateReply();


                    XNamespace vpsvirtual = SAVIApplication.vpsvirtualwebsite;
                    PinlessValidateReply.ResponseCode = resultes.Descendants(vpsvirtual + "ResponseCode").First().Value;

                    PinlessValidateReply.ResponseMessage = resultes.Descendants(vpsvirtual + "ResponseMessage").First().Value;
                    PinlessValidateReply.ServerDateTime = resultes.Descendants(vpsvirtual + "ServerDateTime").First().Value;
                   

                    return PinlessValidateReply;
                }
            }
        }


        public PinlessVendReply PinlessVend(string RegistrationID, string PaymentTypeID, string network, string transactionRef, string rechargeType,string msisdn,string denomination,string BundleName,string value)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
          <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <PinlessVend xmlns=""http://tempuri.org/"">  
                  <RegistrationID>" + RegistrationID + @"</RegistrationID>  
                  <PaymentTypeID>" + PaymentTypeID + @"</PaymentTypeID>  
                  <network>" + network + @"</network>  
                  <transactionRef>" + transactionRef + @"</transactionRef>  
                  <rechargeType>" + rechargeType + @"</rechargeType>  
                  <msisdn>" + msisdn + @"</msisdn>  
                  <denomination>" + denomination + @"</denomination>  
                  <BundleName>" + BundleName + @"</BundleName>  
                  <value>" + value + @"</value>  
                </PinlessVend>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "PinlessVendResult");

                    PinlessVendReply PinlessVendReply = new PinlessVendReply();

                    XNamespace vpsvirtual = SAVIApplication.vpsvirtualwebsite;
                    PinlessVendReply.ResponseCode = resultes.Descendants(vpsvirtual + "ResponseCode").First().Value;

                    PinlessVendReply.ResponseMessage = resultes.Descendants(vpsvirtual + "ResponseMessage").First().Value;
                    PinlessVendReply.ServerDateTime = resultes.Descendants(vpsvirtual + "ServerDateTime").First().Value;


                   
                    return PinlessVendReply;
                }
            }
        }


        public bool WriteError(string RegistrationID, string Type, string ContentData)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <WriteError xmlns=""http://tempuri.org/"">  
                  <RegistrationID>" + RegistrationID + @"</RegistrationID>  
                  <Type>" + Type + @"</Type>  
                  <ContentData>" + ContentData + @"</ContentData>  
                </WriteError>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();


                    bool ok = false;
                    if (ServiceResult.Contains("WriteErrorResponse")) ok = true; else ok = false;

                    return ok;
                }
            }
        }



        public List<ProductList> GetProductList(string type)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
          <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetProductList xmlns=""http://tempuri.org/"">  
                  <type>" + type + @"</type>  
                </GetProductList>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();


                    var soapPr = XElement.Parse(ServiceResult);
                    XNamespace vpsvirtual = SAVIApplication.vpsvirtualwebsite;
                    var result = soapPr.Descendants(vpsvirtual + "ProductList").Descendants(vpsvirtual + "ProductList").ToList();
                    //  var SmsOrBundlePackage = soapPr.Descendants(vpsvirtual + "SmsOrBundlePackage").ToList();
                    //  var ProductName = soapPr.Descendants(vpsvirtual + "ProductName").ToList();
                    //  var TSSProductBundleShortCode = soapPr.Descendants(vpsvirtual + "TSSProductBundleShortCode").ToList();
                    //  var TSSProductBundleName = soapPr.Descendants(vpsvirtual + "TSSProductBundleName").ToList();
                    //   var TSSProductBundleValue = soapPr.Descendants(vpsvirtual + "TSSProductBundleValue").ToList();
                    //   var TSSProductBundleMegs = soapPr.Descendants(vpsvirtual + "TSSProductBundleMegs").ToList();



                    List<ProductList> ProductLists = new List<ProductList>();

                   

                    for (int i = 0; i < result.Count; ++i)
                    {


                        ProductList Pro = new ProductList();
                        Pro.ProductName = (string)result[i].Element(vpsvirtual + "ProductName");
                        Pro.ProductCode = (string)result[i].Element(vpsvirtual + "ProductCode");


                        ProductLists.Add(Pro);


                    }




                    return ProductLists;
                }
            }
        }



        public TSSProductPreVendReply TSSProductPreVend(string transactionRef, string productType, string productCode, string accountNumber, string amount)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
          <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <TSSProductPreVend xmlns=""http://tempuri.org/"">  
                  <transactionRef>" + transactionRef + @"</transactionRef>  
                  <productType>" + productType + @"</productType>  
                  <productCode>" + productCode + @"</productCode>  
                  <accountNumber>" + accountNumber + @"</accountNumber>  
                  <amount>" + amount + @"</amount>  
                </TSSProductPreVend>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "TSSProductPreVendResult");

                    TSSProductPreVendReply TSSProductPreVendReply = new TSSProductPreVendReply();

                    XNamespace vpsvirtual = SAVIApplication.vpsvirtualwebsite;
                    TSSProductPreVendReply.ResponseCode = resultes.Descendants(vpsvirtual + "ResponseCode").First().Value;

                    TSSProductPreVendReply.ResponseMessage = resultes.Descendants(vpsvirtual + "ResponseMessage").First().Value;
                    TSSProductPreVendReply.ServerDateTime = resultes.Descendants(vpsvirtual + "ServerDateTime").First().Value;



                    return TSSProductPreVendReply;
                }
            }
        }


        public TSSProductPreVendReply TSSProductVend(string RegistrationID,string transactionRef, string productType, string productCode, string accountNumber, string amount, string data)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
          <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <TSSProductVend xmlns=""http://tempuri.org/"">
                  <RegistrationID>" + RegistrationID + @"</RegistrationID>
                  <transactionRef>" + transactionRef + @"</transactionRef>  
                  <productType>" + productType + @"</productType>  
                  <productCode>" + productCode + @"</productCode>  
                  <accountNumber>" + accountNumber + @"</accountNumber>  
                  <amount>" + amount + @"</amount>  
                  <data>" + data + @"</data>
                </TSSProductVend>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "TSSProductVendResult");

                    TSSProductPreVendReply TSSProductPreVendReply = new TSSProductPreVendReply();

                    XNamespace vpsvirtual = SAVIApplication.vpsvirtualwebsite;
                    TSSProductPreVendReply.ResponseCode = resultes.Descendants(vpsvirtual + "ResponseCode").First().Value;

                    TSSProductPreVendReply.ResponseMessage = resultes.Descendants(vpsvirtual + "ResponseMessage").First().Value;
                    TSSProductPreVendReply.ServerDateTime = resultes.Descendants(vpsvirtual + "ServerDateTime").First().Value;



                    return TSSProductPreVendReply;
                }
            }
        }

        public GeteWalletParmsReply GeteWalletParms()
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GeteWalletParms  xmlns=""http://tempuri.org/""/>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GeteWalletParmsResult");
                    GeteWalletParmsReply GeteWalletParmsReply = new GeteWalletParmsReply();

                    GeteWalletParmsReply.GeteWalletParmsResult = new IdValue();
                    foreach (XElement result in resultes)
                    {

                            IdValue idValue = new IdValue();
                            idValue.ID = (string)result.Element(ns + "ID");
                            idValue.Value = (string)result.Element(ns + "Value");
                            idValue.ID1 = (string)result.Element(ns + "ID1");
                            idValue.ID2 = (string)result.Element(ns + "ID2");
                            idValue.Amount = (string)result.Element(ns + "Amount");
                            idValue.PromotionID = (string)result.Element(ns + "PromotionID");
                            idValue.TimeStamp = (string)result.Element(ns + "TimeStamp");
                            idValue.Type = (string)result.Element(ns + "Type");
                            idValue.Value1 = (string)result.Element(ns + "Value1");
                            idValue.Used = (string)result.Element(ns + "Used");
                            idValue.WindowsUser = (string)result.Element(ns + "WindowsUser");
                            GeteWalletParmsReply.GeteWalletParmsResult = idValue;
                       
                    }

                    return GeteWalletParmsReply;
                }
            }
        }

        public int GeteWalletBalance(string RegistrationID, string year, string month)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetCompnyID  xmlns=""http://tempuri.org/"">  
                  <RegistrationID>" + RegistrationID + @"</RegistrationID>  
                  <year>" + year + @"</year>  
                  <month>" + month + @"</month>  
                </GetCompnyID>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GeteWalletBalanceResponse");

                    int GeteWalletBalanceResult = 0;

                    foreach (XElement result in resultes)
                    {
                        GeteWalletBalanceResult = (int)result.Element(ns + "GeteWalletBalanceResult");

                    }


                    return GeteWalletBalanceResult;
                }
            }
        }


        public bool EFTPay(string RegistrationID, string PaymentTypeID, string Amount, string MSISDN, string Details)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <EFTPay xmlns=""http://tempuri.org/"">  
                  <RegistrationID>" + RegistrationID + @"</RegistrationID>  
                  <PaymentTypeID>" + PaymentTypeID + @"</PaymentTypeID>  
                  <Amount>" + Amount + @"</Amount>  
                  <MSISDN>" + MSISDN + @"</MSISDN>
                  <Details>" + Details + @"</Details>
                </EFTPay>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);

                    IEnumerable<XElement> resultes = soap.Descendants(ns + "EFTPayResponse");

                    bool EFTPayResult = false ;

                    foreach (XElement result in resultes)
                    {
                        EFTPayResult = (bool)result.Element(ns + "EFTPayResult");

                    }

                  

                    return EFTPayResult;
                }
            }
        }

        public int RegisterV2( string CompanyTradingName, string Name, string Surname, string IdType, string IdNumber, string ContactNumber, string ContactEmail, string StoreID, string Username, string Password, string Title, string Middlename)
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <RegisterV2 xmlns=""http://tempuri.org/"">  
                  <CompanyTradingName>" + CompanyTradingName + @"</CompanyTradingName>  
                  <Name>" + Name + @"</Name>  
                  <Surname>" + Surname + @"</Surname>  
                  <IdType>" + IdType + @"</IdType>  
                  <IdNumber>" + IdNumber + @"</IdNumber>  
                  <ContactNumber>" + ContactNumber + @"</ContactNumber>  
                  <ContactEmail>" + ContactEmail + @"</ContactEmail>
                  <StoreID>" + StoreID + @"</StoreID>
                  <Username>" + Username + @"</Username>
                  <Password>" + Password + @"</Password>
                  <Title>" + Title + @"</Title>
                  <Middlename>" + Middlename + @"</Middlename>
                </RegisterV2>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);
                    IEnumerable<XElement> resultes = soap.Descendants(ns + "RegisterV2Response");

                    int RegisterV2Result = 0;

                    foreach (XElement result in resultes)
                    {
                        RegisterV2Result = (int)result.Element(ns + "RegisterV2Result");

                    }

                  

                    return RegisterV2Result;
                }
            }
        }

        public string GetMobileBannersCurrentVersion()
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetMobileBannersCurrentVersion xmlns=""http://tempuri.org/""/>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "GetMobileBannersCurrentVersionResult");
                    string version = string.Empty;
                    foreach (XElement result in resultes)
                    {

                     
                        version = (string)result.Element(ns + "Version");
                       
                     

                    }

                    return version;
                }
            }
        }

        public List<MobileBanner> GetMobileBanners()
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
             <soap:Body>  
                <GetMobileBanners xmlns=""http://tempuri.org/""/>  
              </soap:Body>  
            </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //// begin async call to web request.
            //IAsyncResult asyncResult = request.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();
            //Geting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    var soap = XDocument.Parse(ServiceResult);


                    IEnumerable<XElement> resultes = soap.Descendants(ns + "MobileBanners");
                    List<MobileBanner> mobileBanners = new List<MobileBanner>();
                    foreach (XElement result in resultes)
                    {

                        MobileBanner mobileBanner = new MobileBanner();
                        mobileBanner.ID = (string)result.Element(ns + "ID");
                        mobileBanner.Image = (string)result.Element(ns + "Image");
                        mobileBanner.Order = (string)result.Element(ns + "Order");

                        mobileBanners.Add(mobileBanner);

                    }

                    return mobileBanners;
                }
            }
        }
    }
}
