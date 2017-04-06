using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace HotelFrontEnd.Model
{
    class Singleton : INotifyPropertyChanged
    {
        // Singleton
        private static readonly Singleton _instance = new Singleton();

        public static Singleton Instance
        {
            get { return _instance; }
        }

        public ObservableCollection<Guest> GuestCollection { get; set; }

        private int _selectedIndexCB;
        public int SelectedIndexCB
        {
            get { return _selectedIndexCB; }
            set
            {
                _selectedIndexCB = value;
                OnPropertyChanged(nameof(SelectedIndexCB));
            }
        }

        // CTOR
        private Singleton()
        {
            GuestCollection = new ObservableCollection<Guest>();
            Load();
        }

        #region Methods
        public void AddGuest(Guest GuestToAdd)
        {
            Persistency.PersistencyService.PostGuest(GuestToAdd);
            GuestCollection.Add(GuestToAdd);
            SelectedIndexCB = 0;
        }

        public void PutGuest(Guest GuestToPut)
        {
            Persistency.PersistencyService.PutGuest(GuestToPut);
            Load();
        }

        public void DeleteGuest(Guest GuestToDelete)
        {
            Persistency.PersistencyService.DeleteGuest(GuestToDelete);
            if (GuestToDelete != null)
            {
                GuestCollection.Remove(GuestToDelete);
            }
        }

        public void Load()
        {
            try
            {
                GuestCollection = Persistency.PersistencyService.GetGuest();
                SelectedIndexCB = 0;
            }
            catch (Exception e)
            {

                MessageDialog Error = new MessageDialog("Error : " + e);
                Error.Commands.Add(new UICommand { Label = "Ok" });
                Error.ShowAsync().AsTask();

            }
        }

        //PropetyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
