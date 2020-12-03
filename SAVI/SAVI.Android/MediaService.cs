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
        public void SaveImageFromByte(string filename, byte[] imageByte)
        {
            try
            {
                Java.IO.File storagePath = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures+"/personalMobility");

                if (!Directory.Exists(Environment.DirectoryPictures + "/personalMobility")) Directory.CreateDirectory(Environment.DirectoryPictures + "/personalMobility");


                string path = System.IO.Path.Combine(storagePath.ToString(), filename);
                System.IO.File.WriteAllBytes(path, imageByte);
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Uri.FromFile(new Java.IO.File(path)));
                CurrentContext.SendBroadcast(mediaScanIntent);
            }
            catch (Exception ex)
            {

            }
        }

        public List<byte[]> GetImages()
        {
            if (Directory.Exists(Environment.DirectoryPictures + "/personalMobility"))
            {
                List<byte[]> list = new List<byte[]>();
                string[] filePaths = Directory.GetFiles(Environment.DirectoryPictures + "/personalMobility");
                foreach (string filePath in filePaths)
                {

                    list.Add(File.ReadAllBytes(filePath));
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