using SAVI.com.celcom.savi;
using SAVI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SAVI.ViewModel
{
    public class AdminViewModel : BaseViewModel
    {
        private IdValue _selectedbank;
        public IdValue SelectedBank
        {
            get => _selectedbank;
            set { _selectedbank = value; OnPropertyChanged(); }
        }

        public ObservableCollection<IdValue> Banks { get; set; }

        private GetBankingDetailReply _bankDetail;
        public GetBankingDetailReply BankDetail
        {
            get => _bankDetail;
            set { _bankDetail = value; OnPropertyChanged(); }
        }


        public AdminViewModel()
        {

            //Bank
            Banks = new ObservableCollection<IdValue>();

             var banks = App.SoapService.GetBanks().GetBanksResult;

            foreach (var l in banks)
                Banks.Add(l);

        }
    }
}
