using Budget.Interfaces;
using Budget.Model;
using Budget.Services;

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

using Xamarin.Essentials;
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

            var localFolder = FileSystem.AppDataDirectory;

            var file = Path.Combine(localFolder, "Reports.txt");

            using (StreamWriter writer = new StreamWriter(Path.GetFullPath(file))) {

                foreach (var ce in CategoryExpenses) {

                    writer.WriteLine($"{ce.Category} - {ce.Porcentage}$");
                }
            }
            var share = DependencyService.Get<IShare>();

            share.Show("Expense report", "Here is your report", file);
        }
    }
}
