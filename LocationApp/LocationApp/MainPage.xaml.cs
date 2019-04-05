using LocationApp.RestClients;
using LocationApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocationApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
       
            private NavigateVM navigateVM;
            public MainPage()
            {
                navigateVM = new NavigateVM();
                BindingContext = navigateVM;
                InitializeComponent();
            }

        protected  async override void OnAppearing()
        {
            EbClient eb = new EbClient();
            await eb.GetUserAsync();
            base.OnAppearing();
        }

    }

}