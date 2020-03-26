using System;
using System.Collections.Generic;
using System.IO;
using Model;

namespace Core
{
    public class FileEventManager : IEventManager
    {
        private readonly string _filePath;

        public void AddEvent(Event evt)
        {
            using (var stream = new FileStream(_filePath, FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(stream))
            {
                /*
                 * 1st line - id
                 * 2nd line - title
                 * 3rd line - description
                 * 4th line - time
                 */
                
                writer.WriteLine(evt.Id.ToString("N"));
                writer.WriteLine(evt.Title);
                writer.WriteLine(evt.Description);
                writer.WriteLine(evt.EvtTime.ToFileTime().ToString());
            }
        }

        public Event[] GetAllEvents()
        {
            if (!File.Exists(_filePath))
                return new Event[0];
            
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(stream))
            {
                string data = reader.ReadToEnd();

                string[] lines = data.Split(Environment.NewLine);

                var result = new List<Event>();
                
                for (int i = 0; i < lines.Length; i+=4)
                {
                    string idStr = lines[i];
                    
                    if (string.IsNullOrEmpty(idStr))
                        break;

                    Guid id = Guid.Parse(idStr);
                    
                    string dateStr = lines[i + 3];
                    DateTime date = DateTime.FromFileTime(long.Parse(dateStr));
                    
                    result.Add(new Event(id, lines[i+1], lines[i+2], date));
                }

                return result.ToArray();
            }
        }

        public Event[] GetAllEvents(DateTime date)
        {
            throw new NotImplementedException();
        }

        public FileEventManager(string filePath)
        {
            _filePath = filePath;
        }
    }
}