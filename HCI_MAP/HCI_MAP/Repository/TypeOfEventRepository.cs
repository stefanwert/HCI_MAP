using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using HCI_MAP.Model;

namespace HCI_MAP.Repository
{
    public class TypeOfEventRepository
    {
        private static string fileName = "TypeOfEvent.txt";
        public List<TypeOfEvent> GetAllTypeOfEvent()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Stream streamData = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            List<TypeOfEvent> typeOfEvent = new List<TypeOfEvent>();
            try
            {
                typeOfEvent = (List<TypeOfEvent>)binaryFormatter.Deserialize(streamData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            streamData.Close();
            return typeOfEvent;
        }

        public TypeOfEvent EditTypeOfEvent(TypeOfEvent typeOfEvent)
        {
            List<TypeOfEvent> typeOfEvents = GetAllTypeOfEvent();
            for (int i = 0; i < typeOfEvents.Count; i++)
            {
                if (typeOfEvents[i].Id.Equals(typeOfEvent.Id))
                {
                    typeOfEvents[i] = typeOfEvent;
                    break;
                }
            }
            WriteAllTypeOFEventToFile(typeOfEvents);
            return typeOfEvent;
        }

        public TypeOfEvent AddTypeOfEvent(TypeOfEvent typeOfEvent)
        {
            //is human des unique
            foreach (TypeOfEvent e in GetAllTypeOfEvent())
            {
                if (e.Human_description.Equals(typeOfEvent.Human_description))
                {
                    return null;
                }
            }
            List<TypeOfEvent> typeOfEventList = GetAllTypeOfEvent();
            int i = Guid.NewGuid().GetHashCode();
            typeOfEvent.Id = i;
            /*if (typeOfEventList.Count != 0)
                typeOfEvent.Id = typeOfEventList[typeOfEventList.Count - 1].Id + 1;
            else
                typeOfEvent.Id = 1;*/
            typeOfEventList.Add(typeOfEvent);
            WriteAllTypeOFEventToFile(typeOfEventList);
            return typeOfEvent;
        }

        public bool RemoveTypeOfEvent(TypeOfEvent typeOfEvent)
        {
            List<TypeOfEvent> typeOfEvents = GetAllTypeOfEvent();
            foreach (TypeOfEvent te2 in typeOfEvents)
            {
                if (typeOfEvent.Id.Equals(te2.Id))
                {
                    typeOfEvents.Remove(te2);
                    WriteAllTypeOFEventToFile(typeOfEvents);
                    return true;
                }
            }
            return false;
        }

        public void WriteAllTypeOFEventToFile(List<TypeOfEvent> typeOfEvent)
        {
            Stream stream = File.Open(fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, typeOfEvent);
            stream.Close();
        }

        public TypeOfEvent getById(int id)
        {
            foreach (TypeOfEvent typeOfEvent in GetAllTypeOfEvent())
            {
                if(typeOfEvent.Id == id)
                {
                    return typeOfEvent;
                }
            }
            return null;
        }
    }
}
