using Project.Data.MenuData;

namespace Project.Dev.Services.PersistentDataService
{
    public interface IPersistentDataService
    {
        PlayerSettingsData Settings { get; set; }
        PlayerProgressData Progress { get; set; }
        PlayerEconomyData Economy { get; set; }
    }
}

