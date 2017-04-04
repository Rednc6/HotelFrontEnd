using HotelFrontEnd.Commen;
using HotelFrontEnd.Handler;
using HotelFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelFrontEnd.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        // Handler
        public GuestHandler GuestHandler { get; set; }

        // ICommand Props
        public ICommand AddGuestCommand { get; set; }
        public ICommand DeleteGuestCommand { get; set; }
        public ICommand SelectGuestCommand { get; set; }
        public ICommand EditGuestCommand { get; set; }


        // Props

        private string _guestName;
        public string GuestName
        {
            get { return _guestName; }
            set { _guestName = value; OnPropertyChanged(nameof(GuestName)); }
        }

        private string _guestAddress;
        public string GuestAdress
        {
            get { return _guestAddress; }
            set { _guestAddress = value; OnPropertyChanged(nameof(GuestAdress)); }
        }

        private int _guestPhone;
        public int GuestPhone
        {
            get { return _guestPhone; }
            set { _guestPhone = value; OnPropertyChanged(nameof(GuestPhone)); }
        }

        private int _guestID;
        public int GuestID
        {
            get { return _guestID; }
            set { _guestID = value; OnPropertyChanged(nameof(GuestID)); }
        }

        private static Guest _selectedGuest;
        public Guest SelectedGuest
        {
            get { return _selectedGuest; }
            set { _selectedGuest = value; OnPropertyChanged(nameof(SelectedGuest)); }
        }

        private ObservableCollection<Guest> _guestCollection;
        public ObservableCollection<Guest> GuestColletion
        {
            get { return _guestCollection; }
            set { _guestCollection = value; }
        }

        private String _searchString;
        public String SearchString
        {
            get { return _searchString; }
            set { _searchString = value; OnPropertyChanged(nameof(SearchString)); RefreshFilter(); }
        }

        private ObservableCollection<Guest> _filterGuest;
        public ObservableCollection<Guest> FilterGuest
        {
            get { return _filterGuest; }
            set
            {
                _filterGuest = value;
                OnPropertyChanged(nameof(FilterGuest));
            }
        }
        
        // CTOR
        public MainViewModel()
        {
            GuestHandler = new GuestHandler(this);
            GuestColletion = new ObservableCollection<Guest>();
            FilterGuest = new ObservableCollection<Guest>();
            GuestColletion = Singleton.Instance.GuestCollection;

            FilterGuest = GuestColletion;

            AddGuestCommand = new RelayCommand(GuestHandler.AddGuest, null);
            DeleteGuestCommand = new RelayCommand(GuestHandler.DeleteGuest, null);
            EditGuestCommand = new RelayCommand(GuestHandler.PutGuest, null);

        }

        private void RefreshFilter()
        {
            var newList = from gobj in GuestColletion
                          where gobj.Phone_Nr.ToString().Contains(SearchString)
                          select gobj;

            if (FilterGuest.Count == newList.Count())
                return;

            FilterGuest = new ObservableCollection<Guest>(newList);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
