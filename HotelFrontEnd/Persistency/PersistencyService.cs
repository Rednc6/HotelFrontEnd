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
        const string serverURL = "http://hotelbackend20170404114439.azurewebsites.net";

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
    }
}
