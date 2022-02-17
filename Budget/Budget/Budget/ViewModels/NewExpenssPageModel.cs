using Budget.Model;

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

namespace Budget.ViewModels {
    public class NewExpenssPageModel {

        public Exenpse Exenpse { get; set; }

        public ObservableCollection<string> Categories { get; set; }

        public ICommand DissmissCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public NewExpenssPageModel() {

            DissmissCommand = new Command(CloseWindow);
            SaveCommand = new Command(SaveContentCommand);
            Categories = new ObservableCollection<string>();
            GetCategories();

            Exenpse = new Exenpse();
        }

        private void SaveContentCommand() {
            throw new NotImplementedException();
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
            Categories.Add("Other");
        }
    }
}
