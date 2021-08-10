using System;
using Xamarin.Forms;
using CustomRenderer.Views;
using Xamarin.Essentials;
using CustomRenderer.Effects;
using CustomRenderer.Services;

namespace CustomRenderer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            LayoutChanged += FirstButton_SpotLight;
            LayoutChanged += SecondButton_SpotLight;
            LayoutChanged += ThirdButton_SpotLight;
        }


        bool isShown_FirstButton_SpotLight = false;
        private void FirstButton_SpotLight(object sender, EventArgs e)
        {
            if (!isShown_FirstButton_SpotLight)
            {
                DependencyService.Get<ISpotLight>().ShowSpotLight_FirstButton(FirstButton, "FirstButton");
                isShown_FirstButton_SpotLight = true;
            }
        }


        bool isShown_SecondButton_SpotLight = false;
        private void SecondButton_SpotLight(object sender, EventArgs e)
        {
            if (!isShown_SecondButton_SpotLight)
            {
                DependencyService.Get<ISpotLight>().ShowSpotLight_SecondButton(SecondButton, "SecondButton");
                isShown_SecondButton_SpotLight = true;
            }
        }

        bool isShown_ThirdButton_SpotLight = false;
        private void ThirdButton_SpotLight(object sender, EventArgs e)
        {
            if (!isShown_ThirdButton_SpotLight)
            {
                DependencyService.Get<ISpotLight>().ShowSpotLight_ThirdButton(ThirdButton, "ThirdButton");
                isShown_ThirdButton_SpotLight = true;
            }
        }

        protected override void OnAppearing()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await SecureStorage.SetAsync("ShapeScale", "0.6");
            });

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
