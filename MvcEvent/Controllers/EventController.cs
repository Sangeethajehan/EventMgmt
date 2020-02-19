using MvcEvent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEvent.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /Event/
        EventDAL EventDAL = new EventDAL();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CreateEvent(Event AddEvent)
        {
            var result = new { Success = "false" };
            string strsuccess = EventDAL.CreateEvent(0, AddEvent.userId, AddEvent.eventName, AddEvent.startDate, AddEvent.startTime, AddEvent.endDate, AddEvent.endTime, AddEvent.description,
               AddEvent.eventType, AddEvent.venueEventType, AddEvent.address, AddEvent.venue, AddEvent.city, AddEvent.state, AddEvent.country, AddEvent.pincode,
               AddEvent.eventLogo, AddEvent.coverPicture, AddEvent.finalEventType, AddEvent.draft, AddEvent.status, 1);
            if (strsuccess != string.Empty)
            {
                result = new { Success = "true" };
            }
            return Json(result);
        }

        public JsonResult listEvents(Event ViewEvent)
        {
            var result = new { Success = "false" };
            List<Event> lst = new List<Event>();
            DataTable dt = EventDAL.GetAllEvents();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lst.Add(new Event
                    {
                        eventId = Convert.ToInt32(dt.Rows[i]["eventId"]),
                        eventName = Convert.ToString(dt.Rows[i]["eventName"]),
                        description = Convert.ToString(dt.Rows[i]["description"]),
                        userId = Convert.ToInt32(dt.Rows[i]["userId"])
                    });
                }
                return Json(new { Success = "true", eventlist = lst }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }

}

