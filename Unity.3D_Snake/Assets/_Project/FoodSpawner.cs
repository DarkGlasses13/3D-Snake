using Assets._Project.Core.Object_Pool;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = UnityEngine.Random;

namespace Assets._Project
{
    public class FoodSpawner : IDisposable
    {
        private readonly MonoPool<Food> _pool;
        private readonly Terrain _terrain;
        private readonly GameConfigLoader _configLoader;
        private GameConfig _config;
        private float _spawnRadius;

        public FoodSpawner(Terrain terrain, GameConfigLoader configLoader)
        {
            _pool = new(CreateFromPrefab);
            _terrain = terrain;
            _configLoader = configLoader;
        }

        public async Task SpawnInitialAsync()
        {
            _config = _configLoader.Load();
            _spawnRadius = _terrain.terrainData.bounds.size.x / 2;

            for (int i = 0; i < _config.StartFoodAmount; i++)
            {
                Spawn();
                await Task.Yield();
            }
        }

        private void Spawn()
        {
            if (_terrain)
            {
                Vector2 randomPointInsideTerrainCircle = Random.insideUnitCircle * _spawnRadius;
                Vector3 randomPosition = new Vector3
                (
                    randomPointInsideTerrainCircle.x,
                    _terrain.terrainData.bounds.center.y,
                    randomPointInsideTerrainCircle.y
                )
                + _terrain.GetPosition() + _terrain.terrainData.bounds.center;

                randomPosition.y = _terrain.SampleHeight(randomPosition);
                Spawn(randomPosition, Random.rotationUniform);
            }
        }

        private Food Spawn(Vector3 position, Quaternion rotation)
        {
            Food instance = _pool.Get();
            position.y += instance.MeshFilter.mesh.bounds.size.y / 2;
            instance.transform.SetPositionAndRotation(position, rotation);
            return instance;
        }

        protected Food CreateFromPrefab()
        {
            AsyncOperationHandle<GameObject> instantiate = Addressables.InstantiateAsync("Food");
            instantiate.WaitForCompletion();
            Food instance = instantiate.Result.AddComponent<Food>();
            instance.OnEaten += OnEaten;
            return instance;
        }

        private void OnEaten() => Spawn();

        public void Dispose()
        {
            foreach (Food instance in _pool.All)
            {
                instance.OnEaten -= OnEaten;
            }
        }
    }
}
