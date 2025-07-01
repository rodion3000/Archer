using Project.Data.MenuData;
using System.Threading.Tasks;

namespace Project.Dev.Services.SaveLoadLocalService
{
    public interface ISaveLoadLocalService
    {
        void SaveProgress();
        Task<PlayerProgressData> LoadProgress();

        void SaveEconomy();
        Task<PlayerEconomyData> LoadEconomy();

        void SaveSettings();
        Task<PlayerSettingsData> LoadSettings();
    }
}
