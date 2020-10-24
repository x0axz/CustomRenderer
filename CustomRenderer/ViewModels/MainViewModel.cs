using System.Threading.Tasks;
using Acr.UserDialogs;
using CustomRenderer.Services.Interfaces;

namespace CustomRenderer.ViewModels
{
    public class MainViewModel : ABaseViewModel
    {
        public MainViewModel(
            IUserDialogs userDialogs,
            INavigationService navigationService
        ) : base(
                nameof(MainViewModel),
                userDialogs,
                navigationService
        )
        {
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
        }
    }
}
