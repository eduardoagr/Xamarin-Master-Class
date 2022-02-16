using Budget.Model;
using Budget.Pages;

using Rg.Plugins.Popup.Services;

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

namespace Budget.ViewModels {
    public class ExpensesPageModel {

        public ICommand PageAppearCommand { get; set; }

        public ICommand NewExpense { get; set; }

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
            var expense = Exenpse.GetExpenses();

            Exenpses.Clear();
            foreach (var ex in expense) {
                Exenpses.Add(ex);
            }
        }

        private void NewExpenseAction() {
            PopupNavigation.Instance.PushAsync(new NewExpensesPage());
        }

    }
}