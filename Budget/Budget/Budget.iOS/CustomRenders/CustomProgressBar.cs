using Budget.iOS.CustomRenders;

using CoreGraphics;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBar))]
namespace Budget.iOS.CustomRenders {
    public class CustomProgressBar : ProgressBarRenderer {

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e) {
            base.OnElementChanged(e);

            if (double.IsNaN(e.NewElement.Progress))
                Control.ProgressTintColor = Color.FromHex("#00B9AE").ToUIColor();
            else if (e.NewElement.Progress < 0.3)
                Control.ProgressTintColor = Color.FromHex("#008DD5").ToUIColor();
            else if (e.NewElement.Progress < 0.5)
                Control.ProgressTintColor = Color.FromHex("#2D76BA").ToUIColor();
            else if (e.NewElement.Progress < 0.7)
                Control.ProgressTintColor = Color.FromHex("#5A5F9F").ToUIColor();
            else if (e.NewElement.Progress < 0.9)
                Control.ProgressTintColor = Color.FromHex("#B3316A").ToUIColor();
            else
                Control.ProgressTintColor = Color.FromHex("#e01a4f").ToUIColor();


            LayoutSubviews();
        }

        public override void LayoutSubviews() {
            base.LayoutSubviews();

            float x = 1.0f;
            float y = 4.0f;

            CGAffineTransform affineTransform = CGAffineTransform.MakeScale(x, y);
            Transform = affineTransform;
        }
    }
}