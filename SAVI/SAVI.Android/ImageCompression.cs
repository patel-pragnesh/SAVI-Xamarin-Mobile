using Android.Graphics;
using SAVI.Android;
using SAVI.CustomControl;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageCompression))]
namespace SAVI.Android
{
    public class ImageCompression: IImageCompressionService
    {
        public ImageCompression()
        {

        }
        
        public byte[] CompressImage(byte[] imageDate, string destinationPath, int compressionPercentage)
        {
            var resizedImage = GetResizedImage(imageDate, compressionPercentage);
            var stream = new FileStream(destinationPath, FileMode. Create);
            stream.Write(resizedImage, 0, resizedImage.Length);
            stream.Flush();
            stream.Close();
            return resizedImage;

        }
        private byte[] GetResizedImage(byte[] imageDate, int compressionPercentage)
        {
            Bitmap originalImage = BitmapFactory.DecodeByteArray(imageDate, 0, imageDate.Length);
            using (MemoryStream ms = new MemoryStream())
            {
                originalImage.Compress(Bitmap.CompressFormat.Jpeg, compressionPercentage, ms);
                return ms.ToArray();
            }
        }
    }
}