using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Views;
using Android.Content;
using CustomRenderer;
using CustomRenderer.Droid.Control;
using Spotlight;

[assembly: ExportRenderer(typeof(MainPage), typeof(SpotLightRenderer))]
namespace CustomRenderer.Droid.Control
{
    public class SpotLightRenderer : PageRenderer
    {
        private Android.Views.View view;
        private Android.Widget.Button button1;
        private Android.Widget.Button button2;
        private Android.Widget.Button button3;
        public SpotLightRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }


            view = MainActivity.Instance.LayoutInflater.Inflate(Resource.Layout.SpotLight, this, false);
            AddView(view);


            view.Click += View_Click;

            button1 = view.FindViewById<Android.Widget.Button>(Resource.Id.firstButton);
            button2 = view.FindViewById<Android.Widget.Button>(Resource.Id.secondButton);
            button3 = view.FindViewById<Android.Widget.Button>(Resource.Id.thirdButton);


        }

        bool isShown_FirstButton_SpotLight = false;
        bool isShown_SecondButton_SpotLight = false;
        bool isShown_ThirdButton_SpotLight = false;
        private void View_Click(object sender, EventArgs e)
        {
            if (!isShown_FirstButton_SpotLight)
            {
                show(button1, "First Button", "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "FirstButton");
                isShown_FirstButton_SpotLight = true;
                return;
            }
            if (!isShown_SecondButton_SpotLight)
            {
                show(button2, "Second Button", "Sed do eiusmod tempor incididunt ut labore eta", "SecondButton");
                isShown_SecondButton_SpotLight = true;
                return;
            }
            if (!isShown_ThirdButton_SpotLight)
            {
                show(button3, "Third Button", "Ut enim ad minim veniam, quis nostrud exercitation", "ThirdButton");
                isShown_ThirdButton_SpotLight = true;
                return;
            }
        }

        void show(Android.Views.View view, string title, string subTitle, string usageId)
        {
            new SpotlightView.Builder(MainActivity.Instance)
                .IntroAnimationDuration(400)
                .EnableRevealAnimation(true)
                .PerformClick(true)
                .FadeinTextDuration(400)
                .HeadingTvColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .HeadingTvSize(32)
                .HeadingTvText(title)
                .SubHeadingTvColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .SubHeadingTvSize(16)
                .SubHeadingTvText(subTitle)
                .MaskColor(Android.Graphics.Color.ParseColor("#dc000000"))
                .Target(view)
                .LineAnimDuration(400)
                .LineAndArcColor(Android.Graphics.Color.ParseColor("#eb273f"))
                .DismissOnTouch(true)
                .DismissOnBackPress(true)
                .EnableDismissAfterShown(true)
                .UsageId(usageId)
                .ShowTargetArc(true)
                .Show();
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

            view.Measure(msw, msh);
            view.Layout(0, 0, r - l, b - t);
        }
    }
}
