using UnityEngine;

namespace Assets._Project
{
    public struct MeshFilterGetter
    {
        private MeshFilter _meshFilter;

        public MeshFilter Get(MonoBehaviour from)
        {
            if (_meshFilter == null)
            {
                if (from.TryGetComponent(out _meshFilter) == false)
                {
                    _meshFilter = from.GetComponentInChildren<MeshFilter>();
                }
            }

            return _meshFilter;
        }
    }
}