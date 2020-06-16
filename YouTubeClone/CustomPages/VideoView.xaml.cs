using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YouTubeClone.CustomPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class VideoView : ContentView
    {
        public static readonly BindableProperty ThumbNailImageProperty =
         BindableProperty.Create(nameof(ThumbNailImage), typeof(string), typeof(VideoView), null);

        public string ThumbNailImage
        {
            get { return (string)GetValue(ThumbNailImageProperty); }
            set { SetValue(ThumbNailImageProperty, value); }
        }

        public static readonly BindableProperty VideoDurationProperty =
         BindableProperty.Create(nameof(VideoDuration), typeof(string), typeof(VideoView), null);

        public string VideoDuration
        {
            get { return (string)GetValue(VideoDurationProperty); }
            set { SetValue(VideoDurationProperty, value); }
        }

        public static readonly BindableProperty ChannelProfilePictureProperty =
         BindableProperty.Create(nameof(ChannelProfilePicture), typeof(string), typeof(VideoView), null);

        public string ChannelProfilePicture
        {
            get { return (string)GetValue(ChannelProfilePictureProperty); }
            set { SetValue(ChannelProfilePictureProperty, value); }
        }

        public static readonly BindableProperty VideoTitleProperty =
         BindableProperty.Create(nameof(VideoTitle), typeof(string), typeof(VideoView), null);

        public string VideoTitle
        {
            get { return (string)GetValue(VideoTitleProperty); }
            set { SetValue(VideoTitleProperty, value); }
        }

        public static readonly BindableProperty ChannelNameProperty =
         BindableProperty.Create(nameof(ChannelName), typeof(string), typeof(VideoView), null);

        public string ChannelName
        {
            get { return (string)GetValue(ChannelNameProperty); }
            set { SetValue(ChannelNameProperty, value); }
        }

        public static readonly BindableProperty ViewCountProperty =
         BindableProperty.Create(nameof(ViewCount), typeof(string), typeof(VideoView), null);

        public string ViewCount
        {
            get { return (string)GetValue(ViewCountProperty); }
            set { SetValue(ViewCountProperty, value); }
        }


        public static readonly BindableProperty MomentPublishedDateProperty =
         BindableProperty.Create(nameof(MomentPublishedDate), typeof(string), typeof(VideoView), null);

        public string MomentPublishedDate
        {
            get { return (string)GetValue(MomentPublishedDateProperty); }
            set { SetValue(MomentPublishedDateProperty, value); }
        }

        public VideoView()
        {
            InitializeComponent();
            ThumbnailArea.SetBinding(Image.SourceProperty, new Binding(nameof(ThumbNailImage), source: this));
            VideoDurationArea.SetBinding(Label.TextProperty, new Binding(nameof(VideoDuration), source: this));
            ChannelProfilePictureArea.SetBinding(CachedImage.SourceProperty, new Binding(nameof(ChannelProfilePicture), source: this));
            VideoTitleArea.SetBinding(Label.TextProperty, new Binding(nameof(VideoTitle), source: this));
            ChannelNameArea.SetBinding(Span.TextProperty, new Binding(nameof(ChannelName), source: this));
            ViewCountArea.SetBinding(Span.TextProperty, new Binding(nameof(ViewCount), source: this));
            MomentPublishedDateArea.SetBinding(Span.TextProperty, new Binding(nameof(MomentPublishedDate), source: this));
        }
    }
}