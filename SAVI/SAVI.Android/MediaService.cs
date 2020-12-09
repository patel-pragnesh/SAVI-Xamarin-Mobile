using Android.Content;
using Android.Net;
using Java.Lang;
using Plugin.CurrentActivity;
using SAVI.CustomControl;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Environment = Android.OS.Environment;
[assembly: Dependency(typeof(SAVI.Droid.MediaService))]
namespace SAVI.Droid
{
    public class MediaService : IMediaService
    {
        Context CurrentContext => CrossCurrentActivity.Current.Activity;

        [System.Obsolete]
        public void SaveImageFromByte(string filename, byte[] imageByte)
        {
            try
            {
                //   Java.IO.File storagePath = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures+"/personalMobility");


                //     var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "count.txt");
                //using (var writer = File.CreateText(backingFile))
                //{
                //    await writer.WriteLineAsync(count.ToString());
                //}

                if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/personalMobility")) Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/personalMobility");


                string path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/personalMobility", filename);
                System.IO.File.WriteAllBytesAsync(path, imageByte);
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Uri.FromFile(new Java.IO.File(path)));
                CurrentContext.SendBroadcast(mediaScanIntent);
            }
            catch (Exception ex)
            {

            }
        }

        public List<string> GetImages()
        {
            if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/personalMobility"))
            {
                List<string> list = new List<string>();
                string[] filePaths = Directory.GetFiles(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/personalMobility");
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
            if (Directory.Exists(Environment.DirectoryPictures + "/personalMobility"))
            {
                string[] filePaths = Directory.GetFiles(Environment.DirectoryPictures + "/personalMobility");
                foreach (string filePath in filePaths)
                    File.Delete(filePath);
            }
        }


    }
}