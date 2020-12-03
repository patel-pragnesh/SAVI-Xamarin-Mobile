using SAVI.com.celcom.savi;
using SAVI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SAVI.ViewModel
{
    public class Airtime2ViewModel : BaseViewModel
    {
        private GetProductResponseDataBundles _selectedBundle;
        public GetProductResponseDataBundles SelectedBundle
        {
            get => _selectedBundle;
            set { _selectedBundle = value; OnPropertyChanged(); }
        }

        public ObservableCollection<GetProductResponseDataBundles> GetProductResponseDataBundles { get; set; }

      

        public Airtime2ViewModel()
        {


            GetProductResponseDataBundles = new ObservableCollection<GetProductResponseDataBundles>();
          

          

          
            
        }
    }
}
