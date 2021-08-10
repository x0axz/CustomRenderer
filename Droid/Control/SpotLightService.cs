using Xamarin.Forms.Platform.Android;
using Android.Views;
using CustomRenderer.Services;
using CustomRenderer.Droid.Control;
using Spotlight;

[assembly: Xamarin.Forms.Dependency(typeof(SpotLightService))]
namespace CustomRenderer.Droid.Control
{
    public class SpotLightService : ISpotLight
    {
        private bool isRevealEnabled_FirstButton_SpotLight = true;
        private bool isRevealEnabled_SecondButton_SpotLight = true;
        private bool isRevealEnabled_ThirdButton_SpotLight = true;
        private SpotlightView FirstButton_SpotLight;
        private SpotlightView SecondButton_SpotLight;
        private SpotlightView ThirdButton_SpotLight;

        public void ShowSpotLight_FirstButton(Xamarin.Forms.View view, string usageId)
        {
            FirstButton_SpotLight = new SpotlightView.Builder(MainActivity.Instance)
                .IntroAnimationDuration(400)
                .EnableRevealAnimation(isRevealEnabled_FirstButton_SpotLight)
                .PerformClick(true)
                .FadeinTextDuration(400)
                .HeadingTvColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .HeadingTvSize(32)
                .HeadingTvText("First Button")
                .SubHeadingTvColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .SubHeadingTvSize(16)
                .SubHeadingTvText("Lorem ipsum dolor sit amet, consectetur adipiscing elit")
                .MaskColor(Android.Graphics.Color.ParseColor("#dc000000"))
                .Target(ConvertFormsToNative(view))
                .LineAnimDuration(400)
                .LineAndArcColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .DismissOnTouch(true)
                .DismissOnBackPress(true)
                .EnableDismissAfterShown(true)
                .UsageId(usageId)
                .ShowTargetArc(true)
                .Show();
        }

        public void ShowSpotLight_SecondButton(Xamarin.Forms.View view, string usageId)
        {
            SecondButton_SpotLight = new SpotlightView.Builder(MainActivity.Instance)
                .IntroAnimationDuration(400)
                .EnableRevealAnimation(isRevealEnabled_SecondButton_SpotLight)
                .PerformClick(true)
                .FadeinTextDuration(400)
                .HeadingTvColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .HeadingTvSize(32)
                .HeadingTvText("Second Button")
                .SubHeadingTvColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .SubHeadingTvSize(16)
                .SubHeadingTvText("Sed do eiusmod tempor incididunt ut labore eta")
                .MaskColor(Android.Graphics.Color.ParseColor("#dc000000"))
                .Target(ConvertFormsToNative(view))
                .LineAnimDuration(400)
                .LineAndArcColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .DismissOnTouch(true)
                .DismissOnBackPress(true)
                .EnableDismissAfterShown(true)
                .UsageId(usageId)
                .ShowTargetArc(true)
                .Show();
        }

        public void ShowSpotLight_ThirdButton(Xamarin.Forms.View view, string usageId)
        {
            ThirdButton_SpotLight = new SpotlightView.Builder(MainActivity.Instance)
                .IntroAnimationDuration(400)
                .EnableRevealAnimation(isRevealEnabled_ThirdButton_SpotLight)
                .PerformClick(true)
                .FadeinTextDuration(400)
                .HeadingTvColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .HeadingTvSize(32)
                .HeadingTvText("Third Button")
                .SubHeadingTvColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .SubHeadingTvSize(16)
                .SubHeadingTvText("Ut enim ad minim veniam, quis nostrud exercitation")
                .MaskColor(Android.Graphics.Color.ParseColor("#dc000000"))
                .Target(ConvertFormsToNative(view))
                .LineAnimDuration(400)
                .LineAndArcColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .DismissOnTouch(true)
                .DismissOnBackPress(true)
                .EnableDismissAfterShown(true)
                .UsageId(usageId)
                .ShowTargetArc(true)
                .Show();
        }

        public View ConvertFormsToNative(Xamarin.Forms.View view)
        {
            var vRenderer = Platform.CreateRendererWithContext(view, MainActivity.Instance);
            var Androidview = vRenderer.View;
            vRenderer.Tracker.UpdateLayout();

            var size = view.Bounds;
            var layoutParams = new ViewGroup.LayoutParams((int)size.Width, (int)size.Height);
            Androidview.LayoutParameters = layoutParams;
            view.Layout(size);
            Androidview.Layout((int)size.X, (int)size.Y, (int)view.WidthRequest, (int)view.HeightRequest);
            Androidview.SetBackgroundColor(Android.Graphics.Color.Red);
            return Androidview;
        }
    }
}
