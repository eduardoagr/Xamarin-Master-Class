using Budget.Pages;

using Syncfusion.Licensing;

using Xamarin.Forms;

namespace Budget {
    public partial class App : Application {
        private const string LicenseKey = "NTg2MzY4QDMxMzkyZTM0MmUzMFJJTUZ0V1REa21QV0EvQk1zZytJMkg1eDZhQ0xtSGI5LzZkY05nTTdwZDA9";

        public static string DatbasePath = string.Empty;

        public App() {

            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());

        }  

        public App(string Db) {

            SyncfusionLicenseProvider.RegisterLicense(LicenseKey);

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
