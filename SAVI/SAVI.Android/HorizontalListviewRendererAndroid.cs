using System;
using System.ComponentModel;
using SAVI;
using SAVI.CustomControl;
using SAVI.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(HorizontalListview), typeof(HorizontalListviewRendererAndroid))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace SAVI.Droid
{
    [Obsolete]
    public class HorizontalListviewRendererAndroid : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
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
            if (ChildCount > 0)
            {
                GetChildAt(0).HorizontalScrollBarEnabled = false;
                GetChildAt(0).VerticalScrollBarEnabled = false;
            }
        }
    }
}