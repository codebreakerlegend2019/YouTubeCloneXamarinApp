using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using YouTubeClone.Themes;

namespace YouTubeClone.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private void PackagesScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            var transY = Convert.ToInt32(SearchBarView.TranslationY);
            if (transY == 0 &&
                e.VerticalDelta > 15)
            {
                var trans = SearchBarView.Height + SearchBarView.Margin.Top;
                var safeInsets = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();

                // Start both animations concurrently
                Task.WhenAll(
                    SearchBarView.TranslateTo(0, -(trans + safeInsets.Top), 200, Easing.CubicIn),
                    SearchBarView.FadeTo(0.25, 200));
            }
            else if (transY != 0 &&
                     e.VerticalDelta < 0 &&
                     Math.Abs(e.VerticalDelta) > 10)
            {
                Task.WhenAll(
                    SearchBarView.TranslateTo(0, 0, 200, Easing.CubicOut),
                    SearchBarView.FadeTo(1, 200));
            }
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var mergedDictionaries = App.Current.Resources.MergedDictionaries;
            if (e.Value)
                mergedDictionaries.Add(new DarkTheme());
            else
                mergedDictionaries.Add(new LightTheme());
        }
    }
}
