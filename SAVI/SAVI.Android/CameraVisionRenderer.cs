using Android.Gms.Vision.Texts;
using Android.Graphics;
using Android.Util;
using SAVI.CustomControl;
using SAVI.Droid;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Frame = Android.Gms.Vision.Frame;

[assembly: Dependency(typeof(CameraVisionRenderer))]
namespace SAVI.Droid
{

    public class CameraVisionRenderer : Iocr
    {


        public CameraVisionRenderer() {}

        [System.Obsolete]
        public List<string> ShowAndroid(System.IO.Stream stream)
        {

           
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Forms.Context).Build();
           

            var bitmap = BitmapFactory.DecodeStream(stream);

            Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
            SparseArray items = txtRecognizer.Detect(frame);

            List<string> listString = new List<string>();

            if (items.Size() != 0)
            {
              //  StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); ++i)
                {
                    listString.Add(((TextBlock)items.ValueAt(i)).Value);


                   // stringBuilder.Append(((TextBlock)items.ValueAt(i)).Value);
                   // stringBuilder.Append("\n");
                }
               // var text = stringBuilder.ToString();
            }
           

            return listString;
        }

     
     

    }
}