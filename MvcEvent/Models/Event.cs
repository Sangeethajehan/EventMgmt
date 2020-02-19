using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEvent.Models
{
    public class Event
    {
        public int eventId { get; set; }
        public int userId { get; set; }
        public string eventName { get; set; }
        public string startDate { get; set; }
        public string startTime { get; set; }
        public string endDate { get; set; }
        public string endTime { get; set; }
        public string description { get; set; }
        public string eventType { get; set; }
        public string venueEventType { get; set; }
        public string address { get; set; }
        public string venue { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string pincode { get; set; }
        public string eventLogo { get; set; }
        public string coverPicture { get; set; }
        public string finalEventType { get; set; }
        public string draft { get; set; }
        public string status { get; set; }
        public int createdBy { get; set; }
    }
}