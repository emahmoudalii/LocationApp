using LocationApp.Models;
using LocationApp.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static LocationApp.Models.VenueModel;

namespace LocationApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
        public ProfileVM profileVM { get; set; }
		public ProfilePage ()
		{
            profileVM = new ProfileVM();
            BindingContext = profileVM;
			InitializeComponent ();
		}


        protected override void OnAppearing()
        {
            base.OnAppearing();

            profileVM.Display();




                //DisplayInMap(post); //passing a list to the history xaml page
            }


            
        }
    }
