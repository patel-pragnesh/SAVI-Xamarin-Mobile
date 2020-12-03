using System.Collections.Generic;
using System.IO;

namespace SAVI.CustomControl
{
    public interface IMediaService
    {
        void SaveImageFromByte(string filename, byte[] imageByte);

        void DeleteImages();

        List<string> GetImages();

    }
}
