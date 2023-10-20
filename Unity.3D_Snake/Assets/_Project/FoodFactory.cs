using UnityEngine;
using Zenject;

namespace Assets._Project
{
    public class FoodFactory
    {
        private readonly DiContainer _container;

        public FoodFactory(DiContainer container)
        {
            _container = container;

        }

        public Food Create(GameObject prefab)
        {
            return _container.InstantiatePrefabForComponent<Food>(prefab);
        }
    }
}
