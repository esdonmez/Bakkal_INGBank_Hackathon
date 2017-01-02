using Bakkal.Views.ContentDialogs;
using BakkalAPI.Models;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Calls;
using Windows.Foundation.Metadata;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Bakkal.Views
{
    public sealed partial class MarketDetailsView : Page
    {
        public static List<ProductModel> products = new List<ProductModel>();
        public static BakkalModel bakkal;
        private string selectedCategory;


        public MarketDetailsView()
        {
            this.InitializeComponent();
            this.Loaded += MarketDetailsView_Loaded;
        }


        private async void GetProductsRequest()
        {
            products = await App.Client.Products(bakkal.Id);

            var list = new List<ProductModel>();

            for(int i = 0; i < products.Count; i++)
            {
                if(selectedCategory == products[i].CategoryName)
                {
                    list.Add(products[i]);
                }
            }

            listView.ItemsSource = list;
        }

        private void MarketDetailsView_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = bakkal;
        }

        private async void reportButton_Click(object sender, RoutedEventArgs e)
        {
            ReportDialog report = new ReportDialog(bakkal.Id);
            ContentDialogResult content = await report.ShowAsync();
        }

        private void callButton_Click(object sender, RoutedEventArgs e)
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.Calls.CallsPhoneContract", 1, 0))
            {
                PhoneCallManager.ShowPhoneCallUI(bakkal.Phone, bakkal.Name);
            }
        }

        private void categoryButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var selected = (sender as Grid).Name;

            if (selected == "grid11") selectedCategory = "İçecekler";
            else if (selected == "grid12") selectedCategory = "Atıştırmalık";
            else if (selected == "grid13") selectedCategory = "Meyve / Sebze";
            else if (selected == "grid21") selectedCategory = "Süt Ürünleri";
            else if (selected == "grid22") selectedCategory = "Kahvaltılık";
            else if (selected == "grid23") selectedCategory = "Temel Gıda";
            else if (selected == "grid31") selectedCategory = "Dondurma";
            else if (selected == "grid32") selectedCategory = "Temizlik";
            else if (selected == "grid33") selectedCategory = "Diğer";

            header.Text = selectedCategory;
            category.ShowAt(this as FrameworkElement);
            GetProductsRequest();
        }

        private void close_Tapped(object sender, TappedRoutedEventArgs e)
        {
            category.Hide();
        }

        private async void shop_Tapped(object sender, TappedRoutedEventArgs e)
        {
            category.Hide();
            await new MessageDialog("Ürünleriniz sepete eklendi.", "Bildirim").ShowAsync();
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}