using LocationApp.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationApp.ASSET
{
    public class GenerateVenue
    {
        //the function been called to get the venue
        public static string GenerateURL(double latitude, double longitude)
        {
            return string.Format(Constant.VENUE_SEARCH, latitude, longitude, Constant.CLIENT_ID, Constant.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));
        }

        
    }
}
