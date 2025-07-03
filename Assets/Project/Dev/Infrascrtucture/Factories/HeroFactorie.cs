using System.Threading.Tasks;
using Project.Dev.Infrastructure.Factories.Interfaces;
using UnityEngine;
using Project.Dev.Infrastructure.Factories.FunctionalExtensions;
using Project.Dev.GamePlay.NPC.Player;
using Project.Dev.Infrastructure.AssetManager;

namespace Project.Dev.Infrastructure.Factories
{
    public class HeroFactorie : IHeroFactory
    {
        public GameObject Hero { get; }
        public Task WarmUp()
        {
            throw new System.NotImplementedException();
        }

        public void CleanUp()
        {
            throw new System.NotImplementedException();
        }

        public Task<GameObject> Create(Vector3 at)
        {
            throw new System.NotImplementedException();
        }
    }

}
