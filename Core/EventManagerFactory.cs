namespace Core
{
    public static class EventManagerFactory
    {
        private static readonly bool UseStorage = true; // option from config file
        
        public static IEventManager CreateManager()
        {
            if (UseStorage)
            {
                var stg = new FileEventManager("events.txt");
                var primary = new InMemoryManager();
                return new CombinedManager(primary, stg);
            }
            else
            {
                return new InMemoryManager();
            }
        }
    }
}