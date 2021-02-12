using System;
using System.Collections.Generic;

using Foundation;
using Vision;
using VisionKit;
using CoreFoundation;

using SAVI;
using SAVI.iOS.Renderers;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SAVI.CustomControl;
using UIKit;
using AVFoundation;
using SAVI.com.celcom.savi.common;
using Demo.Pages;
using Rg.Plugins.Popup.Services;
using System.IO;

[assembly: ExportRenderer(typeof(CameraVisionPage), typeof(CameraVisionRenderer))]
namespace SAVI.iOS.Renderers
{
    public class CameraVisionRenderer : PageRenderer, IVNDocumentCameraViewControllerDelegate
    {
        CameraVisionPage _page;
        byte[] resizedImage;

        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            base.OnElementChanged(e);

            _page = Element as CameraVisionPage;

            _page.ShowDocumentViewController += ShowDocumentViewController;

            _page.CancelDocumentViewController += CancelDocumentViewController;

            _page.ShowBarcodeDocumentViewController += ShowBarcodeDocumentViewController;

            _page.UpdateImageScanController += UpdateImageScanController;
        }


        [Obsolete]
        public void UpdateImageScanController()
        {

            _page.updateImageScan(resizedImage);
        }

            [Obsolete]
        public void ShowBarcodeDocumentViewController()
        {
            if (NativeView != null)
            {
                this.ShowQRCodeReaderViewController((result) => {

                    Globals.barcodeResult = result;
                    _page.editProductNumber.Text = Globals.barcodeResult;

                    if (_page.editProductNumber.Text != null)
                    {
                        _page.addmProd();
                    }
                    //DismissViewController(true, null);
                   // UIAlertView alert = new UIAlertView("Result",result,null,"OK",null);
                
                });
                

            }
            
        }
        public void ShowDocumentViewController()
        {
            var cameraViewController = new VNDocumentCameraViewController
            {
                Delegate = this
            };
           
            PresentViewController(cameraViewController, true, null);
        }

        public void CancelDocumentViewController()
        {
            DismissViewController(true, null);
        }


        [Export("documentCameraViewControllerDidCancel:")]
        public void DidCancel(VNDocumentCameraViewController controller)
        {
            DismissViewController(true, null);
        }

        [Export("documentCameraViewController:didFinishWithScan:")]
        [Obsolete]
        public async void DidFinish(VNDocumentCameraViewController controller, VNDocumentCameraScan scan)
        {
           

            var pageCount = (int)scan.PageCount;

            if (pageCount >= 1)
            {
                var pageLoading = new LoadingPopupPage();
                try
                {

                    DismissViewController(true, null);

                    await PopupNavigation.Instance.PushAsync(pageLoading);

                    var allItems = new List<List<string>>();
                    string _base64String = string.Empty;
                    for (int i = 0; i < pageCount; i++)
                    {
                        var image = scan.GetImage(nuint.Parse(i.ToString()));
                        using (NSData imageData = image.AsPNG())
                        {
                            Byte[] myByteArray = new Byte[imageData.Length];
                            System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteArray, 0, Convert.ToInt32(imageData.Length));
                            resizedImage = DependencyService.Get<IImageService>().ResizeTheImage(myByteArray, 1024, 768);
                            _base64String = Convert.ToBase64String(resizedImage);

                            if (resizedImage != null) UpdateImageScanController();
                        }

                        var imageRequestHandler = new VNImageRequestHandler(image.CGImage, options: new NSDictionary());

                        var textRequest = new VNRecognizeTextRequest(new VNRequestCompletionHandler((request, error) =>
                        {
                            var results = request.GetResults<VNRecognizedTextObservation>();

                            foreach (var result in results)
                            {
                                var items = new List<string>();

                                foreach (var candidate in result.TopCandidates(100))
                                    items.Add(candidate.String);

                                allItems.Add(items);
                            }

                            Device.BeginInvokeOnMainThread(() =>
                            {
                                _page.LoadRecognizedTextItems(allItems, _base64String);
                               
                                DismissViewController(true, null);
                            });
                        }));

                        switch (_page.TextRecognitionLevel)
                        {
                            case TextRecognitionLevelEnum.Accurate:
                                textRequest.RecognitionLevel = VNRequestTextRecognitionLevel.Accurate;
                                break;

                            case TextRecognitionLevelEnum.Fast:
                                textRequest.RecognitionLevel = VNRequestTextRecognitionLevel.Fast;
                                break;

                            default:
                                break;
                        }

                        textRequest.UsesLanguageCorrection = true;
                        
                        DispatchQueue.DefaultGlobalQueue.DispatchAsync(() =>
                        {
                            imageRequestHandler.Perform(new VNRequest[] { textRequest }, out NSError error);
                          
                        });
                        pageLoading.CloseMe();
                    }
                }
                catch
                {
                    pageLoading.CloseMe();
                }
            }
        }
    }
}
