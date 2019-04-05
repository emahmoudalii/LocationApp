using LocationApp.Command;
using LocationApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LocationApp.ViewModels
{
    public class UserVM : INotifyPropertyChanged
    {

        private User user;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }




        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                User = new User
                {
                    Email = this.email,
                    Password = this.password,
                    FirstName = this.FirstName,
                    LastName=this.lastname
                };
                OnPropertyChanged("LastName");
            }
        }


        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                User = new User
                {
                    Email = this.email,
                    Password = this.password,
                    FirstName = this.FirstName,
                    LastName = this.lastname

                };
                OnPropertyChanged("FirstName");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new User
                {
                    Email = this.email,
                    Password = this.password,
                    LastName = this.lastname
                };
                OnPropertyChanged("Email");
            }
        }


        private string password;

        public string Password

        {
            get { return password; }
            set
            {
                password = value;
                User = new User
                {
                    Email = this.email,
                    Password = this.password,
                   FirstName=this.firstname,
                   LastName=this.LastName
                };
                OnPropertyChanged("Password");
            }
        }
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public IRegisterUserCommand userCommand { get; set; }

        public UserVM()
        {
            userCommand = new IRegisterUserCommand(this);
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


