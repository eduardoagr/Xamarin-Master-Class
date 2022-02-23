using Budget.iOS.CustomRenders;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CollectionView), typeof(CustomCollectionView))]
namespace Budget.iOS.CustomRenders {
    public class CustomCollectionView : CollectionViewRenderer {


        protected override void OnElementChanged(ElementChangedEventArgs<GroupableItemsView> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null) {

                Controller.CollectionView.ScrollEnabled = false;
            }
        }

    }
}