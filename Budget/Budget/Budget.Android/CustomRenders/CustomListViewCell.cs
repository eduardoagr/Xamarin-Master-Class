

using Android.Content;
using Android.Views;

using Budget.Droid.CustomRenders;

using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ListView), typeof(CustomListViewCell))]
namespace Budget.Droid.CustomRenders {
    public class CustomListViewCell : TextCellRenderer {

        private Android.Views.View _cell;
        private bool _isSelected;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context) {

            _cell = base.GetCellCore(item, convertView, parent, context);
            _isSelected = false;

            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnCellPropertyChanged(sender, e);

            if (e.PropertyName == "IsSelected") {

                _isSelected = !_isSelected;

                if (_isSelected) {

                    _cell.SetBackgroundColor(Color.FromHex("#E6E6E6").ToAndroid());

                } else {

                    _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }
        }
    }
}