using System;
using UnityEngine;

namespace Assets._Project
{
    public class Food : MonoBehaviour, IHaveMesh
    {
        public event Action OnEaten;

        private readonly MeshFilterGetter _meshFilterGetter = new();

        public MeshFilter MeshFilter => _meshFilterGetter.Get(this);

        public void Eat()
        {
            gameObject.SetActive(false);
            OnEaten?.Invoke();
        }
    }
}