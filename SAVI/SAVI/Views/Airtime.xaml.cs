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
    public partial class Airtime : ContentPage
    {
        public Airtime()
        {
            InitializeComponent();
        }

        private async void Vodacom_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Airtime2("Vodacom"));
        }

        private async void MTN_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Airtime2("MTN"));
        }

        private async void CellC_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Airtime2("CellC"));
        }

        private async void Ata_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Airtime2("8ta"));
        }

        private async void VMSA_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Airtime2("VMSA"));
        }
    }
}