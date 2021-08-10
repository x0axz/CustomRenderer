using Xamarin.Forms;

namespace CustomRenderer.Services
{
    public interface ISpotLight
    {
        void ShowSpotLight_FirstButton(View view, string usageId);
        void ShowSpotLight_SecondButton(View view, string usageId);
        void ShowSpotLight_ThirdButton(View view, string usageId);
    }
}
