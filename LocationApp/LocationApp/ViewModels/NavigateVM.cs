using LocationApp.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationApp.ViewModels
{
    public class NavigateVM
    {
        public IRegisterCommand registerCommand { get; set; }
        public INeweTravelNavigateCoommand travelNavigateCoommand { get; set; }
        public NavigateVM()
        {
            //Register User
            registerCommand = new IRegisterCommand(this);
            travelNavigateCoommand = new INeweTravelNavigateCoommand(this);
            //Forgot Password Navigation command
            //forgotpasswordCommand = new ForgotPasswordCommand(this);

            // loginCommand = new LoginCommand(this);


        }


    }
}
