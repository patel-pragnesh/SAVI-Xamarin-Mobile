using System;
using System.Collections.Generic;
using System.Text;

namespace SAVI.CustomControl
{
    public interface IImageService 
    { 
        byte[] ResizeTheImage(byte[] imageData, float width, float height); 
    }
}
