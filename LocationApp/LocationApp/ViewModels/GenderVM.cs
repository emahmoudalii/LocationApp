using LocationApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LocationApp.ViewModels
{
    public class GenderVM : INotifyPropertyChanged
    {



        public List<Gender> gender { get; set; }

        //  public GenderCommand genderCommand { get; set; }

        public GenderVM()
        {
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
