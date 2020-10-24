using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CustomRenderer.Services.Interfaces;
using Xamarin.Forms;

namespace CustomRenderer.ViewModels
{
    public class FormViewModel : ABaseViewModel
    {

        public FormViewModel(
            IUserDialogs userDialogs,
            INavigationService navigationService) : base(
                nameof(FormViewModel),
                userDialogs,
                navigationService)
        {
        }

        public async Task FormDataButton()
        {
            try
            {
                await DialogService.AlertAsync("Congrats");
            }
            catch (Exception error)
            {
                await DialogService.AlertAsync(error.Message, "Error", "OK");
            }
        }

        #region Bindable Commands
        public ICommand FormButtonCommand => new Command(async () => await FormDataButton());
        #endregion

    }
}
