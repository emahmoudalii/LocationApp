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
	public partial class RegisterPage : ContentPage
	{
        public UserVM userVM { get; set; }
        public RegisterPage()
        {
            //  joko.sour
            userVM = new UserVM();
            BindingContext = userVM;
            InitializeComponent();
        }
    }
}