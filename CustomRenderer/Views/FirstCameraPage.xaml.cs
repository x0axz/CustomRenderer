using System;
using Xamarin.Forms;

namespace CustomRenderer.Views
{
    public partial class FirstCameraPage : ContentPage
    {
        public FirstCameraPage()
        {
            InitializeComponent();
        }

        public void IDCamera_Clicked(object sender, EventArgs args)
        {
            try
            {
                MessagingCenter.Send<object>(this, "A");
                Device.BeginInvokeOnMainThread(() => Navigation.PushModalAsync(new FormPage()));
            }
            catch (Exception error)
            {
                if (error.InnerException != null)
                {
                    DisplayAlert("Error", error.InnerException.Message, "Ok");
                }
            }
        }
    }
}
