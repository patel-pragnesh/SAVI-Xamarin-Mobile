using SAVI.com.celcom.savi;
using SAVI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SAVI.ViewModel
{
    public class ClaimCommisionViewModel : BaseViewModel
    {
        private IdValue _selectedPtype;
        public IdValue SelectedPtype
        {
            get => _selectedPtype;
            set { _selectedPtype = value; OnPropertyChanged(); }
        }

        public ObservableCollection<IdValue> PaymentTypes { get; set; }

      

        public ClaimCommisionViewModel()
        {


            PaymentTypes = new ObservableCollection<IdValue>();
            var getPtypes = App.SoapService.GetPaymentTypes().GetPaymentTypesResult;
            for (int i = 0; i < getPtypes.Count; ++i)
            {
                PaymentTypes.Add(getPtypes[i]);
            }


          

          
            
        }
    }
}
