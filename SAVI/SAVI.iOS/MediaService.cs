using Foundation;
using SAVI.CustomControl;
using System;
using System.Collections.Generic;
using System.IO;
using UIKit;
using Xamarin.Forms;
[assembly: Dependency(typeof(SAVI.iOS.MediaService))]
namespace SAVI.iOS
{
    public class MediaService : IMediaService
    {
        //public void SaveImageFromByte(byte[] imageByte, string fileName)
        //{
        //    var imageData = new UIImage(NSData.FromArray(imageByte));
        //    imageData.SaveToPhotosAlbum((image, error) =>
        //    {
        //        //you can retrieve the saved UI Image as well if needed using  
        //        //var i = image as UIImage;  
        //        if (error != null)
        //        {
        //            Console.WriteLine(error.ToString());
        //        }
        //    });
        //}


        public void SaveImageFromByte(string filename, byte[] imageByte)
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var library = Path.Combine(documentsDirectory, "..", "Library");
            var Personal = Path.Combine(library, "PersonalMobility");
         

            if (!Directory.Exists(Personal)) 
                
                Directory.CreateDirectory(Personal);

            string imageFilename = System.IO.Path.Combine(Personal, filename);
                var imageData = new UIImage(NSData.FromArray(imageByte));
                NSData pngImg = imageData.AsJPEG();
                if (pngImg.Save(imageFilename, false, out NSError err))
                {
                    //return imageFilename;
                }
                else
                {
                    Console.WriteLine("NOT saved as " + imageFilename + " because" + err.LocalizedDescription);
                    //return null;
                }
           
        }

        public List<string> GetImages()
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var library = Path.Combine(documentsDirectory, "..", "Library");
            var Personal = Path.Combine(library, "PersonalMobility");


            if (Directory.Exists(Personal))
            {
                List<string> list = new List<string>();
                string[] filePaths = Directory.GetFiles(Personal);
                foreach (string filePath in filePaths)
                {

                    list.Add(filePath);
                }
                return list;
            }
            return null;
        }

        public void DeleteImages()
        {

            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var library = Path.Combine(documentsDirectory, "..", "Library");
            var Personal = Path.Combine(library, "PersonalMobility");

            if (Directory.Exists(Personal))
            {
                string[] filePaths = Directory.GetFiles(Personal);
                foreach (string filePath in filePaths)
                    File.Delete(filePath);
            }
        }


    }
}