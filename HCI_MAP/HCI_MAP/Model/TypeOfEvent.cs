using System;
using System.Collections.Generic;
using System.Text;

namespace HCI_MAP.Model
{
    [Serializable]
    public class TypeOfEvent
    {
        private string name;
        private string picturePath;
        private string human_description;
        private string description;
        private int id; 
        public TypeOfEvent() { }
        public TypeOfEvent(string name)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }
        public string PicturePath { get => picturePath; set => picturePath = value; }
        public string Human_description { get => human_description; set => human_description = value; }
        public string Description { get => description; set => description = value; }
        public int Id { get => id; set => id = value; }
    }
}

