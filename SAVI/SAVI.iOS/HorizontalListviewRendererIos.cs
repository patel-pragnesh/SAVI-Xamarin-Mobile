using SAVI.CustomControl;
using SAVI.iOS;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HorizontalListview), typeof(HorizontalListviewRendererIos))]
namespace SAVI.iOS
{
    public class HorizontalListviewRendererIos : ScrollViewRenderer
    {
        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            base.OnElementChanged(e);

            var element = e.NewElement as HorizontalListview;
            element?.Render();
            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;

            e.NewElement.PropertyChanged += OnElementPropertyChanged;
        }

        protected void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.ShowsHorizontalScrollIndicator = false;
            this.ShowsVerticalScrollIndicator = false;
            this.AlwaysBounceHorizontal = false;
            this.AlwaysBounceVertical = false;
            this.Bounces = false;

        }
    }
}