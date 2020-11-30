using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CustomRenderer.ViewModels;

namespace CustomRenderer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonPage : ContentPage, IRootView
    {
        public ButtonPage()
        {
            InitializeComponent();
            BindingContext = new ButtonViewModel(default, default);
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new FirstCameraPage());
            }
            catch { }
        }
    }
}
