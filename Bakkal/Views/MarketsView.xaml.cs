using BakkalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;

namespace Bakkal.Views
{
    public sealed partial class MarketsView : Page
    {
        private static List<BakkalModel> bakkalList = new List<BakkalModel>();
        private static Geopoint myLocation;
        private static string city;


        public MarketsView()
        {
            this.InitializeComponent();
            this.GetLocation();
        }


        private async void GetLocation()
        {
            progress.IsIndeterminate = true;

            var gl = new Geolocator() { DesiredAccuracy = PositionAccuracy.High };
            var location = await gl.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(5));
            myLocation = location.Coordinate.Point;


            var pin = new MapIcon()
            {
                Location = location.Coordinate.Point,
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/MapPins/me.png")),
                Title = "Buradasın",
                NormalizedAnchorPoint = new Windows.Foundation.Point() { X = 0.32, Y = 0.78 }
            };

            map.MapElements.Add(pin);

            await map.TrySetViewAsync(location.Coordinate.Point, 12, 0, 0, MapAnimationKind.Bow);

            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(myLocation);
            city = result.Locations[0].Address.Region;
            GetAllBakkalsRequest();

            progress.IsIndeterminate = false;
        }

        private async void GetBakkalsRequest()
        {
            string latitude = myLocation.Position.Latitude.ToString().Replace(",", ".");
            string longitude = myLocation.Position.Longitude.ToString().Replace(",", ".");

            bakkalList = await App.Client.Bakkals(city, latitude, longitude);

            if (bakkalList != null)
            {
                for (int i = 0; i < bakkalList.Count; i++)
                {
                    PinToMap(bakkalList[i].Latitude, bakkalList[i].Longitude, bakkalList[i].Name);
                }
            }
        }

        private async void GetAllBakkalsRequest()
        {
            bakkalList = await App.Client.GetAllBakkals();

            if (bakkalList.Count != 0)
            {
                for (int i = 0; i < bakkalList.Count; i++)
                {
                    PinToMap(bakkalList[i].Latitude, bakkalList[i].Longitude, bakkalList[i].Name);
                }
            }
        }

        private void PinToMap(string latitude, string longitude, string name)
        {
            BasicGeoposition position = new BasicGeoposition()
            {
                Latitude = double.Parse(String.Format(latitude.Replace(".",","), "{0:0.#######}")),
                Longitude = double.Parse(String.Format(longitude.Replace(".", ","), "{0:0.#######}"))
            };

            MapIcon icon = new MapIcon()
            {
                Title = name,
                Location = new Geopoint(position),
                NormalizedAnchorPoint = new Windows.Foundation.Point() { X = 0.32, Y = 0.78 },
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/MapPins/bakkal.png", UriKind.RelativeOrAbsolute))
            };

            map.MapElements.Add(icon);
        }

        private void map_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            MapIcon icon = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;

            for(int i = 0; i < bakkalList.Count; i++)
            {
                if(icon.Title == bakkalList[i].Name)
                {
                    MarketDetailsView.bakkal = bakkalList[i];
                    Frame.Navigate(typeof(MarketDetailsView));
                    break;
                }
            }
        }
    }
}