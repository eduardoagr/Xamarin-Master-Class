using Budget.Model;
using Budget.Services;

using PropertyChanged;

using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Budget.ViewModels {

    [AddINotifyPropertyChangedInterface]
    public class NewExpenssPageModel {

        public Expense Exenpse { get; set; }

        public ObservableCollection<string> Categories { get; set; }

        public Command DissmissCommand { get; set; }

        public Command SaveCommand { get; set; }

        public NewExpenssPageModel() {

            DissmissCommand = new Command(CloseWindow);
            SaveCommand = new Command(SaveContentCommand);
            Categories = new ObservableCollection<string>();
            GetCategories();

            Exenpse = new Expense();
        }


        private void SaveContentCommand() {

            if (string.IsNullOrEmpty(Exenpse.Name)
                && string.IsNullOrEmpty(Exenpse.Description)
                && Exenpse.Ammount <= 0
                && string.IsNullOrEmpty(Exenpse.Catergory)) {

                Application.Current.MainPage.DisplayAlert("Error", "Please filled out your expense", "OK");

            } else {
                var res = Database.InsertExpense(Exenpse);
                if (res > 0) {
                    App.Current.MainPage.Navigation.PopModalAsync();
                }
            }


        }

        private void CloseWindow() {
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        private void GetCategories() {

            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Heath");
            Categories.Add("Food");
            Categories.Add("Travel");
            Categories.Add("Recreation");
            Categories.Add("Other");
        }
    }
}
