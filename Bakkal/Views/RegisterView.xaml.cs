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
    public sealed partial class RegisterView : Page
    {

        public RegisterView()
        {
            this.InitializeComponent();
            this.RegisterRequest();
        }


        private async void RegisterRequest()
        {
            var model = new RegisterModel()
            {
                Email = "onurantmil@gmail.com",
                Password = "2255",
                Name = "Onur Çelik",
                Phone = "05074406251"
            };

            var result = await App.Client.Register(model);

            if(result.IsSuccess == true)
            {
                App.Client.SetToken(result.Token);
                ProfileView.user = await App.Client.GetMe();
                ApplicationData.Current.LocalSettings.Values["Token"] = result.Token;
                Frame.Navigate(typeof(MainPage));
            }
        }

        private void exit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void register_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}