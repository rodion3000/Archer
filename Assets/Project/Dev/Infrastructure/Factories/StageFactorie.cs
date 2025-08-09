using System.Threading.Tasks;
using Project.Dev.Infrastructure.AssetManager;
using Project.Dev.Infrastructure.Factories.Interfaces;
using UnityEngine;

namespace Project.Dev.Infrastructure.Factories
{
    public class StageFactorie : IStageFactorie
    {
        private readonly IAssetProvider _assetProvider;

        public StageFactorie(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        public async Task WarmUp(string locationName)
        {
            await _assetProvider.Load<GameObject>(key: locationName);
        }

        public void CleanUp(string locationName)
        {
            _assetProvider.Release(key: locationName);
        }

        public async Task<GameObject> CreateLocation(string locationName)
        {
            var prefab = await _assetProvider.Load<GameObject>(key: locationName);
            return Object.Instantiate(prefab);
        }
    }
}
