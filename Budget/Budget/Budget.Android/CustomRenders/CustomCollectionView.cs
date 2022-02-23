

using Android.Content;
using Android.Views;

using Budget.Droid.CustomRenders;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CollectionView), typeof(CustomCollectionView))]
namespace Budget.Droid.CustomRenders {
    internal class CustomCollectionView : CollectionViewRenderer {
        public CustomCollectionView(Context context) : base(context) { }

        public override bool OnInterceptTouchEvent(MotionEvent ev) {
            return false;
        }


        public override bool OnTouchEvent(MotionEvent ev) {
            return false;

        }
    }
}
