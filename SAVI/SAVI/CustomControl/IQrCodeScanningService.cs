using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SAVI.CustomControl
{
    public interface IQrCodeScanningService
    {
         Task<string> ScanAsync();
    }
}
