using System;
using System.Collections.Generic;
using System.Text;

namespace HCI_MAP.Model
{
    [Serializable]
    public enum Attendance
    {
        Enum_To_1000 = 0,
        Enum_1000_To_5000 = 1,
        Enum_5000_To_10000 = 2,
        Enum_Over_10000 = 3
    }

    [Serializable]
    public class Event
    {
        private int id;
        private string name;
        private string description;
        private string human_description;
        private int typeOfEventId=-1;
        private Attendance attendance;
        //ikonica opciono ali ako se ne postavi uzima se difoltna
        private bool humanitarian;
        private double price;// u dolarima
        private string country;
        private string city;
        private string place;
        private List<DateTime> dateTimes = new List<DateTime>();
        private List<StickyNote> stickyNotes = new List<StickyNote>();
        private DateTime date;
        private double x=0;
        private double y=0;

        public Event()
        {

        }
        public Event(int id, string name, string description, string human_description,
            int typeOfEventId, Attendance attendance, bool humanitarian, double price,
            string country, string city, string place, List<DateTime> dateTimes, List<StickyNote> stickyNotes,DateTime date)
        {
            Id = id;
            Name = name;
            Description = description;
            Human_description = human_description;
            TypeOfEventId = typeOfEventId;
            Attendance = attendance;
            Humanitarian = humanitarian;
            Price = price;
            Country = country;
            City = city;
            Place = place;
            DateTimes = dateTimes;
            StickyNotes = stickyNotes;
            Date = date;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Human_description { get => human_description; set => human_description = value; }
        public int TypeOfEventId { get => typeOfEventId; set => typeOfEventId = value; }
        public Attendance Attendance { get => attendance; set => attendance = value; }
        public bool Humanitarian { get => humanitarian; set => humanitarian = value; }
        public double Price { get => price; set => price = value; }
        public string Country { get => country; set => country = value; }
        public string City { get => city; set => city = value; }
        public string Place { get => place; set => place = value; }
        public List<DateTime> DateTimes { get => dateTimes; set => dateTimes = value; }
        public List<StickyNote> StickyNotes { get => stickyNotes; set => stickyNotes = value; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
