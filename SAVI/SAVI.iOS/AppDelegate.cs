using System;
using System.Collections.Generic;
using System.Linq;
using AVFoundation;
using Foundation;
using UIKit;

namespace SAVI.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IAVCaptureMetadataOutputObjectsDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
          
            Rg.Plugins.Popup.Popup.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();

            QRCodeGlobalObject.TheAppDel = this;
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }


        #region Barcode Scan

        bool canReceiveData = true;
        public bool CanReceiveData
        {
            get
            {
                return canReceiveData;
            }
            set
            {
                canReceiveData = value;
            }
        }

        [Export("captureOutput:didOutputMetadataObjects:fromConnection:")]
        public void DidOutputMetadataObjects(AVFoundation.AVCaptureMetadataOutput captureOutput, AVFoundation.AVMetadataObject[] metadataObjects, AVFoundation.AVCaptureConnection connection)
        {
            if (null != captureOutput && metadataObjects.Length > 0 && canReceiveData)
            {
                canReceiveData = false;
                AVMetadataMachineReadableCodeObject metadataObj = metadataObjects[0] as AVMetadataMachineReadableCodeObject;
                NSString result = new NSString();
                //if (metadataObj.Type.Equals (AVMetadataObjectType.QRCode)) {
                result = new NSString(metadataObj.StringValue);
                //}
                //else {
                //	result = new NSString( "It's not a QRCode." );
                //}
                this.PerformSelector(new ObjCRuntime.Selector("reportScanResult:"), NSThread.MainThread, result, false);
            }
        }

        [Export("reportScanResult:")]
        void ReportScanResult(NSString result)
        {
            QRCodeGlobalObject.TheQRCodeReaderViewController.ReturnResult(result.ToString());

            //NSData data = NSData.FromFile(NSBundle.MainBundle.PathForResource("beep", "wav"));
            //NSError error = new NSError();
            //AVAudioPlayer beepPlayer = new AVAudioPlayer(data, "", out error);
            //beepPlayer.Play();
        }

        #endregion
    }
}
