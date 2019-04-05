using LocationApp.ASSET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static LocationApp.Models.VenueModel;

namespace LocationApp.Logics
{
    public class VenueLogic
    {
        public async Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();
            //List<Venue> venues = new List<Venue>();
            //calls the Generate URL
            var url = GenerateVenue.GenerateURL(latitude, longitude);
            using (HttpClient client = new HttpClient())
            {
                //this is the function that calls the foursquare api
                var response = await client.GetAsync(url);
                //convert the json t+o string 
                var json = await response.Content.ReadAsStringAsync();

                //the venue root consisit of response and the venue consist of Venue, so we cal as well call the venue root
                var VenueRoot = JsonConvert.DeserializeObject<List<Venue>>(json);
                venues = /*(List<Venue>)VenueRoot.response.venues;*/VenueRoot;

                return venues;
            }
        }


    }
}

