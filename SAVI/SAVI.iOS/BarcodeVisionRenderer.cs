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
using AVFoundation;
using UIKit;

[assembly: ExportRenderer(typeof(CameraVisionPage), typeof(BarcodeVisionRenderer))]
namespace SAVI.iOS.Renderers
{
    public class BarcodeVisionRenderer : PageRenderer
    {
        CameraVisionPage _page;
        //UINavigationController navController;
        //UIWindow window;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            _page = Element as CameraVisionPage;

            _page.ShowBarcodeDocumentViewController += ShowBarcodeDocumentViewController;
        }

        public void ShowBarcodeDocumentViewController()
        {
            if (NativeView != null)
            {
                BarcodeViewController vc = new BarcodeViewController();
                NativeView.Add(vc.View);
            }
            //navController = new UINavigationController(new BarcodeViewController());

            //// create a new window instance based on the screen size
            //window = new UIWindow(UIScreen.MainScreen.Bounds);
            //window.RootViewController = navController;
            //window.MakeKeyAndVisible();

            // var cameraViewController = new BarcodeViewController();


            // PresentViewController(cameraViewController, true, null);
        }

        //[Export("documentCameraViewControllerDidCancel:")]
        //public void DidCancel(BarcodeViewController controller)
        //{
        //    DismissViewController(true, null);
        //}

        //[Export("documentCameraViewController:didFinishWithScan:")]
        //public void DidFinish(BarcodeViewController controller, VNDocumentCameraScan scan)
        //{
        //    var pageCount = (int)scan.PageCount;
        //    var allItems = new List<List<string>>();
        //    string _base64String = string.Empty;
        //    for (int i = 0; i < pageCount; i++)
        //    {
        //        var image = scan.GetImage(nuint.Parse(i.ToString()));
        //        using (NSData imageData = image.AsPNG())
        //        {


        //            Byte[] myByteArray = new Byte[imageData.Length];
        //            System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteArray, 0, Convert.ToInt32(imageData.Length));
        //            byte[] resizedImage = DependencyService.Get<IImageService>().ResizeTheImage(myByteArray, 1024, 768);
        //            _base64String = Convert.ToBase64String(resizedImage);
        //        }

        //        var imageRequestHandler = new VNImageRequestHandler(image.CGImage, options: new NSDictionary());

        //        var textRequest = new VNRecognizeTextRequest(new VNRequestCompletionHandler((request, error) =>
        //        {
        //            var results = request.GetResults<VNRecognizedTextObservation>();

        //            foreach (var result in results)
        //            {
        //                var items = new List<string>();

        //                foreach (var candidate in result.TopCandidates(100))
        //                    items.Add(candidate.String);

        //                allItems.Add(items);
        //            }

        //            Device.BeginInvokeOnMainThread(() =>
        //            {
        //                _page.LoadRecognizedTextItems(allItems, _base64String);
        //                DismissViewController(true, null);
        //            });
        //        }));

        //        switch (_page.TextRecognitionLevel)
        //        {
        //            case TextRecognitionLevelEnum.Accurate:
        //                textRequest.RecognitionLevel = VNRequestTextRecognitionLevel.Accurate;
        //                break;

        //            case TextRecognitionLevelEnum.Fast:
        //                textRequest.RecognitionLevel = VNRequestTextRecognitionLevel.Fast;
        //                break;

        //            default:
        //                break;
        //        }

        //        textRequest.UsesLanguageCorrection = true;

        //        DispatchQueue.DefaultGlobalQueue.DispatchAsync(() =>
        //        {
        //            imageRequestHandler.Perform(new VNRequest[] { textRequest }, out NSError error);
        //        });
        //    }
        //}




        //#region Barcode Scan

        //bool canReceiveData = true;
        //public bool CanReceiveData
        //{
        //    get
        //    {
        //        return canReceiveData;
        //    }
        //    set
        //    {
        //        canReceiveData = value;
        //    }
        //}

        //[Export("captureOutput:didOutputMetadataObjects:fromConnection:")]
        //public void DidOutputMetadataObjects(AVFoundation.AVCaptureMetadataOutput captureOutput, AVFoundation.AVMetadataObject[] metadataObjects, AVFoundation.AVCaptureConnection connection)
        //{
        //    if (null != captureOutput && metadataObjects.Length > 0 && canReceiveData)
        //    {
        //        canReceiveData = false;
        //        AVMetadataMachineReadableCodeObject metadataObj = metadataObjects[0] as AVMetadataMachineReadableCodeObject;
        //        NSString result = new NSString();
        //        //if (metadataObj.Type.Equals (AVMetadataObjectType.QRCode)) {
        //        result = new NSString(metadataObj.StringValue);
        //        //}
        //        //else {
        //        //	result = new NSString( "It's not a QRCode." );
        //        //}
        //        this.PerformSelector(new ObjCRuntime.Selector("reportScanResult:"), NSThread.MainThread, result, false);
        //    }
        //}

        //[Export("reportScanResult:")]
        //void ReportScanResult(NSString result)
        //{
        //    QRCodeGlobalObject.TheQRCodeReaderViewController.ReturnResult(result.ToString());

        //    NSData data = NSData.FromFile(NSBundle.MainBundle.PathForResource("beep", "wav"));
        //    NSError error = new NSError();
        //    AVAudioPlayer beepPlayer = new AVAudioPlayer(data, "", out error);
        //    beepPlayer.Play();
        //}

        //#endregion
    }
}
