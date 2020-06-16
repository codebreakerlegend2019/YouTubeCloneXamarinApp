using System;
using System.Collections.Generic;
using System.Text;
using YouTubeClone.Interfaces;
using YouTubeClone.Models;

namespace YouTubeClone.Services.VideoS
{
    public class VideoService : IGetAll<Video>
    {

        public List<Video> GetAll()
        {
            return new List<Video>()
            {
                new Video()
                {
                    Id =1,
                    ThumbNail = "YT_Vlog_1_Thumbnail.jpg",
                    Duration = "3:10",
                    ChannelProfileImage = "Channel_Profile_Pic.jpg",
                    Title = "Tiktok Songs Played on Guitar (FIRST VLOG)",
                    ChannelName = "JDS-TV",
                    Views = 52,
                    PublishedDate = DateTime.Parse("April 29, 2020 12:00AM")
                },
                new Video()
                {
                    Id =2,
                    ThumbNail = "YT_Vlog_2_Thumbnail.jpg",
                    Duration = "7:51",
                    ChannelProfileImage = "Channel_Profile_Pic.jpg",
                    Title = "A Day in a life of Software Developer (Philippines) - SECOND VLOG",
                    ChannelName = "JDS-TV",
                    Views = 755,
                    PublishedDate = DateTime.Parse("May 2, 2020 1:53PM")
                },
                new Video()
                {
                    Id =2,
                    ThumbNail = "YT_Vlog_2_Thumbnail.jpg",
                    Duration = "7:51",
                    ChannelProfileImage = "Channel_Profile_Pic.jpg",
                    Title = "A Day in a life of Software Developer (Philippines) - SECOND VLOG",
                    ChannelName = "JDS-TV",
                    Views = 755,
                    PublishedDate = DateTime.Parse("May 2, 2020 1:53PM")
                },
                new Video()
                {
                    Id =2,
                    ThumbNail = "YT_Vlog_2_Thumbnail.jpg",
                    Duration = "7:51",
                    ChannelProfileImage = "Channel_Profile_Pic.jpg",
                    Title = "A Day in a life of Software Developer (Philippines) - SECOND VLOG",
                    ChannelName = "JDS-TV",
                    Views = 755,
                    PublishedDate = DateTime.Parse("May 2, 2020 1:53PM")
                },
                new Video()
                {
                    Id =2,
                    ThumbNail = "YT_Vlog_2_Thumbnail.jpg",
                    Duration = "7:51",
                    ChannelProfileImage = "Channel_Profile_Pic.jpg",
                    Title = "A Day in a life of Software Developer (Philippines) - SECOND VLOG",
                    ChannelName = "JDS-TV",
                    Views = 755,
                    PublishedDate = DateTime.Parse("May 2, 2020 1:53PM")
                },
            };
        }
    }
}
