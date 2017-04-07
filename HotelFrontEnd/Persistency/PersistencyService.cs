using HotelFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace HotelFrontEnd.Persistency
{
    class PersistencyService
    {
        const string serverURL = "http://hotelwebapi20170407022644.azurewebsites.net/";

        #region GuestServices
        // Post 
        public static void PostGuest(Guest PostGuest)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PostAsJsonAsync<Guest>("api/guests", PostGuest).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageDialog guestAdded = new MessageDialog("Guest has been added");
                        guestAdded.Commands.Add(new UICommand { Label = "Ok" });
                        guestAdded.ShowAsync().AsTask();
                    }
                    else
                    {
                        MessageDialog Error = new MessageDialog("Error");
                        Error.Commands.Add(new UICommand { Label = "Ok" });
                        Error.ShowAsync().AsTask();
                    }
                }
                catch (Exception e)
                {
                    MessageDialog Error = new MessageDialog("Error : " + e);
                    Error.Commands.Add(new UICommand { Label = "Ok" });
                    Error.ShowAsync().AsTask();
                }

            }

        }

        // Delete
        public static void DeleteGuest(Guest GuestToDelete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                string urlString = "api/guests/" + GuestToDelete.Guest_ID.ToString();

                try
                {
                    var response = client.DeleteAsync(urlString).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageDialog msg = new MessageDialog("Guest has been Deleted");
                        msg.Commands.Add(new UICommand { Label = "Ok" });
                        msg.ShowAsync().AsTask();

                    }
                }
                catch (Exception e)
                {
                    MessageDialog Error = new MessageDialog("Error : " + e);
                    Error.Commands.Add(new UICommand { Label = "Ok" });
                    Error.ShowAsync().AsTask();
                }
            }
        }

        // Put
        public static void PutGuest(Guest GuestToPut)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlString = "api/guests/" + GuestToPut.Guest_ID.ToString();

                try
                {
                    var response = client.PutAsJsonAsync<Guest>(urlString, GuestToPut).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        MessageDialog msg = new MessageDialog("Guest has been edited");
                        msg.Commands.Add(new UICommand { Label = "Ok" });
                        msg.ShowAsync().AsTask();

                    }
                }
                catch (Exception e)
                {
                    MessageDialog Error = new MessageDialog("Error : " + e);
                    Error.Commands.Add(new UICommand { Label = "Ok" });
                    Error.ShowAsync().AsTask();
                }
            }

        }


        // make view => call view instead thus getting booking information as well.
        public static ObservableCollection<Guest> GetGuest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                var response = client.GetAsync("api/Guests").Result;

                if (response.IsSuccessStatusCode)
                {
                    var guestListe = response.Content.ReadAsAsync<ObservableCollection<Guest>>().Result;
                    return guestListe;
                }

                return null;
            }
        }
        #endregion


        #region BookingServices

        public static ObservableCollection<Booking> GetBooking()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/Bookings").Result;

                if (response.IsSuccessStatusCode)
                {
                    var BookingList = response.Content.ReadAsAsync<ObservableCollection<Booking>>().Result;
                    return BookingList;
                }

                return null;
            }
        }

        public static void BookingCommand(String command, Booking booking)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();

                switch (command)
                {
                    case "post":
                        try
                        {
                            var response = client.PostAsJsonAsync<Booking>("api/bookings", booking).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                MessageDialog success = new MessageDialog("Booking is complete");
                                success.Commands.Add(new UICommand { Label = "Ok" });
                                success.ShowAsync().AsTask();
                                break;
                            }
                            else
                            {
                                MessageDialog Error = new MessageDialog("Error: Booking failed");
                                Error.Commands.Add(new UICommand { Label = "Ok" });
                                Error.ShowAsync().AsTask();
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            MessageDialog Error = new MessageDialog("Error : " + e);
                            Error.Commands.Add(new UICommand { Label = "Ok" });
                            Error.ShowAsync().AsTask();
                        }
                        break;
                    case "put":
                        String bookingToUpdate = "api/bookings/" + booking.Booking_ID.ToString();

                        var ExistCheck = client.GetAsync(bookingToUpdate).Result;

                        if (ExistCheck.IsSuccessStatusCode)
                        {
                            try
                            {
                                var response = client.PutAsJsonAsync<Booking>(bookingToUpdate, booking).Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    MessageDialog success = new MessageDialog("Booking updated");
                                    success.Commands.Add(new UICommand { Label = "Ok" });
                                    success.ShowAsync().AsTask();
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                MessageDialog Error = new MessageDialog("Error : " + e);
                                Error.Commands.Add(new UICommand { Label = "Ok" });
                                Error.ShowAsync().AsTask();
                                break;
                            }
                        }
                        else
                        {
                            MessageDialog success = new MessageDialog("Booking was not found!");
                            success.Commands.Add(new UICommand { Label = "Ok" });
                            success.ShowAsync().AsTask();
                        }
                        break;
                    case "delete":
                        String bookingToDelete = "api/bookings/" + booking.Booking_ID.ToString();

                        var DeleteBooking = client.DeleteAsync(bookingToDelete).Result;

                        try
                        {
                            if (DeleteBooking.IsSuccessStatusCode)
                            {
                                MessageDialog msg = new MessageDialog("Booking has been deleted!");
                                msg.Commands.Add(new UICommand { Label = "Ok" });
                                msg.ShowAsync().AsTask();
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            MessageDialog Error = new MessageDialog("Error : " + e);
                            Error.Commands.Add(new UICommand { Label = "Ok" });
                            Error.ShowAsync().AsTask();
                        }
                        break;
                }
            }
        }

        #endregion

        #region RoomServices

        public static ObservableCollection<Room> AvailableRooms(DateTimeOffset datefrom, DateTimeOffset dateto)
        {
            DateTime DateFrom = Converter.DateTimeConverter.DateTimeArrive(datefrom);
            DateTime DateTo = Converter.DateTimeConverter.DateTimeLeave(dateto);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var GetAllRooms = client.GetAsync("api/rooms").Result;
                var GetAllBookings = client.GetAsync("api/bookings").Result;

                if (GetAllRooms.IsSuccessStatusCode && GetAllBookings.IsSuccessStatusCode)
                {
                    var AllRooms = GetAllRooms.Content.ReadAsAsync<ObservableCollection<Room>>().Result;
                    var AllBookings = GetAllBookings.Content.ReadAsAsync<List<Booking>>().Result;
                    ObservableCollection<Room> AvailableRooms = new ObservableCollection<Room>();

                    foreach (var r in AllRooms)
                    {
                        var IsBooked = AllBookings.Where(b => b.Room_ID == r.Room_ID && (b.Date_From <= b.Date_To && b.Date_From >= b.Date_To || b.Date_From <= DateTo && b.Date_To >= DateFrom)).FirstOrDefault();

                        if (IsBooked == null)
                        {
                            AvailableRooms.Add(r);
                        }
                    }

                    return AvailableRooms;
                }
            }

            return null;
        }

        #endregion

        #region DatabaseViewService

        public static ObservableCollection<GuestAndBookings> GetDBView()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                String ViewURL = "api/GuestBookingViews";

                var GetViewData = client.GetAsync(ViewURL).Result;

                if(GetViewData.IsSuccessStatusCode)
                {
                    var ViewList = GetViewData.Content.ReadAsAsync<ObservableCollection<GuestAndBookings>>().Result;
                    return ViewList;
                }

            }
            return null;
        }

        public static ObservableCollection<Booking> GetAllBookingsByGuestId(int GuestID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                String GetBookingUrl = "api/bookings/";

                var GetBookings = client.GetAsync(GetBookingUrl).Result;

                if(GetBookings.IsSuccessStatusCode)
                {
                    var AllBookingsByGuestId = new ObservableCollection<Booking>();

                    foreach (var item in GetBookings.Content.ReadAsAsync<ObservableCollection<Booking>>().Result)
                    {
                        if(item.Guest_ID == GuestID)
                        {
                            AllBookingsByGuestId.Add(item);
                        }
                    }

                    return AllBookingsByGuestId;
                }
            }
            return null;
        }


        #endregion

    }

}
