using System;
using System.Collections.Generic;
using System.Text;
using HCI_MAP.Repository;
using HCI_MAP.Model;

namespace HCI_MAP.Service
{
    public class EventService
    {
        private EventRepository eventRepository = new EventRepository();

        public List<Event> GetAllEvents()
        {
            return eventRepository.GetAllEvent();
        }

        public Event AddEvent(Event _event)
        {
            return eventRepository.AddEvent(_event);
        }

        public bool RemoveEvent(Event _event)
        {
            return eventRepository.RemoveEvent(_event);
        }

        public Event EditEvent(Event _event)
        {
            return eventRepository.EditEvent(_event);
        }
        public bool RemoveById(int id)
        {
            return eventRepository.RemoveById(id);
        }
    }
}
