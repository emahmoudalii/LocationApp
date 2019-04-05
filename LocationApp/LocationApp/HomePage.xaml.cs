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
    public partial class HomePage : TabbedPage
    {
        public NavigateVM navigateVm { get; set; }
        public HomePage()
        {
            navigateVm = new NavigateVM();
            BindingContext = navigateVm;
            InitializeComponent();
        }
    }
}