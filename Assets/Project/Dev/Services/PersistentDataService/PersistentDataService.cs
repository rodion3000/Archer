using Project.Data.MenuData;

namespace Project.Dev.Services.PersistentDataService
{
    public class PersistentDataService : IPersistentDataService
    {
        public PlayerSettingsData Settings { get; set; }
        public PlayerProgressData Progress { get; set; }
        public PlayerEconomyData Economy { get; set; }
    }
}

