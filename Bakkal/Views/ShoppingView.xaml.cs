using BakkalAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class ShoppingView : Page
    {
        private List<ProductModel> bucket = new List<ProductModel>();


        public ShoppingView()
        {
            this.InitializeComponent();
            this.DummyData();
        }


        private void DummyData()
        {
            var model1 = new ProductModel()
            {
                Name = "Bizim Bakkal",
                Price = "8,5",
                Products = "süt, ekmek, yumurta",
                BgColor = "#f1f1f1"
            };
            bucket.Add(model1);

            listView.ItemsSource = bucket;
        }

        private void delete_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private async void confirm_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await new MessageDialog("Siparişiniz gönderilmiştir.", "Bildirim").ShowAsync();
        }
    }
}