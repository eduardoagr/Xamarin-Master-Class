using System.Collections.ObjectModel;

namespace Budget.ViewModels {
    public class CategoryPageModel {

        public ObservableCollection<string> Categories { get; set; }

        public CategoryPageModel() {

            Categories = new ObservableCollection<string>();
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
    }
}
