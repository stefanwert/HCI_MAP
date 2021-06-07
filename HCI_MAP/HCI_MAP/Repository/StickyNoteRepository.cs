using HCI_MAP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace HCI_MAP.Repository
{
    public class StickyNoteRepository
    {
        private static string fileName = "StickyNote.txt";


        public List<StickyNote> GetAllStickyNote()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Stream streamData = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            List<StickyNote> stickyNotes = new List<StickyNote>();
            try
            {
                stickyNotes = (List<StickyNote>)binaryFormatter.Deserialize(streamData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            streamData.Close();
            return stickyNotes;
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
