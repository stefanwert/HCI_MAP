using System;
using System.Collections.Generic;
using System.Text;
using HCI_MAP.Model;
using HCI_MAP.Service;

namespace HCI_MAP.Controller
{
    public class EventController
    {
        private EventService eventService = new EventService();
        public List<Event> GetAllEvents()
        {
            return eventService.GetAllEvents();
        }

        public Event addEvent(Event _event)
        {
            return eventService.AddEvent(_event);
        }
        public bool RemoveEvent(Event _event)
        {
            return eventService.RemoveEvent(_event);
        }

        public Event EditEvent(Event _event)
        {
            return eventService.EditEvent(_event);
        }

        public bool RemoveById(int id)
        {
            return eventService.RemoveById(id);
        }
    }
}
