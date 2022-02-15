using Budget.Model;
using Budget.Pages;

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

namespace Budget.ViewModels {
    public class ExpensesPageModel {

        public ObservableCollection<Exenpse> Exenpses { get; set; }

        public ICommand NewExpense { get; set; }

        public ExpensesPageModel() {

            Exenpses = new ObservableCollection<Exenpse>();

            NewExpense = new Command(NewExpenseAction);

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
            App.Current.MainPage.Navigation.PushAsync(new NewExpensesPage());
        }

    }
}