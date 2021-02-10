using Demo.Pages;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Toast;
using Rg.Plugins.Popup.Services;
using SAVI.com.celcom.savi;
using SAVI.com.celcom.savi.common;
using SAVI.CustomControl;
using SAVI.Models;
using SAVI.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;
using PermissionStatus = Plugin.Permissions.Abstractions.PermissionStatus;

namespace SAVI
{
    public enum TextRecognitionLevelEnum
    {
        Accurate = 0,
        Fast = 1
    }
  
    public partial class CameraVisionPage : ContentPage
    {
        public string filePath { get; set; }
        public MediaFile ImageFile { get; set; }
        public Action ShowDocumentViewController;
        public Action CancelDocumentViewController;
        public Action ShowBarcodeDocumentViewController;
        public TextRecognitionLevelEnum TextRecognitionLevel;
        List<String> UniqueBarcode;
        private List<string> listString;
        private bool AutoValidated;
        private string Imagebase64 = string.Empty;
        private List<RecognizedTextItem> _itemList;
        public List<RecognizedTextItem> ItemList
        {
            get { return _itemList; }
            set { _itemList = value; OnPropertyChanged(); }
        }

        int Counter = 0;
        String String1 = "TAX";
        String String2 = "INVOICE";
        String String3 = "BALANCE";
        String String4 = "TOTAL";
        String String5 = "TENDER";

        int counter1 = 0;
        int counter2 = 0;
        int counter3 = 0;
        int counter4 = 0;
        int counter5 = 0;
        int countermBarcode = 0;
        int counterinvoice = 0;
        bool InvExistance = false;

        bool barCodeExistance;

      
        List<string> fruit;
        bool atleastonehitimgbutton = false;
        GetPromotionByIDReply mProm;


        private string _recognizedCode;

        public string RecognizedCode
        {
            get
            {
                return (_recognizedCode == null) ? "" : "Code scanned: " + _recognizedCode;
            }

            set
            {
                _recognizedCode = value;
                OnPropertyChanged(nameof(RecognizedCode));
            }
        }

        //protected override  void OnAppearing()
        //{
        //    base.OnAppearing();
        //    //if (Connectivity.NetworkAccess != NetworkAccess.Internet)
        //    //{
        //    //    await DisplayAlert("WARNING!", "Error message!", "OK");
        //    //    await Navigation.PopModalAsync();
        //    //}
        //    //else
        //    //{

        //    //    //...

        //    //}

        //    //editProductNumber CrossToastPopUp.Current.ShowToastMessage(Globals.barcodeResult);

        //    editProductNumber.Text = Globals.barcodeResult;
        //    Globals.barcodeResult = string.Empty;
        //}
        public CameraVisionPage()
        {
            this.BindingContext = this;
             counter1 = 0;
             counter2 = 0;
             counter3 = 0;
             counter4 = 0;
             counter5 = 0;
             countermBarcode = 0;
             counterinvoice = 0;
             InvExistance = false;

             barCodeExistance = false;
            ItemList = new List<RecognizedTextItem>();
            listString = new List<string>();
            fruit = new List<string>();
            UniqueBarcode = new List<string>();
            AutoValidated = false;
            InitializeComponent();

            textSteptwo.IsVisible = false;
            btnClaim.IsVisible = false;
            buttonClaimAutoVerify.IsEnabled = false;
            buttonClaimAutoVerify.IsVisible = false;
            buttonClaimManual.IsEnabled = false;
            buttonClaimManual.IsVisible = false;
            editInvoice.IsVisible = false;
            imageButton5.IsEnabled = false;
            imageButton5.IsVisible = false;
            img.IsVisible = false;
            dataGrid.IsVisible = false;
            SAVIApplication.mProds = new List<ValidateBarcodeReply>();
            setheader();
          


    }

       

        private async void ScanBarcodeClicked(object sender, EventArgs e)
        {

            if (Device.RuntimePlatform == Device.iOS)
            {
                
                ShowBarcodeDocumentViewController.Invoke();
            }
            //await ScanditService.BarcodePicker.StartScanningAsync(false);


            //var scanner = DependencyService.Get<IQrCodeScanningService>();//ios
            //var result = await scanner.ScanAsync();
            //if (result != null)
            //    editProductNumber.Text = result;


            //scanPage = new ZXingScannerPage(new MobileBarcodeScanningOptions()
            //{
            //    AutoRotate = false,
            //    TryInverted = true,
            //    TryHarder = true,
            //});

            if (Device.RuntimePlatform == Device.Android)
            {

                var scanPage = new ZXingScannerPage
                {
                    Title = "Scanning...",
                    BackgroundColor = Color.FromHex("#212223")
                };

                await App.Current.MainPage.Navigation.PushAsync(scanPage);
                scanPage.OnScanResult += (result) =>
                {
                    scanPage.IsScanning = false;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                    // await Navigation.PopModalAsync();
                    await App.Current.MainPage.Navigation.PopAsync();
                        editProductNumber.Text = result.Text;

                        if (editProductNumber.Text != null)
                        {
                            addmProd();
                        }
                    });
                };
                //await Navigation.PushModalAsync(scanPage);
            }
        }


        private  void AddClicked(object sender, EventArgs e)
        {
            if (editProductNumber.Text == null)
            {

                CrossToastPopUp.Current.ShowToastMessage("Please enter a barcode");
                return;
            }
            if (editProductNumber.Text.Trim().Length < 2)
            {

                CrossToastPopUp.Current.ShowToastMessage("Please enter a barcode");
                return;
            }

            addmProd();
        }
            private  void ClaimClicked(object sender, EventArgs e)
        {
            if (btnClaim.Text != "Clear to restart")
            {
                if (SAVIApplication.mProds.Count > 0) {
                    dataGrid.IsVisible = true;
                    editProductNumber.IsVisible = false;
                imageScan.IsVisible = true;
                btnScanI.IsVisible = false;
                editInvoice.IsVisible = true;
                editInvoice.Focus();
                img.IsEnabled = true;
                img.IsVisible = true;
                btnClaim.Text = "Clear to restart";
                textSteptwo.IsVisible = true;

                    // await Navigation.PopModalAsync();

                     DisplayAlert("", "Barcodes added, please capture invoice number.", "OK");

                 //   CrossToastPopUp.Current.ShowToastMessage("Barcodes added, please capture invoice number.");

                  /// var pageMessage = new ShowMessagePopupPage("Barcodes added, please capture invoice number.");
                    //PopupNavigation.Instance.PushAsync(pageMessage);
                    return;
                }
            }
            else
            {

                if (btnClaim.Text == "Clear to restart")
                {
                    SAVIApplication.mProds.Clear();
                    UniqueBarcode.Clear();
                    for (int i = 0; i < dataGrid.Children.Count(); ++i)
                        dataGrid.Children.RemoveAt(i);

                    dataGrid.IsVisible = false;
                    textSteptwo.IsVisible = false;

                    editProductNumber.IsVisible = true;
                    imageScan.IsVisible = false;
                    btnScanI.IsVisible = true;
                    editInvoice.IsVisible = false;

                    img.IsEnabled = false;
                    img.IsVisible = false;
                    buttonClaimManual.IsVisible = false;
                    buttonClaimAutoVerify.IsVisible = false;
                    btnClaim.IsVisible = false;
                    btnClaim.Text = "Verify Barcodes";
                    //    Navigation.PopModalAsync();
                    //CrossToastPopUp.Current.ShowToastMessage("Barcodes added, please capture invoice number.");
                   //   DisplayAlert("", "Barcodes added, please capture invoice number.", "OK");

                //    CrossToastPopUp.Current.ShowToastMessage("Barcodes added, please capture invoice number.");
                  //  var pageMessage = new ShowMessagePopupPage("Barcodes added, please capture invoice number.");
                    //PopupNavigation.Instance.PushAsync(pageMessage);
                    return;
                }
            }
        }

        

        private  async void buttonClaimManualClicked(object sender, EventArgs e)
        {
            if (editInvoice.Text == null)
            {
                
                CrossToastPopUp.Current.ShowToastMessage("Please enter the invoice number");
                return;
            }
            if (editInvoice.Text.Trim().Length < 2)
            {
              
                CrossToastPopUp.Current.ShowToastMessage("Please enter the invoice number");
                return;
            }

            bool answer = await DisplayAlert("", "Do you want to proceed?", "OK", "Cancel");
            if (answer)
            {
                continueclaim(false);

            }
            return;

        }
        private async  void buttonAutoVerifyClicked(object sender, EventArgs e)
        {
            if (editInvoice.Text == null)
            {
                CrossToastPopUp.Current.ShowToastMessage("Please enter the invoice number");
                return;
            }
            if (editInvoice.Text.Trim().Length < 2)
            {
                CrossToastPopUp.Current.ShowToastMessage("Please enter the invoice number");
                return;
            }
            if (!atleastonehitimgbutton)
            {
                CrossToastPopUp.Current.ShowToastMessage("Please scan your invoice document!");
                return;
            }
            if (SAVIApplication.mProds.Count<1)
            {
                CrossToastPopUp.Current.ShowToastMessage("There is not any Product in the list!");
                return;
            }

            bool answer = await DisplayAlert("", "Do you want to proceed?", "OK", "cancel");
            if (answer)
            {
                continueclaim(true);

            }
            return;

         
        }
        private async void continueclaim(bool autovalidation)
        {
             String name = "N/A";
             String surname = "N/A";
             String number = "N/A";
             String email = "N/A";
            long StoreID = 0;
            StoreID =SAVIApplication.mStoreID;
            if (StoreID < 1)
            {
                StoreID = 1;
            }

            List<Basket> baskets = new List<Basket>();
            double val = 0;
            for (int i = 0; i < SAVIApplication.mProds.Count; i++)
            {
            
                    val += Double.Parse(SAVIApplication.mProds[i].RetailValue, CultureInfo.InvariantCulture);

                Basket b = new Basket();
                b.PromotionProductID=SAVIApplication.mProds[i].PromotionProductID;

                b.ImeiID="0";

                b.StoreRep= Preferences.Get(Globals.REP_NAME, "");

                b.StoreRepMSISDN = Preferences.Get(Globals.REP_MSISDN, "");
                b.StoreName="";

                b.VoucherID= SAVIApplication.mProds[i].VoucherID;

                b.SubmittedDeviceLocationLatitude= SAVIApplication.mLatitude.ToString();
                b.SubmittedDeviceLocationLongitude = SAVIApplication.mLongitude.ToString();
                b.RedemtionDate = DateTime.Now.ToString();

                b.RedemptionID="0";
                b.NoStock="false";

                b.StoreID = "0";
                b.CompanyID = "0";

                b.InvoiceID = "0";

                baskets.Add(b);
            }
           // SAVIApplication.mProds.Clear();
            UniqueBarcode.Clear();

            string result = App.SoapService.CaptureMobilityBasketCustomer(baskets, editInvoice.Text.Trim().ToUpper(), SAVIApplication.mRegistrationID.ToString(), name, surname, number, email, "--", "--", "--", "--", "--", "--");
            if (!string.IsNullOrWhiteSpace(result)) {
                if (Convert.ToInt64(result)>=0)
                {
                    if (!string.IsNullOrWhiteSpace(Imagebase64)) {
                      string resultUpload=  App.SoapService.UpdateInvoiceNew(Imagebase64, editInvoice.Text.Trim().ToUpper(),StoreID.ToString(),"PNG", autovalidation.ToString().ToLower());

                        if (string.IsNullOrWhiteSpace(resultUpload))
                        {
                         //   CrossToastPopUp.Current.ShowToastMessage("Upload of invoice failed but the claim was successful. Please use the Upload Invoice option to upload the invoice.");
                            var pageMessage = new ShowMessagePopupPage("Upload of invoice failed but the claim was successful. Please use the Upload Invoice option to upload the invoice.");
                          await  PopupNavigation.Instance.PushAsync(pageMessage);

                            return;
                        }

                        /* else if (resultUpload == "Upload failed as the Store is the wrong store.")
                          {
                              CrossToastPopUp.Current.ShowToastMessage(resultUpload);
                          }*/
                        else if (resultUpload.ToUpper() != "SUCCESS")
                        {
                           // CrossToastPopUp.Current.ShowToastMessage(resultUpload);
                            var pageMessage = new ShowMessagePopupPage(resultUpload);
                          await  PopupNavigation.Instance.PushAsync(pageMessage);

                            return;
                        }
                        else
                        {
                            if (resultUpload.ToUpper() == "SUCCESS")
                            {
                                SAVIApplication.mProds.Clear();
                                if (mProm != null)
                                {
                                    double v = Convert.ToDouble(mProm.BelowThreshold);

                                    if (val >= Convert.ToDouble(mProm.Threshold))
                                    {
                                        v = Convert.ToDouble(mProm.AboveThreshold);
                                    }

                                    if (AutoValidated)
                                    {
                                        var pageMessage = new ShowMessagePopupPage("Congratulations you have receive R" + v + " Commission, Please remember to upsell to get greater commissions");
                                       await PopupNavigation.Instance.PushAsync(pageMessage);
                                        //    CrossToastPopUp.Current.ShowToastMessage("Congratulations you have receive R" + v + " Commission, Please remember to upsell to get greater commissions");
                                    }
                                    else
                                    {
                                        var pageMessage = new ShowMessagePopupPage("Congratulations you will receive R" + v + " Commission once verified all is correct by our team, Please remember to upsell to get greater commissions");
                                       await PopupNavigation.Instance.PushAsync(pageMessage);

                                        //    CrossToastPopUp.Current.ShowToastMessage("Congratulations you will receive R" + v + " Commission once verified all is correct by our team, Please remember to upsell to get greater commissions");
                                    }
                                    //CancelDocumentViewController.Invoke();
                                   await this.Navigation.PopAsync();
                                    await Navigation.PushAsync(new Main());
                                    return;
                                }
                            }
                        }
                    }
                }
                    
                        
            }
        }
            [Obsolete]
        private async void CameraClicked(object sender, EventArgs e)
        {
             InvExistance = false;

             barCodeExistance = false;
             countermBarcode = 0;
             counterinvoice = 0;
             counter1 = 0;
             counter2 = 0;
             counter3 = 0;
             counter4 = 0;
             counter5 = 0;

            buttonClaimAutoVerify.IsEnabled = false;
            buttonClaimAutoVerify.IsVisible = false;
            buttonClaimManual.IsEnabled = false;
            buttonClaimManual.IsVisible = false;
            if (editInvoice.Text == null)
            {
                await DisplayAlert("", "Please enter the invoice number", "OK");
                return;
            }
            if (editInvoice.Text.Trim().Length < 2)
            {
                await DisplayAlert("", "Please enter the invoice number", "OK");
                return;
            }
            atleastonehitimgbutton = true;


            if (Device.RuntimePlatform == Device.iOS)
            {
                //  string recognitionLevel = await DisplayActionSheet("Select Recognition Level", "Cancel", null, new string[] { "Accurate", "Fast" });
                string recognitionLevel = "Accurate";
                TextRecognitionLevel = (TextRecognitionLevelEnum)Enum.Parse(typeof(TextRecognitionLevelEnum), recognitionLevel);

                ShowDocumentViewController.Invoke();
            }
            if (Device.RuntimePlatform == Device.Android)
            {

                try
                {
                    var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                    if (status != PermissionStatus.Granted)
                    {
                        if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                        {
                            //awat DisplayAlert("Camera Permission", "Allow to access your camera", "OK");
                        }
                        var result = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
                        status = result[Permission.Camera];
                    }
                    var statusStorage = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                    if (statusStorage != PermissionStatus.Granted)
                    {
                        if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                        {
                            //awat DisplayAlert("Camera Permission", "Allow to access your camera", "OK");
                        }
                        var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Storage });
                        statusStorage = results[Permission.Storage];
                    }

                    if (status == PermissionStatus.Granted && statusStorage == PermissionStatus.Granted)
                    {
                        await CrossMedia.Current.Initialize();

                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            //await DisplayAlert("No Camera", ":( No camera available.", "OK");
                            return;
                        }
                        
                        var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            PhotoSize = PhotoSize.MaxWidthHeight,
                            Directory = "Sample",
                            Name = "test.jpg",
                            SaveToAlbum = true,
                            MaxWidthHeight = 2000
                        });

                        if (file == null)
                            return;


                        if (file != null)
                        {
                            //PhotoImage.Source = ImageSource.FromStream(() => { return file.GetStream(); });
                            filePath = file.Path;
                            ImageFile = file;
                          
                            listString.Clear();
                            listString =  DependencyService.Get<Iocr>().ShowAndroid(ImageFile.GetStream());
                      
                            var stream = file.GetStream();
                            var bytes = new byte[stream.Length];
                            await stream.ReadAsync(bytes, 0, (int)stream.Length);

                            byte[] resizedImage = DependencyService.Get<IImageService>().ResizeTheImage(bytes, 1024, 768);

                            Imagebase64 = System.Convert.ToBase64String(resizedImage);
                           
                         


                            var pageLoading = new LoadingPopupPage();
                            await PopupNavigation.Instance.PushAsync(pageLoading);
                            logExtrasForTesting(listString);
                            pageLoading.CloseMe();
                            imageScan.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
                            return;
                        }

                       

                        //PhotoIDImage.Source = ImageSource.FromFile(file.Path);

                        //  await DisplayAlert("File Location", file.Path, "OK");

                        // files.Add(file);


                       

                    }
                    else if (status != PermissionStatus.Unknown)
                    {
                        await DisplayAlert("Camera Denied", "Can not continue, try again.", "OK");
                        return;
                    }
                }
                catch (Exception ex)
                {

                    // await DisplayAlert("Error", "Camera Not Available", "OK");
                }




               
            }
        }
        private async void logExtrasForTesting(List<string> listString)
        {
            if (editInvoice.Text == null)
            {

                CrossToastPopUp.Current.ShowToastMessage("Please enter the invoice number");
                return;
            }
            if (editInvoice.Text.Trim().Length < 2)
            {

                CrossToastPopUp.Current.ShowToastMessage("Please enter the invoice number");
                return;
            }
           // var pageLoading = new LoadingPopupPage();
         //   await PopupNavigation.Instance.PushAsync(pageLoading);

            fruit = new List<string>();
            fruit.Add(editInvoice.Text.Trim().ToUpper());
            fruit.Add(String1);
            fruit.Add(String2);
            fruit.Add(String3);
            fruit.Add(String4);
            fruit.Add(String5);
            if (listString != null)
            {
                for (int k = 0; k < listString.Count(); ++k)
                {
                    for (int mp = 0; mp < UniqueBarcode.Count(); mp++)
                    {

                        if (listString[k].ToUpper().Contains(UniqueBarcode[mp].ToUpper())) countermBarcode++;

                    }

                    foreach (var s in fruit)
                    {
                        if (listString[k].ToUpper().Contains(s.ToUpper()))
                        {

                            if (s.ToUpper().Contains(editInvoice.Text.Trim().ToUpper()) && counterinvoice == 0)
                            {
                                InvExistance = true; counterinvoice++;
                                Counter++;
                            }
                            if (s.ToUpper().Contains(String1) && counter1 == 0)
                            {
                                counter1++;
                                Counter++;
                            }
                            if (s.ToUpper().Contains(String2) && counter2 == 0)
                            {
                                counter2++;
                                Counter++;
                            }
                            if (s.ToUpper().Contains(String3) && counter3 == 0)
                            {
                                counter3++;
                                Counter++;
                            }
                            if (s.ToUpper().Contains(String4) && counter4 == 0)
                            {
                                counter3++;
                                Counter++;
                            }
                            if (s.ToUpper().Contains(String5) && counter5 == 0)
                            {
                                counter5++;
                                Counter++;
                            }

                        }
                    }

                }
                if (countermBarcode == SAVIApplication.mProds.Count()) barCodeExistance = true;
                if (Counter >= 3 && InvExistance && barCodeExistance)
                {
                    AutoValidated = true;
                    buttonClaimAutoVerify.IsEnabled = true;
                    buttonClaimAutoVerify.IsVisible = true;
                    buttonClaimManual.IsEnabled = false;
                    buttonClaimManual.IsVisible = false;
                    editInvoice.IsVisible = false;
                    img.IsVisible = false;
                    btnScanI.IsVisible = false;

                    await DisplayAlert("", "Claim successfully validated, please submit your claim.", "OK");

                  
                    return;
                }
                else
                {
                    AutoValidated = false;

                    buttonClaimAutoVerify.IsEnabled = false;
                    buttonClaimAutoVerify.IsVisible = false;
                    buttonClaimManual.IsEnabled = true;
                    buttonClaimManual.IsVisible = true;
                    editInvoice.IsVisible = true;
                    img.IsVisible = true;
                    btnScanI.IsVisible = true;
                    string messageDiolgue = string.Empty;
                    if (barCodeExistance && !InvExistance)  messageDiolgue = "Invoice number is not found. Barcode(s) is/are found. Your claim was not successfully validated, please submit for manual verification or take a photo of your invoice again.";
                    if (!barCodeExistance && InvExistance) messageDiolgue = "Invoice number is found and One/more Barcode(s) is/are not found. Your claim was not successfully validated, please submit for manual verification or take a photo of your invoice again.";
                    if (barCodeExistance && InvExistance) messageDiolgue = "Invoice number and barcode(s) are found but your claim was not successfully validated, please submit for manual verification or take a photo of your invoice again.";
                    if (!barCodeExistance && !InvExistance) messageDiolgue = "Invoice number and barcode(s) are not found and  your claim was not successfully validated, please submit for manual verification or take a photo of your invoice again.";
                    bool answer = await DisplayAlert("", messageDiolgue, "Manual Submit", "Cancel");
                    if (answer)
                    {
                        continueclaim(AutoValidated);
                        
                    }
                    else
                    {
                      
                      



                        SAVIApplication.mProds.Clear();
                        UniqueBarcode.Clear();
                        for (int i = 0; i < dataGrid.Children.Count(); ++i)
                            dataGrid.Children.RemoveAt(i);

                        dataGrid.IsVisible = false;
                        textSteptwo.IsVisible = false;

                        editProductNumber.IsVisible = true;
                        imageScan.IsVisible = false;
                        btnScanI.IsVisible = true;
                        editInvoice.IsVisible = false;

                        img.IsEnabled = false;
                        img.IsVisible = false;
                        buttonClaimManual.IsVisible = false;
                        buttonClaimAutoVerify.IsVisible = false;
                        btnClaim.IsVisible = false;
                        btnClaim.Text = "Verify Barcodes";

                    }
                    return;
                        
                }
            }
            else
            {
                AutoValidated = false;


                buttonClaimAutoVerify.IsEnabled = false;
                buttonClaimAutoVerify.IsVisible = false;
                buttonClaimManual.IsEnabled = true;
                buttonClaimManual.IsVisible = true;
                btnScanI.IsVisible = true;
                editInvoice.IsVisible = true;
                img.IsVisible = true;


              //  CrossToastPopUp.Current.ShowToastMessage("It could not find any text at image");
                await DisplayAlert("", "It could not find any text at image", "OK");
                return;
            }
          //  pageLoading.CloseMe();

        }
        public async void LoadRecognizedTextItems(List<List<string>> items, string base64Image) //iOS
        {
            var pageLoading = new LoadingPopupPage();
            await PopupNavigation.Instance.PushAsync(pageLoading);
            Imagebase64 = base64Image;
            InvExistance = false;

            barCodeExistance = false;
            countermBarcode = 0;
            counterinvoice = 0;
            counter1 = 0;
            counter2 = 0;
            counter3 = 0;
            counter4 = 0;
            counter5 = 0;


           



            var itemList = items.Select(item => new RecognizedTextItem(item));
            ItemList = new List<RecognizedTextItem>(itemList);

            listString.Clear();
            for (int i=0;i<ItemList.Count();++i)
            {
                listString.Add(ItemList[i].TopCandidate);
            }
            //if (editProductNumber.Text != null)
            {
                //if (!string.IsNullOrWhiteSpace(editProductNumber.Text))
                {


                    logExtrasForTesting(listString);


                }
            }
            pageLoading.CloseMe();

        }



        void addproducts()
        {
         //   dataGrid.IsVisible = false;
            //for (int i = 0; i < dataGrid.Children.Count(); ++i)
                //dataGrid.Children.RemoveAt(i);
            dataGrid.Children.Clear();

          //  dataGrid.IsVisible = true;

            if (SAVIApplication.mProds.Count() > 0) { dataGrid.IsVisible = true; btnClaim.IsVisible = true; }
          
            dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40, GridUnitType.Absolute) });

            for (int i = 0; i < SAVIApplication.mProds.Count; i++)
            {



                var imageButton = new ImageButton
                {
                    Source = "x50.png",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                    CommandParameter = i.ToString()

                };
                imageButton.Clicked += OnImageButtonClicked;
                dataGrid.Children.Add(imageButton, 0, i);

            }

            dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1000, GridUnitType.Absolute) });
            for (int i = 0; i < SAVIApplication.mProds.Count; i++)
            {



                var label1 = new Label
                {
                    TextColor = Color.Black,
                    Text = "  ",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start
                };
                dataGrid.Children.Add(label1, 0, i);
                label1 = new Label
                {
                    TextColor = Color.Black,
                    Text = SAVIApplication.mProds[i].Barcode + "\r\n" + SAVIApplication.mProds[i].Description,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start
                };
                dataGrid.Children.Add(label1, 1, i);
            }

        }
        void OnImageButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var imageButton = sender as ImageButton;
                string theValue = imageButton.CommandParameter.ToString();
                //CrossToastPopUp.Current.ShowToastError(theValue, Plugin.Toast.Abstractions.ToastLength.Long);
                int thevalueInt = Convert.ToInt32(theValue);
                SAVIApplication.mProds.RemoveAt(thevalueInt);
                addproducts();
                //header
            }
            catch
            {

            }
        }
        public void addmProd()
        {
            if (!string.IsNullOrWhiteSpace(editProductNumber.Text))
            {

                ValidVoucherAndPromotion2Reply validVoucherAndPromotion2Reply = App.SoapService.ValidVoucherAndPromotion2(editProductNumber.Text.Trim().ToUpper(), "false");
                if (validVoucherAndPromotion2Reply.IdValue.Value.StartsWith("Voucher Activated"))
                {

                    ValidateBarcodeReply validateBarcodeReply = App.SoapService.ValidateBarcode(editProductNumber.Text.Trim().ToUpper(), validVoucherAndPromotion2Reply.IdValue.PromotionID);
                    if (validateBarcodeReply != null)
                    {

                        bool existU = false;
                        for (int i = 0; i < UniqueBarcode.Count(); i++
                        )
                        {
                            if (UniqueBarcode[i] == editProductNumber.Text.Trim().ToUpper()) existU = true;

                        }
                        if (!existU)
                        {
                            UniqueBarcode.Add(editProductNumber.Text.Trim().ToUpper());
                        }
                        editProductNumber.Text = string.Empty;

                        if (mProm == null) 
                            mProm = App.SoapService.GetPromotionByID(validVoucherAndPromotion2Reply.IdValue.PromotionID);
                        validateBarcodeReply.PromotionID = validVoucherAndPromotion2Reply.IdValue.PromotionID;
                        validateBarcodeReply.VoucherID = validVoucherAndPromotion2Reply.IdValue.ID1;
                        SAVIApplication.mProds.Add(validateBarcodeReply);
                        addproducts();
                    }
                  



                }
                else
                {
                    editProductNumber.Text = string.Empty;
                   // CrossToastPopUp.Current.ShowToastError(validVoucherAndPromotion2Reply.IdValue.Value, Plugin.Toast.Abstractions.ToastLength.Long);

                    var pageMessage = new ShowMessagePopupPage(validVoucherAndPromotion2Reply.IdValue.Value);
                    PopupNavigation.Instance.PushAsync(pageMessage);

                    try
                    {
                        CancelDocumentViewController.Invoke();
                    }
                    catch { }

                }
            }
        }



        private void setheader()
        {


            dataGridHeader.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });
            dataGridHeader.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40, GridUnitType.Absolute) });
            dataGridHeader.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1000, GridUnitType.Absolute) });
            var label = new Label
            {
                Text = "  ",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 0, 0);
            label = new Label
            {
                Text = "Accessory",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start
            };
            dataGridHeader.Children.Add(label, 1, 0);
        }

        private void editProductNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (editProductNumber.Text.Trim().Length >= 1 && !imageButton5.IsEnabled)
            {
                imageButton5.IsEnabled = true;
                imageButton5.IsVisible = true;
            }
            if (editProductNumber.Text.Trim().Length < 1)
            {
                imageButton5.IsEnabled = false;
                imageButton5.IsVisible = false;
            }

        }
    }
}
