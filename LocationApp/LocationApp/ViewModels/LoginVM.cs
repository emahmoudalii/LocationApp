using LocationApp.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LocationApp.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        public string  Email { get; set; }
        public string Password { get; set; }

       public LoginUserCmmand loginUserCmmand { get; set; }

        public LoginVM()
        {
            loginUserCmmand = new LoginUserCmmand(this);
            //  Gender = new Gender();
            // genderCommand = new GenderCommand(this);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       
    }
}
