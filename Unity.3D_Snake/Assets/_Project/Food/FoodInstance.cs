using System;
using UnityEngine;

namespace Assets._Project.Food
{
    public class FoodInstance : MonoBehaviour
    {
        public event Action OnEaten;

        private MeshFilter _meshFilter;

        public MeshFilter MeshFilter => _meshFilter;

        private void Awake()
        {
            if (TryGetComponent(out _meshFilter) == false)
            {
                _meshFilter = GetComponentInChildren<MeshFilter>();
            }
        }

        public void Eat()
        {
            gameObject.SetActive(false);
            OnEaten?.Invoke();
        }
    }
}