using SAVI.com.celcom.savi;
using SAVI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SAVI.ViewModel
{
    public class ElectricityViewModel : BaseViewModel
    {
        private ProductList _selectedProductList;
        public ProductList SelectedProductList
        {
            get => _selectedProductList;
            set { _selectedProductList = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ProductList> ProductLists { get; set; }

      

        public ElectricityViewModel()
        {


            ProductLists = new ObservableCollection<ProductList>();
          

          

          
            
        }
    }
}
