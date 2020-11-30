using Acr.UserDialogs;
using CustomRenderer.Services.Interfaces;

namespace CustomRenderer.ViewModels
{
    public class ButtonViewModel : ABaseViewModel
    {
        public ButtonViewModel(
            IUserDialogs userDialogs,
            INavigationService navigationService) : base(
                "Button",
                userDialogs,
                navigationService)
        {
        }

    }
}
