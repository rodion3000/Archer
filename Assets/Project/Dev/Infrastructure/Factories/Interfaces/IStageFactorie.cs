using UnityEngine;
using System.Threading.Tasks;

namespace Project.Dev.Infrastructure.Factories.Interfaces
{
    public interface IStageFactorie
    {
        Task WarmUp(string locationName);
        void CleanUp(string locationName);
        Task<GameObject> CreateLocation(string locationName);

    }
}
