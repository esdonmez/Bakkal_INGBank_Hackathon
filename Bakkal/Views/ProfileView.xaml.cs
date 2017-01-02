using BakkalAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Bakkal.Views
{
    public sealed partial class ProfileView : Page
    {
        private List<VeresiyeModel> veresiyeList = new List<VeresiyeModel>();
        public static UserModel user;


        public ProfileView()
        {
            this.InitializeComponent();
            this.Loaded += ProfileView_Loaded;
        }


        private async void GetVeresiyeRequest()
        {
            veresiyeList = await App.Client.Veresiye();

            if (veresiyeList != null)
            {
                for (int i = 0; i < veresiyeList.Count; i++)
                {
                    if (i % 2 == 0) veresiyeList[i].BgColor = "#FBFBFB";
                    else veresiyeList[i].BgColor = "#FFFFFF";
                }
            }
        }

        private void ProfileView_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = user;

            panel1.Opacity = 1;
            panel2.Opacity = 0;
        }

        private async void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            var newMessage = new MessageDialog("Uygulamadan çıkış yapmak istediğinize emin misiniz?", "Bildirim");
            newMessage.Commands.Add(new UICommand("Evet"));
            newMessage.Commands.Add(new UICommand("Hayır"));
            IUICommand result = await newMessage.ShowAsync();

            if (result != null && result.Label == "Evet")
            {
                ApplicationData.Current.LocalSettings.Values["Token"] = null;
                Application.Current.Exit();
            }
        }

        private void settingButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingView));
        }

        private void onlineAdvertButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            panel1.Opacity = 1;
            panel2.Opacity = 0;

            pivot.SelectedItem = pivotItem1;
        }

        private void offlineAdvertButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            panel1.Opacity = 0;
            panel2.Opacity = 1;

            pivot.SelectedItem = pivotItem2;
        }

        private void pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pivot.SelectedItem == pivotItem1)
            {
                DummyData1();
                panel1.Opacity = 1;
                panel2.Opacity = 0;
            }

            else
            {
                DummyData2();
                panel1.Opacity = 0;
                panel2.Opacity = 1;
            }
        }

        private void DummyData1()
        {
            var leftList = new List<VeresiyeModel>();

            var model1 = new VeresiyeModel()
            {
                Name = "Bizim Bakkal",
                TotalAmount = "8,5",
                Date = "06.11.2016",
                BgColor = "#f1f1f1"
            };
            var model2 = new VeresiyeModel()
            {
                Name = "Bakkal Veli",
                TotalAmount = "26",
                Date = "14.11.2016",
                BgColor = "#ffffff"
            };
            var model3 = new VeresiyeModel()
            {
                Name = "Bakkal Derya",
                TotalAmount = "45",
                Date = "12.11.2016",
                BgColor = "#f1f1f1"
            };
            leftList.Add(model1);
            leftList.Add(model2);
            leftList.Add(model3);

            list1.ItemsSource = leftList;
        }

        private void DummyData2()
        {
            var rightList = new List<VeresiyeModel>();

            var model1 = new VeresiyeModel()
            {
                Name = "Bakkal Ali",
                TotalAmount = "26",
                Date = "01.11.2016",
                BgColor = "#f1f1f1"
            };
            var model2 = new VeresiyeModel()
            {
                Name = "Bakkal Erdal",
                TotalAmount = "102",
                Date = "09.10.2016",
                BgColor = "#ffffff"
            };
            var model3 = new VeresiyeModel()
            {
                Name = "Bakkal Osman",
                TotalAmount = "150",
                Date = "14.10.2016",
                BgColor = "#f1f1f1"
            };
            rightList.Add(model1);
            rightList.Add(model2);
            rightList.Add(model3);

            list2.ItemsSource = rightList;
        }
    }
}