using System;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Bakkal
{
    public sealed partial class MainPage : Page
    {

        public MainPage()
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

            marketButton.Opacity = 1;
            shoppingButton.Opacity = 0.4;
            notificationButton.Opacity = 0.4;
            profileButton.Opacity = 0.4;
            iframe.Navigate(typeof(Views.MarketsView));
        }

        private void marketButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            marketButton.Opacity = 1;
            shoppingButton.Opacity = 0.4;
            notificationButton.Opacity = 0.4;
            profileButton.Opacity = 0.4;
            iframe.Navigate(typeof(Views.MarketsView));
        }

        private void shoppingButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            marketButton.Opacity = 0.4;
            shoppingButton.Opacity = 1;
            notificationButton.Opacity = 0.4;
            profileButton.Opacity = 0.4;
            iframe.Navigate(typeof(Views.ShoppingView));
        }

        private void notificationButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            marketButton.Opacity = 0.4;
            shoppingButton.Opacity = 0.4;
            notificationButton.Opacity = 1;
            profileButton.Opacity = 0.4;
            iframe.Navigate(typeof(Views.NotificationView));
        }

        private void profileButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            marketButton.Opacity = 0.4;
            shoppingButton.Opacity = 0.4;
            notificationButton.Opacity = 0.4;
            profileButton.Opacity = 1;
            iframe.Navigate(typeof(Views.ProfileView));
        }
    }
}