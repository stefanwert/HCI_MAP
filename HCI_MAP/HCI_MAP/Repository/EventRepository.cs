using HCI_MAP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace HCI_MAP.Repository
{
    public class EventRepository
    {
        private static string fileName = "Event.txt";
        public List<Event> GetAllEvent()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Stream streamData = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            List<Event> events = new List<Event>();
            try
            {
                events = (List<Event>)binaryFormatter.Deserialize(streamData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            streamData.Close();
            /*List<Event> events = new List<Event>();
            events.Add(new Event(1, "name", "opis", "opis", null, Attendance.Enum_1000_To_5000, false, 123300, null, null, null, null, null));*/
            return events;
        }

        public Event EditEvent(Event _event)
        {
            List<Event> events = GetAllEvent();
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Id.Equals(_event.Id))
                {
                    events[i] = _event;
                    break;
                }
            }
            WriteAllEventToFile(events);
            return _event;
        }
        public Event AddEvent(Event _event)
        {
            //is human des unique
            foreach(Event e in GetAllEvent())
            {
                if (e.Human_description.Equals(_event.Human_description))
                {
                    return null;
                }
            }
            List<Event> eventList = GetAllEvent();
            if (eventList.Count != 0)
                _event.Id = eventList[eventList.Count - 1].Id + 1;
            else
                _event.Id = 1;
            eventList.Add(_event);
            WriteAllEventToFile(eventList);
            return _event;
        }

        public bool RemoveEvent(Event _event)
        {
            List<Event> events = GetAllEvent();
            foreach(Event _event2 in events)
            {
                if (_event.Id.Equals(_event2.Id))
                {
                    events.Remove(_event2);
                    WriteAllEventToFile(events);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveById(int id)
        {
            List<Event> events = GetAllEvent();
            foreach (Event _event2 in events)
            {
                if (id.Equals(_event2.Id))
                {
                    events.Remove(_event2);
                    WriteAllEventToFile(events);
                    return true;
                }
            }
            return false;
        }
        public void WriteAllEventToFile(List<Event> eventList)
        {
            Stream stream = File.Open(fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, eventList);
            stream.Close();
        }

    }
}
