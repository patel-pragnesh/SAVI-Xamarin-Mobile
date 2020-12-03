using SAVI.com.celcom.savi;
using SAVI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SAVI.ViewModel
{
    public class InboxViewModel : BaseViewModel
    {
        private IdValue _selectedInbox;
        public IdValue SelectedInbox
        {
            get => _selectedInbox;
            set { _selectedInbox = value; OnPropertyChanged(); }
        }

        public ObservableCollection<IdValue> Inboxes { get; set; }



        public InboxViewModel()
        {
            Inboxes = new ObservableCollection<IdValue>();
            refreshInboxes();



        }


        public void refreshInboxes()

        {
            Inboxes.Clear();
             var getInboxes = App.SoapService.GetInbox(SAVIApplication.mRegistrationID.ToString()).GetInboxResult;
            for (int i = 0; i<getInboxes.Count; ++i)
            {
                Inboxes.Add(getInboxes[i]);
            }


        }
    }
}
