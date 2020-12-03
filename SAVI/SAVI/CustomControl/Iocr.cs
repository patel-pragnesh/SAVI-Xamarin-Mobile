using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SAVI.CustomControl
{
    public interface Iocr
    {
     List<string> ShowAndroid(Stream stream);
    }
}
