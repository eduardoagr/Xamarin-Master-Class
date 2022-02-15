

using Budget.Model;

using PropertyChanged;

using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

namespace Budget.ViewModels {

    [AddINotifyPropertyChangedInterface]
    public class NewExpensePageModel {

        public ObservableCollection<string> Categories { get; set; }

        public ICommand SaveCommand { get; set; }

        public Exenpse Exenpse { get; set; }

        public NewExpensePageModel() {
            SaveCommand = new Command(SaveAction);

            Categories = new ObservableCollection<string>();

            Exenpse = new Exenpse();

            GetCategories();

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

            Exenpse = new Exenpse() {
                Name = Exenpse.Name,
                Ammount = Exenpse.Ammount,
                Descriion = Exenpse.Descriion,
                Date = Exenpse.Date,
                Catergory = Exenpse.Catergory
            };

            int response = Exenpse.InsertExpense(Exenpse);

            if (response > 0) {
                Application.Current.MainPage.Navigation.PopAsync();
            } else {
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserted", "OK");
            }

        }
    }
}
