using System;
using System.Globalization;
using Core;
using Model;

namespace Cli
{
    class Program
    {
        // Strategy pattern
        // Decorator pattern
        // Factory pattern
        private static IEventManager _manager;
        
        static void Main(string[] args)
        {
            _manager = EventManagerFactory.CreateManager();
            
            /*
             * var manager = 100... EventManagerFactory.CreateManager();
             */
            
            while (true)
            {
                Console.WriteLine("Choose an action:\n1) Add event\n2) Get all events\n3) Get specific events");
                
                int code = int.Parse(Console.ReadLine());

                switch (code)
                {
                    case 1:
                        AddEvent();
                        break;
                    
                    case 2:
                        GetAll();
                        break;
                    
                    case 3:
                        break;
                    
                    default:
                        return;
                }
            }
        }

        private static void AddEvent()
        {
            string title = GetInput("Enter title:");
            string descr = GetInput("Enter description:");
            DateTime date = DateTime.ParseExact(GetInput("Enter date:"), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            var id = Guid.NewGuid();
            
            _manager.AddEvent(new Event(id, title, descr, date));
        }

        private static void GetAll()
        {
            Console.Clear();

            foreach (Event evt in _manager.GetAllEvents())
            {
                Console.WriteLine(evt);
            }

            Console.ReadLine();
        }

        private static string GetInput(string message)
        {
            Console.Clear();
            Console.Write(message);

            return Console.ReadLine();
        }
    }
}