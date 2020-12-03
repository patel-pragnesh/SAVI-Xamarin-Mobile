using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Demo.Pages
{
    public partial class LoadingPopupPage : PopupPage
    {
        public LoadingPopupPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    public async void CloseAllPopup()
    {
       await PopupNavigation.Instance.PopAllAsync();
     // await PopupNavigation.Instance.PopAsync();

    }

    //[Obsolete]
    public async void CloseMe()
    {
      // await PopupNavigation.Instance.PopAllAsync();
      await PopupNavigation.Instance.PopAsync();
    }
  }
}
