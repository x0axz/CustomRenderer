﻿using Xamarin.Forms;
using CustomRenderer.Views;

namespace CustomRenderer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CameraPreview.OnSubscribe();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CameraPreview.OnUnsubscribe();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                MessagingCenter.Send<object>(this, "A");
                Device.BeginInvokeOnMainThread(() => Navigation.PushModalAsync(new ButtonPage()));
            }
            catch { }
        }
    }
}
