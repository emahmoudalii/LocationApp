using LocationApp.Logics;
using LocationApp.ViewModels;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs;

namespace LocationApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
        public VenueVM venueVM { get; set; }
        public NewTravelPage()
        {

            try
            {
               // OnAppearing();
               venueVM = new VenueVM();
              BindingContext = venueVM;
                InitializeComponent();
            }
            catch (Exception e)
            {
               if(e.InnerException==null)
                {
                    Console.WriteLine("InnerException{0}", e.InnerException);
                }
            }

        }


        //protected async override void OnAppearing()
        //{
        //    VenueLogic v = new VenueLogic();
        //    var loadingDialog = await MaterialDialog.Instance.LoadingDialogAsync(message: "Getting Location");

        //    var locator = CrossGeolocator.Current;
        //    var location = await locator.GetPositionAsync();
        //    //var request = new GeolocationRequest(GeolocationAccuracy.Medium);
        //    //var location = await Geolocation.GetLocationAsync(request).ConfigureAwait(false); ; // for current location; // for current location
        //    BindingContext = new VenueVM
        //    {
        //        VenueList = await v.GetVenues(location.Latitude, location.Longitude)
        //    };
        //    // venueListView.ItemsSource = await v.GetVenues(location.Latitude, location.Longitude);


        //    // var VenueList = await v.GetVenues(location.Latitude, location.Longitude);
        //    //  venueListView.ItemsSource = VenueList;
        //    await loadingDialog.DismissAsync();

        //    base.OnAppearing();
        //}
        protected  override async void OnAppearing()
        {
            
            Device.BeginInvokeOnMainThread(async () =>
            {

                VenueLogic v = new VenueLogic();
               

                var loadingDialog = await MaterialDialog.Instance.LoadingDialogAsync(message: "Getting Location");
                var locator = CrossGeolocator.Current;  //get the current location

                var location = await locator.GetPositionAsync();





                //pass the longitude and latitude
              //  var venues = await v.GetVenues(location.Latitude, location.Longitude);

                //venueListView.ItemsSource = venues;
                //venueVM.VenueList = venues;
               // var vm = new VenueVM();

                
                BindingContext = new VenueVM()

                {
                    VenueList =  await venueVM.GetVenues(location.Latitude,location.Longitude)
                };
                //    //passsing list to view
                // venueListView.ItemsSource = venues;
                await loadingDialog.DismissAsync();
                base.OnAppearing();

            });
           
        }
    }
}
