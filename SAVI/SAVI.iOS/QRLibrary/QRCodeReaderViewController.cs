using System;
using UIKit;
using AVFoundation;
using CoreGraphics;
using Foundation;
using CoreFoundation;

namespace SAVI.iOS
{
	public delegate void QRCodeReaderCallback(string result);
	public class QRCodeReaderViewController : UIViewController
	{
		private QRCodeReaderView readerView;
		private QRCodeReaderCallback callback;
		private static QRCodeReaderViewController intance;

        [Obsolete]
        public static QRCodeReaderViewController Intance()
		{
			if (null == intance)
				intance = new QRCodeReaderViewController ();
			return intance;
		}

        [Obsolete]
        private QRCodeReaderViewController ()
		{
			QRCodeGlobalObject.TheQRCodeReaderViewController = this;

			readerView = new QRCodeReaderView (this);
			this.View = readerView;
		}

        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        public override void ViewDidAppear(bool animated)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
			readerView.StartScan ();
		}

		public override void ViewDidDisappear (bool animated)
		{
			readerView.StopScan ();
		}

		public void ReturnResult(string result)
		{
			callback.Invoke (result);
			Close ();
		}

		public void Show(UIViewController navController,QRCodeReaderCallback _callback)
		{
			//UINavigationController navController = new UINavigationController(uiController);
			
			readerView.HideLayer ();
			callback = _callback;
			navController.PresentViewController(this,true,null);
		}

		public void Close()
		{
			this.DismissViewController (true, delegate {
				QRCodeGlobalObject.TheAppDel.CanReceiveData = true;
			});
		}
	}
}

