
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;

using Budget.Droid.CustomRenders;

using System.ComponentModel;


using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomViewCell))]
namespace Budget.Droid.CustomRenders {
    internal class CustomViewCell : TextCellRenderer {

        private Android.Views.View _cellCore;
        private Drawable _DefaaultBackgrounnd;
        private bool _selected;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context) {
            _cellCore = base.GetCellCore(item, convertView, parent, context);

            _selected = false;
            _DefaaultBackgrounnd = _cellCore.Background;


            return _cellCore;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnCellPropertyChanged(sender, e);

            if (e.PropertyName == "IsSelected") {
                _selected = !_selected;

                if (_selected) {
                    _cellCore.SetBackgroundColor(Color.FromHex("#E6E6E6E6").ToAndroid());
                } else {
                    _cellCore.Background = _DefaaultBackgrounnd;
                }
            }
        }
    }
}