using System.Threading.Tasks;
using Project.Dev.Infrastructure.AssetManager;
using Project.Dev.Infrastructure.Factories.Interfaces;
using Project.Dev.Meta.UI.HudController;
using Project.Dev.Meta.UI.MenuController;
using UnityEngine;
using Zenject;

namespace Project.Dev.Infrastructure.Factories
{
    public class UIFactorie : IUIFactorie
    {
        private const string menuPrefabId = "MenuPrefab";
        private const string hudPrefabId = "HudPrefab";
        private const string rootUiPrefabId = "RootUiPrefab";

        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;

        private Canvas _uiRoot;

        public UIFactorie(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public async Task WarmUp()
        {
            await _assetProvider.Load<GameObject>(key: menuPrefabId);
            await _assetProvider.Load<GameObject>(key: hudPrefabId);
            await _assetProvider.Load<GameObject>(key: rootUiPrefabId);
        }

        public void CleanUp()
        {
            _assetProvider.Release(key: menuPrefabId);
            _assetProvider.Release(key: hudPrefabId);
        }

        public async Task<MenuController> CreateMenu()
        {
            var prefab = await _assetProvider.Load<GameObject>(key: menuPrefabId);
            var menu = Object.Instantiate(prefab, _uiRoot.transform).GetComponent<MenuController>();
            _container.InjectGameObject(menu.gameObject);
            return menu;
        }

        public async Task<HudController> CreateHud()
        {
            var prefab = await _assetProvider.Load<GameObject>(key: hudPrefabId);
            var hud = Object.Instantiate(prefab, _uiRoot.transform).GetComponent<HudController>();
            _container.Inject(hud);
            return hud;
        }
    }
}
