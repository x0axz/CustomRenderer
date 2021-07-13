using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using System;
using System.ComponentModel;
using Android.Content;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CustomRenderer;
using CustomRenderer.Droid.Renderers;
using CustomRenderer.Droid.Views;

[assembly: ExportRenderer(typeof(OverlayView), typeof(OverlayViewRenderer))]
namespace CustomRenderer.Droid.Renderers
{
    public class OverlayViewRenderer : ViewRenderer<OverlayView, NativeOverlayView>
    {
        public OverlayViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<OverlayView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new NativeOverlayView(Context));
            }

            if (e.NewElement != null)
            {
                Control.Opacity = (float)Element.OverlayOpacity;
                Control.ShowOverlay = Element.ShowOverlay;
                Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToAndroid();
                Control.Shape = Element.Shape;
            }

            if (e.OldElement != null)
            {

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == OverlayView.OverlayOpacityProperty.PropertyName)
            {
                Control.Opacity = (float)Element.OverlayOpacity;
            }
            else if (e.PropertyName == OverlayView.OverlayBackgroundColorProperty.PropertyName)
            {
                Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToAndroid();
            }
            else if (e.PropertyName == OverlayView.ShapeProperty.PropertyName)
            {
                Control.Shape = Element.Shape;
            }
            else if (e.PropertyName == OverlayView.ShowOverlayProperty.PropertyName)
            {
                Control.ShowOverlay = Element.ShowOverlay;
            }
            else if (e.PropertyName == OverlayView.ShapeScaleProperty.PropertyName)
            {
                Control.ShapeScale = Element.ShapeScale;
            }
        }
    }
}