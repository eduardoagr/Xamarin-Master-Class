using Budget.Interfaces;
using Budget.Model;
using Budget.Services;

using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;

namespace Budget.ViewModels {
    public class CategoryPageModel {

        public Command PageAppearCommand { get; set; }

        public ObservableCollection<string> Categories { get; set; }

        public ObservableCollection<CategoryExpenses> CategoryExpenses { get; set; }

        public Command ExportCommand { get; set; }

        public CategoryPageModel() {

            ExportCommand = new Command(ShareReport);
            Categories = new ObservableCollection<string>();
            CategoryExpenses = new ObservableCollection<CategoryExpenses>();
            PageAppearCommand = new Command(AppearAction);
            GetCategories();
        }

        private void AppearAction() {
            ExpensePerCategory();
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

        private void ExpensePerCategory() {

            CategoryExpenses.Clear();

            float TotalExpemneAmmount = Database.TotalExpenseAmmount();
            foreach (var c in Categories) {

                var expenses = Database.GetExpenses(c);
                var porcentageAmmount = expenses.Sum(e => e.Ammount);

                CategoryExpenses ce = new CategoryExpenses() {
                    Category = c,
                    Porcentage = porcentageAmmount / TotalExpemneAmmount
                };

                CategoryExpenses.Add(ce);
            }
        }

        public void ShareReport() {

            var share = DependencyService.Get<IShare>();

            share.Show("", "", "");
        }
    }
}
