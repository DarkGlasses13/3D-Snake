using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Core.Asset_Loading
{
    public abstract class SingleAssetLoader<T> : ISingleAssetLoader<T>
    {
        protected object _asset;

        public abstract object Key { get; }

        public abstract T Load();
        public abstract T LoadAndInstantiate(Transform parent, bool isActive = true);
        public abstract Task<T> LoadAsync();
        public abstract Task<T> LoadAndInstantiateAsync(Transform parent, bool isActive = true);

        public void Unload()
        {
            if (_asset != null)
            {
                if (_asset is GameObject gameObjectAsset)
                {
                    gameObjectAsset.SetActive(false);
                }

                ReleaseAsset();
                _asset = null;
            }
        }

        protected abstract void ReleaseAsset();
    }
}