using Budget.Model;

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;

namespace Budget.ViewModels {
    public class CategoryPageModel {

        public ICommand PageAppearCommand { get; set; }

        public ObservableCollection<string> Categories { get; set; }

        public ObservableCollection<CategoryExpenses> CategoryExpenses { get; set; }

        public CategoryPageModel() {

            Categories = new ObservableCollection<string>();
            CategoryExpenses = new ObservableCollection<CategoryExpenses>();
            PageAppearCommand = new Command(AppearAction);
        }

        private void AppearAction() {

            GetCategories();
            ExpensePerCategory();
        }

        private void GetCategories() {

            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Heath");
            Categories.Add("Food");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        private void ExpensePerCategory() {

            CategoryExpenses.Clear();

            float TotalExpemneAmmount = Exenpse.TotalExpenseAmmount();
            foreach (var c in Categories) {

                var expenses = Exenpse.GetExpenses(c);
                var porcentageAmmount = expenses.Sum(e => e.Ammount);

                CategoryExpenses ce = new CategoryExpenses() {
                    Category = c,
                    Porcentage = porcentageAmmount / TotalExpemneAmmount
                };

                CategoryExpenses.Add(ce);
            }
        }

    }
}
