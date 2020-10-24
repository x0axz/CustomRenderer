using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CustomRenderer.ViewModels;

namespace CustomRenderer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormPage : ContentPage
    {
		public FormPage()
		{
			InitializeComponent();
			BindingContext = new FormViewModel(default, default);
		}
	}
}