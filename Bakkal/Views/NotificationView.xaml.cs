using BakkalAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Bakkal.Views
{
    public sealed partial class NotificationView : Page
    {

        private List<NotificationModel> notificationList = new List<NotificationModel>();


        public NotificationView()
        {
            this.InitializeComponent();
            this.GetNotificationsRequest();
        }


        private async void GetNotificationsRequest()
        {
            notificationList = await App.Client.Notifications();

            if (notificationList.Count != 0)
            {
                for (int i = 0; i < notificationList.Count; i++)
                {
                    if (i % 2 == 0) notificationList[i].BgColor = "#FBFBFB";
                    if (i % 2 == 1) notificationList[i].BgColor = "#FFFFFF";
                    if (notificationList[i].IsConfirm == true) notificationList[i].Icon = "ms-appx:///Assets/Icons/yes.png";
                    if (notificationList[i].IsConfirm == false) notificationList[i].Icon = "ms-appx:///Assets/Icons/no.png";
                }

                listView.ItemsSource = notificationList;
            }
        }
    }
}