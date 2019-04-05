using LocationApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LocationApp.Command
{
    public class IRegisterCommand : ICommand
    {

        public NavigateVM navigateVM { get; set; }
        public IRegisterCommand(NavigateVM navigateVM)
        {

            this.navigateVM = navigateVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new RegisterPage());

            }
            catch (Exception ex)
            {

            }


        }


    }
}
