using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LocationApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new MainPage();
        }
        //creating the database, we set up a constructor
        public App(string databaseLocation)
        {
            XF.Material.Forms.Material.Init(this);
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            DatabaseLocation = databaseLocation;

        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
