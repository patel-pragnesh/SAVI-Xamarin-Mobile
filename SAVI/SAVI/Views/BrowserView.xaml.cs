using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAVI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowserView : ContentPage
    {
        public BrowserView( string htmlText)
        {
            InitializeComponent();


            var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body> " + htmlText + @" </body></html>";
            browser.Source = htmlSource;
            Content = browser;





        }
    }
}