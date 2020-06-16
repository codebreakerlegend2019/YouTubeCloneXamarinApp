using System;
using System.Collections.Generic;
using System.Text;

namespace YouTubeClone.Helpers
{
    public class StringHelper
    {
        public static string ToViews(double views)
        {
            return $"{views} Views";
        }
        public static string GetIntervalFromTheCurrentDateTime(DateTime notificationDateTime)
        {
            var currentDateTime = DateTime.Now;
            var interval = (currentDateTime - notificationDateTime);

            if (interval.Days == 0 && interval.Hours > 0)
                return (interval.Hours > 1) ? $"{interval.Hours} hours Ago" : "an hour ago";

            if (interval.Days == 0 && interval.Hours == 0)
                return (interval.Minutes > 1) ? $"{interval.Minutes} minutes Ago" : "a minute ago";

            if (interval.Days == 0 && interval.Hours == 0 && interval.Minutes == 0)
                return (interval.Seconds > 1) ? $"{interval.Seconds} seconds Ago" : "a second ago";

            if (interval.Days <= 1) return "Invalid Date";

            if (interval.Days % 7 == 0)
            {
                var weeks = (interval.Days / 7);
                var result = (weeks > 1) ? $"{weeks} weeks Ago" : "a week ago";
                return result;
            }
            if (interval.Days <= DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month))
                return (interval.Days > 0) ? $"{interval.Days} days Ago" : "a day ago";
            {
                var months = (interval.Days / 30);
                var result = (months > 1) ? $"{months} weeks Ago" : "a week ago";
                return result;
            }
        }
    }
}
