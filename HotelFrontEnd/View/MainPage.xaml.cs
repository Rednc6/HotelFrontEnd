using HotelFrontEnd.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HotelFrontEnd
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void newBooking_Click(object sender, RoutedEventArgs e)
        {
            base.Frame.Navigate(typeof(NewBookingView));
        }

        private void newGuest_Click(object sender, RoutedEventArgs e)
        {
            base.Frame.Navigate(typeof(NewGuestView));
        }

        private void currentBooking_Click(object sender, RoutedEventArgs e)
        {
            base.Frame.Navigate(typeof(BookingsView));
        }

        private void allGuests_Click(object sender, RoutedEventArgs e)
        {
            base.Frame.Navigate(typeof(GuestView));
        }
    }
}
