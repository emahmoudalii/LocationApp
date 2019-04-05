using LocationApp.Models;
using LocationApp.RestClients;
using LocationApp.ViewModels;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Xml.Serialization;
using XF.Material.Forms.UI.Dialogs;

namespace LocationApp.Command
{
    public class IRegisterUserCommand : ICommand
    {
        public UserVM userVM { get; set; }
        //protected IUserDialogs Dialogs { get; }
        //private IUserDialogs Dialogs = UserDialogs.Instance;
        public IRegisterUserCommand(UserVM userVM)
        {
            this.userVM = userVM;
            // this.Dialogs = UserDialogs.Instance;

        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var user = (User)parameter;
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async void Execute(object parameter)
        {

            var loadingDialog = await MaterialDialog.Instance.LoadingDialogAsync(message: "Loading");

            //await Task.Delay(5000) // Represents a task that is running.



            // var diag = this.Dialogs.Loading("Please wait ...... Register in progress");
            var user = (User)parameter;
            EbClient ebClient = new EbClient();
          var joko= await  ebClient.RegisterUser(user);

            if (joko.IsSuccessStatusCode == true)
            {
                await loadingDialog.DismissAsync();
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());

            }
            else
            {

            }

        }
    }
}
