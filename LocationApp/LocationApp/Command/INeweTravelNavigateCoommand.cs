using LocationApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LocationApp.Command
{
    public class INeweTravelNavigateCoommand : ICommand
    {
        public NavigateVM navigateVM { get; set; }
        public INeweTravelNavigateCoommand(NavigateVM navigateVM)
        {
            this.navigateVM = navigateVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }
    }
}
