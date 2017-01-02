using BakkalAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Bakkal.Views
{
    public sealed partial class LoginView : Page
    {

        public LoginView()
        {
            this.InitializeComponent();
        }


        private async void LoginRequiest()
        {
            var model = new LoginModel()
            {
                Email = "onurantmil@gmail.com",
                Password = "2255"
            };

            var result = await App.Client.Login(model);

            if(result.IsSuccess == true)
            {
                App.Client.SetToken(result.Token);
                ProfileView.user = await App.Client.GetMe();
                ApplicationData.Current.LocalSettings.Values["Token"] = result.Token;
                Frame.Navigate(typeof(MainPage));
            }
        }

        private void login_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LoginRequiest();
        }

        private void exit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}