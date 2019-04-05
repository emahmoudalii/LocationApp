using LocationApp.ASSET;
using LocationApp.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static LocationApp.Models.VenueModel;

namespace LocationApp.ViewModels
{
    public class VenueVM : INotifyPropertyChanged
    {






        public List<Venue> VenueList { get; set; }



        public VenueVM(Venue venue)
        {
           this.Venuess = venue;
            Venuess = new Venue();
            Venuee = new Venue();
            VenueList = new List<Venue>();
        }


  
        private Venue venuess;

        public Venue Venuess
        {
            get { return venuess; }
            set
            {
                venuess = value;

                OnPropertyChanged("Venuess");
            }
        }
        private Venue venuee;

        public Venue Venuee
        {
            get { return venuee; }
            set
            {
                venuee = value;
                if (venuee != null)
                {
                    Venuess = new Venue
                    {

                        VenueName = venuee.name,
                        Address = venuee.location.address,
                        distance = venuee.location.distance,
                        Experience = this.experience,
                    };
                }
               
                OnPropertyChanged("Venuee");
            }
        }
        private string experience;

        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                if(venuee!=null)
                {
                    Venuess = new Venue
                    {

                        VenueName = venuee.name,
                        Address = venuee.location.address,
                        distance = venuee.location.distance,
                        Latitude = venuee.location.lat,
                        Longitude=venuee.location.lng,

                        Experience = this.experience,
                    };
                }
               

                OnPropertyChanged("Experience");
            }
        }


        public class VenueListo
        {
            public List<Venue> Venueistos{ get; set; }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        public IAddNewtRAVELpAGECommand addNewtRAVELpAGECommand { get; set; }

        public VenueVM()
        {
            addNewtRAVELpAGECommand = new IAddNewtRAVELpAGECommand(this);
        }

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
                var VenueRoot = JsonConvert.DeserializeObject<VenueList>(json);
              var j=  (JObject)JsonConvert.DeserializeObject(json);
               
                venues = (List<Venue>)VenueRoot.response.venues;

                return venues;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
