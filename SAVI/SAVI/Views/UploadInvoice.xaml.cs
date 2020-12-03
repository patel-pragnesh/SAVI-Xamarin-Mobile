using Demo.Pages;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Toast;
using Rg.Plugins.Popup.Services;
using SAVI.com.celcom.savi;
using SAVI.CustomControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAVI.Views
{
 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadInvoice : ContentPage
    {
        
        public string filePath { get; set; }
        public MediaFile ImageFile { get; set; }
        public UploadInvoice()
        {
            InitializeComponent();
           // NavigationPage.SetHasNavigationBar(this, false);
        }

        [Obsolete]
        private async void Button_Clicked(object sender, EventArgs e)
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

                if (status ==PermissionStatus.Granted && statusStorage == PermissionStatus.Granted)
                {
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        //await DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
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
                        PhotoImage.Source = ImageSource.FromStream(() => { return file.GetStream(); });
                        filePath = file.Path;
                        ImageFile = file;
                    }

                    //using (var memoryStream = new MemoryStream())
                    //{
                    //  file.GetStream().CopyTo(memoryStream);
                    //  var myfile = memoryStream.ToArray();
                    //  mysfile = myfile;
                    //}

                    //PhotoIDImage.Source = ImageSource.FromFile(file.Path);

                  //  await DisplayAlert("File Location", file.Path, "OK");

                    // files.Add(file);
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Camera Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {

               // await DisplayAlert("Error", "Camera Not Available", "OK");
            }

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filePath) || ImageFile == null)
            {
                //  await DisplayAlert("", "No Image", "OK");
                CrossToastPopUp.Current.ShowToastMessage("No Image");
                return;
            }

            string invoice = string.Empty;
            if (!string.IsNullOrWhiteSpace(editInvoiceNumber.Text))
            {
                invoice = editInvoiceNumber.Text.Trim().ToUpper();



            }
            else
            {

                //  await DisplayAlert("", "Please enter invoice number!", "OK");
                CrossToastPopUp.Current.ShowToastMessage("Please enter invoice number!");
                return;
            }



    var stream = ImageFile.GetStream();
            var bytes = new byte[stream.Length];

            byte[] mysfile;
            using (var memoryStream = new MemoryStream())
            {
                ImageFile.GetStream().CopyTo(memoryStream);
                var myfile = memoryStream.ToArray();
                mysfile = myfile;
               
            }

            byte[] resizedImage = DependencyService.Get<IImageService>().ResizeTheImage(mysfile, 1024, 768);

            mysfile = resizedImage;


            string base64 = System.Convert.ToBase64String(mysfile);

          string StoreId =  App.SoapService.GetStoreID(SAVIApplication.mRegistrationID.ToString()).GetStoreIDResult;

        string result=  App.SoapService.UpdateInvoiceNew(base64, invoice, StoreId, "PNG", "false");
            if (result.ToUpper()=="SUCCESS")
            {
               await  Application.Current.MainPage.Navigation.PopAsync(); //Remove the page currently on top.
                CrossToastPopUp.Current.ShowToastMessage("Upload invoice is succesfull!");
            }
            else
            {
                var pageMessage = new ShowMessagePopupPage(result);
                await PopupNavigation.Instance.PushAsync(pageMessage);
            }
        }

    
    }
}