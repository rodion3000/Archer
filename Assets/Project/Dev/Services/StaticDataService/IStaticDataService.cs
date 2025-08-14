using System.Collections.Generic;
using Project.Data.HeroLocalData;
using Project.Data.StageData;

namespace Project.Dev.Services.StaticDataService
{
    public interface IStaticDataService
    {
        StageLocalData ForStage(string stageKey);
        List<StageLocalData> GetAllStages { get; }
        public HeroLocalData ForHero();
    }
}
