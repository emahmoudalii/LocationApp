
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationApp.Models
{
    public class VenueModel
    {
        public class Meta
        {
            public int code { get; set; }
            public string requestId { get; set; }
        }

        public class LabeledLatLng
        {
            public string label { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
            public IList<LabeledLatLng> labeledLatLngs { get; set; }
            public int distance { get; set; }
            public string cc { get; set; }
            public string country { get; set; }
            public IList<string> formattedAddress { get; set; }
            public string postalCode { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string address { get; set; }
            public string crossStreet { get; set; }
        }

        public class Icon
        {
            public string prefix { get; set; }
            public string suffix { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pluralName { get; set; }
            public string shortName { get; set; }
            public Icon icon { get; set; }
            public bool primary { get; set; }
        }

        public class Venue
        {
            public double Longitude { get; set; }
            public double Latitude { get; set; }
            public string AdditionalInfo { get; set; }
            public string VenueName { get; set; }
            public string Address { get; set; }
            public int? distance { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            [SQLite.Ignore]
            public Location location { get; set; }
            [Ignore]
            public IList<Category> categories { get; set; }
           // public string referralId { get; set; }
           // public bool hasPerk { get; set; }
            public string Experience { get; set; }
        }

        public class Response
        {
            public IList<Venue> venues { get; set; }
            public bool confident { get; set; }
        }

        public class VenueList
        {
            public Meta meta { get; set; }
            public Response response { get; set; }
        }

    }
}
