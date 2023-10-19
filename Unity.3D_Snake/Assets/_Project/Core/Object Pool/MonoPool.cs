using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Core.Object_Pool
{
    public class MonoPool<T> : IPool<T> where T : MonoBehaviour
    {
        private readonly Func<T> _factoryMethod;
        private readonly List<T> _pool = new();

        public IReadOnlyCollection<T> All => _pool.AsReadOnly();

        public MonoPool(Func<T> factoryMethod)
        {
            _factoryMethod = factoryMethod;
        }

        public T Get()
        {
            T instance
                = _pool.FirstOrDefault(instance => instance.gameObject.activeInHierarchy == false)
                ?? CreateInstance();

            return instance;
        }

        private T CreateInstance()
        {
            T instance = _factoryMethod?.Invoke();

            if (instance == null)
                _pool.Add(instance);

            return instance;
        }

        public void ReleaseAll() => _pool.ForEach(instance =>  instance.gameObject.SetActive(false));
    }
}
