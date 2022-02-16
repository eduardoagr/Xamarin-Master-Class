
using Rg.Plugins.Popup.Pages;

using Xamarin.Forms.Xaml;

namespace Budget.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExpensesPage : PopupPage {
        public NewExpensesPage() {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed() {
            return true;
        }

        protected override bool OnBackgroundClicked() {
            return false;
        }
    }
}