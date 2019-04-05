using LocationApp.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using XF.Material.Forms.UI.Dialogs;
using static LocationApp.Models.VenueModel;

namespace LocationApp.Command
{
    public class IAddNewtRAVELpAGECommand : ICommand
    {
        public VenueVM venueVM { get; set; }
        public IAddNewtRAVELpAGECommand(VenueVM venueVM)
        {
            this.venueVM = venueVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
                return false;
            var venue = (Venue)parameter;

            if (venue.Experience == null)
                return false;
            return true;
        }

        public async void Execute(object parameter)
    {

            var venue = (Venue)parameter;

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);

            var loadingDialog = await MaterialDialog.Instance.LoadingDialogAsync(message: "Saving");
            conn.CreateTable<Venue>(); //create table and insert
            int rows = conn.Insert(venue); //it returns new rows inserted
            conn.Close();  //it is import
                           //loadingDialog.Dismiss();
            await loadingDialog.DismissAsync();
            await App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }
    }
}
