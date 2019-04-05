using LocationApp.Models;
using LocationApp.RestClients;
using LocationApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LocationApp.Command
{
  public   class LoginUserCmmand:ICommand
    {
        public LoginVM loginVM { get; set; }
        public LoginUserCmmand(LoginVM loginVM)
        {
            this.loginVM = loginVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
          var user=  (User)parameter;
            if(user.Email=="")
            {
                return false;
            }
            if (user.Password == "")
            {
                return false;
            }

            return true;
        }

        public async void Execute(object parameter)
        {
            var user = (User)parameter;

            EbClient ebClient = new EbClient();
          var joko=  await ebClient.LoginUser(user);

            

        }
    }
}
