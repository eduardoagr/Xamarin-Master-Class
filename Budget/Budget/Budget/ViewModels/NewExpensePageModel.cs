

using Budget.Model;

using PropertyChanged;

using Rg.Plugins.Popup.Services;

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

namespace Budget.ViewModels {

    [AddINotifyPropertyChangedInterface]
    public class NewExpensePageModel {

        public ICommand SaveCommand { get; set; }

        public ICommand CloseComand { get; set; }

        public ObservableCollection<string> Categories { get; set; }

        public Exenpse Exenpse { get; set; }

        public NewExpensePageModel() {

            CloseComand = new Command(CloseAction);

            SaveCommand = new Command(SaveAction);

            Categories = new ObservableCollection<string>();

            Exenpse = new Exenpse();

            GetCategories();

            Exenpse = new Exenpse() {
                Name = Exenpse.Name,
                Ammount = Exenpse.Ammount,
                Description = Exenpse.Description,
                Date = DateTime.Today,
                Catergory = Exenpse.Catergory
            };

        }

        private void CloseAction() {
            PopupNavigation.Instance.PopAsync();
        }

        private void GetCategories() {

            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Heath");
            Categories.Add("Food");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        private void SaveAction() {

            int response = Exenpse.InsertExpense(Exenpse);

            if (response > 0) {
                Application.Current.MainPage.Navigation.PopAsync();
            } else {
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserted", "OK");
            }
        }
    }
}
