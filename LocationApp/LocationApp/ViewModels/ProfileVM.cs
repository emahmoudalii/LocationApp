using LocationApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using static LocationApp.Models.VenueModel;

namespace LocationApp.ViewModels
{
   public  class ProfileVM: INotifyPropertyChanged
    {
        public ObservableCollection<Profile> ProfileList { get; set; }


        public ProfileVM()
        {
            ProfileList = new ObservableCollection<Profile>();
        }
       //public List<Profile> ProfileList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        internal void Display()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                conn.CreateTable<Venue>();// get the table
                if (ProfileList != null)
                {                      // clearing the list
                    ProfileList.Clear();
                }
                var post = conn.Table<Venue>().ToList();   //return list of  info from db
                List<Profile> list = new List<Profile>();

                Profile po = new Profile();
                foreach (var p in post)
                {
                    var venueName = p.VenueName;

                    var NumberCount = post.FindAll(x => x.VenueName == venueName).Count;

                    //Dictionary<string, int> dict = new Dictionary<string, int>()
                    //{
                    //    {venueName,NumberCount},
                    //};
                    var pro = new Profile
                    {
                        Count = NumberCount,
                        VenueName = venueName
                    };

                    list.Add(pro);

                    //adding the list to observable
                    foreach (var j in list)
                        ProfileList.Add(j);
                }
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
