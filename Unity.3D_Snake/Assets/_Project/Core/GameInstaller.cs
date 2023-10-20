using UnityEngine;
using Zenject;

namespace Assets._Project
{
    [CreateAssetMenu(fileName = "Game Installer", menuName = "Installers/Game Installer")]
    public class GameInstaller : ScriptableObjectInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            BindRunner();
            BindConfig();
            BindTerrain();
            BindFoodFactory();
            BindFoodSpawner();
        }

        private void BindFoodSpawner()
        {
            Container
                .BindInterfacesAndSelfTo<FoodSpawner>()
                .FromNew()
                .AsSingle();
        }

        private void BindFoodFactory()
        {
            Container
                .Bind<FoodFactory>()
                .FromNew()
                .AsSingle();
        }

        private void BindTerrain()
        {
            Container
                .Bind<Terrain>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindConfig()
        {
            Container
                .Bind<GameConfigLoader>()
                .FromNew()
                .AsSingle();
        }

        private void BindRunner()
        {
            Container
                .BindInterfacesTo<GameRunner>()
                .AsSingle()
                .NonLazy();
        }
    }
}