using System;
using System.Collections.Generic;
using System.Text;
using YouTubeClone.Helpers;

namespace YouTubeClone.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string ThumbNail { get; set; }
        public string Duration { get; set; }
        public string ChannelProfileImage { get; set; }
        public string Title { get; set; }
        public string ChannelName { get; set; }
        public double Views { get; set; }
        public string ViewInText => StringHelper.ToViews(Views);
        public DateTime PublishedDate { get; set; }
        public string MomentPublishedDate => StringHelper.GetIntervalFromTheCurrentDateTime(PublishedDate);
    }
}
