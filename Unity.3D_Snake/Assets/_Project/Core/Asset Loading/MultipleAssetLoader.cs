using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Core.Asset_Loading
{
    public abstract class MultipleAssetLoader<T> : IMultipleAssetLoader<T>
    {
        protected IList<object> _assets;

        public object Key { get; }

        public abstract IList<T> Load();
        public abstract IList<T> LoadAndInstantiate(Transform parent, bool isActive = true);
        public abstract Task<IList<T>> LoadAsync();
        public abstract Task<IList<T>> LoadAndInstantiateAsync(Transform parent, bool isActive = true);

        public void Unload()
        {
            if (_assets != null)
            {
                foreach (object asset in _assets)
                {
                    if (asset is GameObject gameObjectAsset)
                    {
                        gameObjectAsset.SetActive(false);
                    }

                    ReleaseAsset(asset);
                }

                _assets = null;
            }
        }

        protected abstract void ReleaseAsset(object asset);
    }
}