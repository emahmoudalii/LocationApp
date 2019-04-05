using LocationApp.Logics;
using LocationApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using static LocationApp.Models.VenueModel;

namespace LocationApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            GetUserLocationAsync();
            InitializeComponent();
        }

        // by md
        public async void GetUserLocationAsync()
        {
            try
            {

                VenueLogic venue = new VenueLogic();

                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request).ConfigureAwait(false); ; // for current location; // for current location
                var joko = await venue.GetVenues(location.Latitude, location.Longitude);
                if (location == null)
                {
                    // if current location is not retrieved use last known location
                    var lastLocation = await Geolocation.GetLastKnownLocationAsync();

                    if (lastLocation != null)
                    {
                        Debug.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");

                        myMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lastLocation.Latitude, lastLocation.Longitude), Distance.FromMiles(10)));
                    }
                }
                else if (location != null)
                {
                    Debug.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");

                    myMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(10)));
                }

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {

                    conn.CreateTable<User>();// get the table
                    var post = conn.Table<Venue>().ToList();   //return list of  info from db


                    //DisplayInMap(post); //passing a list to the history xaml page
                }

               
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Debug.WriteLine("Feature Not Supported Exeception: " + fnsEx.Message);
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Debug.WriteLine("Permission Exeception: " + pEx.Message);
            }
            catch (Exception ex)
            {
                // Unable to get location
                Debug.WriteLine("Exeception: " + ex.Message);
            }
        }



        public void DisplayInMap(List<Venue> post)
        {
            foreach(var p in post)
            {
                try
                {


                    var position = new Xamarin.Forms.Maps.Position(p.Latitude, p.Longitude);

                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = p.VenueName,
                        Address = p.Address
                    };
                    myMap.Pins.Add(pin);
                }catch(NullReferenceException nre) { }
                catch(Exception e) { }
            }
        }

    }
}