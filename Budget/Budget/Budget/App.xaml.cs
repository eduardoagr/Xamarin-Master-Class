using Budget.Pages;

using Xamarin.Forms;

namespace Budget {
    public partial class App : Application {

        public static string DatbasePath = string.Empty;

        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }

        public App(string Db) {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());

            if (string.IsNullOrEmpty(Db)) {
                Current.MainPage.DisplayAlert("Error", "Database path not found", "OK");
            }


            DatbasePath = Db;
        }


        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
