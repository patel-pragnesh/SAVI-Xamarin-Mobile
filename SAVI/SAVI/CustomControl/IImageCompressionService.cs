using System;
using System.Collections.Generic;
using System.Text;

namespace SAVI.CustomControl
{
    public interface IImageCompressionService
    {
        byte[] CompressImage(byte[] imageDate, string destinationPath, int compressionPercentage);
    }
}
