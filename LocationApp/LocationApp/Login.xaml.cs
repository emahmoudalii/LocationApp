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
    public partial class Login : ContentPage
    {
        public LoginVM loginVm { get; set; }
        public Login()
        {
            loginVm = new LoginVM();
            BindingContext = loginVm;
            InitializeComponent();
        }
    }
}