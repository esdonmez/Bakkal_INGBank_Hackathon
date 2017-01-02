using System;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Bakkal.Views
{
    public sealed partial class StartView : Page
    {

        public StartView()
        {
            this.InitializeComponent();
            this.InitializeUI();
        }


        private async void InitializeUI()
        {
            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            {
                var statusBar = StatusBar.GetForCurrentView();
                await statusBar.HideAsync();
            }
        }

        private void Register_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterView));
        }

        private void Login_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginView));
        }
    }
}