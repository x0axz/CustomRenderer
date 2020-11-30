using Acr.UserDialogs;
using CustomRenderer.Services.Interfaces;

namespace CustomRenderer.ViewModels
{
    public class FirstCameraViewModel : ABaseViewModel
    {

        public FirstCameraViewModel(
            IUserDialogs userDialogs,
            INavigationService navigationService
            ) : base(
                "FirstCamera",
                userDialogs,
                navigationService
           )
        {
        }
    }
}
