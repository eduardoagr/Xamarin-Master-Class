using Budget.Model;
using Budget.Pages;
using Budget.Services;

using PropertyChanged;

using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Budget.ViewModels {
    public class ExpensesPageModel {

        public Command PageAppearCommand { get; set; }

        public Command NewExpense { get; set; }

        public ObservableCollection<Exenpse> Exenpses { get; set; }

        public ExpensesPageModel() {

            Exenpses = new ObservableCollection<Exenpse>();

            NewExpense = new Command(NewExpenseAction);

            PageAppearCommand = new Command(AppearAction);
        }

        private void AppearAction() {
            GetExpenses();
        }

        private void GetExpenses() {
            var expense = Database.GetExpenses();

            Exenpses.Clear();
            foreach (var ex in expense) {
                Exenpses.Add(ex);
            }
        }

        private void NewExpenseAction() {

            Application.Current.MainPage.Navigation.PushModalAsync(new NewExpensePage());
        }
    }
}