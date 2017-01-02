using Bakkal.Client;
using Bakkal.Views;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Bakkal
{
    sealed partial class App : Application
    {
        private static DataClient _client = new DataClient();


        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }


        public static DataClient Client
        {
            get
            {
                return _client;
            }
        }

        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                }

                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    var token = ApplicationData.Current.LocalSettings.Values["Token"];

                    if(token == null)
                    {
                        rootFrame.Navigate(typeof(StartView), e.Arguments);
                    }

                    else
                    {
                        Client.SetToken(token.ToString());
                        ProfileView.user = await Client.GetMe();
                        rootFrame.Navigate(typeof(MainPage), e.Arguments);
                    }
                }

                Window.Current.Activate();
            }
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }
    }
}