using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets._Project.Core.Asset_Loading
{
    public abstract class LocalAddressableSingleAssetLoader<T> : SingleAssetLoader<T> where T : class
    {
        public override T Load()
        {
            if (_asset != null)
                return (T)_asset;

            AsyncOperationHandle<T> loading = Addressables.LoadAssetAsync<T>(Key);
            loading.WaitForCompletion();
            _asset = loading.Result;
            return loading.Result;
        }

        public override async Task<T> LoadAsync()
        {
            if (_asset != null)
                return (T)_asset;

            T asset = await Addressables.LoadAssetAsync<T>(Key).Task;
            _asset = asset;
            return asset;
        }

        public override T LoadAndInstantiate(Transform parent, bool isActive = true)
        {
            if (_asset != null)
                return (T)_asset;

            AsyncOperationHandle<GameObject> instantiate = Addressables.InstantiateAsync(Key, parent);
            instantiate.WaitForCompletion();
            instantiate.Result.SetActive(isActive);

            if (instantiate.Result.TryGetComponent(out T component) == false)
            {
                throw new NullReferenceException(
                    $"There is no such component on the {instantiate.Result.name}");
            }

            _asset = component;
            return component;
        }

        public override async Task<T> LoadAndInstantiateAsync(Transform parent, bool isActive = true)
        {
            if (_asset != null)
                return (T)_asset;

            GameObject instance = await Addressables.InstantiateAsync(Key, parent).Task;
            instance.SetActive(isActive);

            if (instance.TryGetComponent(out T component) == false)
            {
                throw new NullReferenceException(
                    $"There is no such component on the {instance.name}");
            }

            _asset = component;
            return component;
        }

        protected override void ReleaseAsset()
        {
            Addressables.Release(_asset);
        }
    }
}
