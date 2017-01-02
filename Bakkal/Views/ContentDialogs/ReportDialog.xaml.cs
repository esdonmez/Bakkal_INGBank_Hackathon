using BakkalAPI.Models;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Bakkal.Views.ContentDialogs
{
    public sealed partial class ReportDialog : ContentDialog
    {
        private ReportModel model = new ReportModel();


        public ReportDialog(string BakkalId)
        {
            this.InitializeComponent();
            this.InitializeUI();

            model.BakkalId = BakkalId;
        }


        private void InitializeUI()
        {
            tick_1.Visibility = Visibility.Collapsed;
            tick_2.Visibility = Visibility.Collapsed;
            tick_3.Visibility = Visibility.Collapsed;
            tick_4.Visibility = Visibility.Collapsed;
        }

        private void report_1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tick_1.Visibility = Visibility.Visible;
            tick_2.Visibility = Visibility.Collapsed;
            tick_3.Visibility = Visibility.Collapsed;
            tick_4.Visibility = Visibility.Collapsed;

            model.Content = "Bu kişi ebni rahatsız ediyor";
        }

        private void report_2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tick_1.Visibility = Visibility.Collapsed;
            tick_2.Visibility = Visibility.Visible;
            tick_3.Visibility = Visibility.Collapsed;
            tick_4.Visibility = Visibility.Collapsed;

            model.Content = "Tanıdığım birisini taklit ediyor";
        }

        private void report_3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tick_1.Visibility = Visibility.Collapsed;
            tick_2.Visibility = Visibility.Collapsed;
            tick_3.Visibility = Visibility.Visible;
            tick_4.Visibility = Visibility.Collapsed;

            model.Content = "Uygunsuz içerik paylaşıyor";
        }

        private void report_4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tick_1.Visibility = Visibility.Collapsed;
            tick_2.Visibility = Visibility.Collapsed;
            tick_3.Visibility = Visibility.Collapsed;
            tick_4.Visibility = Visibility.Visible;

            model.Content = "Bu sahte bir hesap";
        }

        private void close_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Hide();
        }

        private async void report_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (model.Content != null)
            {
                var result = await App.Client.Report(model);

                if(result.IsSuccess == true)
                {
                    Hide();
                    await new MessageDialog("Şikayetiniz tarafımıza iletilmiştir. İlginiz için teşekkürler.", "Bildirim").ShowAsync();
                }
            }
        }
    }
}