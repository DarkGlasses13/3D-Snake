using Assets._Project.Food.Spawn;
using System;
using Zenject;

namespace Assets._Project.Core
{
    public class GameRunner : IInitializable, IDisposable
    {
        private readonly GameConfigLoader _configLoader;
        private readonly FoodSpawner _foodSpawner;

        public GameRunner(GameConfigLoader configLoader, FoodSpawner foodSpawner)
        {
            _configLoader = configLoader;
            _foodSpawner = foodSpawner;
        }

        public void Initialize() => RunAsync();

        private async void RunAsync()
        {
            await _configLoader.LoadAsync();
            await _foodSpawner.SpawnInitialAsync();
            //Hide loading screen
        }

        public void Dispose()
        {
        }
    }
}
