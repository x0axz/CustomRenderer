using Xamarin.Forms;

namespace CustomRenderer.Views
{
    public class FirstCameraPageCS : ContentPage
    {
        public FirstCameraPageCS()
        {
            Title = "Picture";
            Padding = new Thickness(0, 20, 0, 0);
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Picture" },
                    new CameraPreview {
                        Camera = CameraOptions.Rear,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    }
                }
            };
        }
    }
}
