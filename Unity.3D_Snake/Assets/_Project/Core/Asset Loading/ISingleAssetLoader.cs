using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Core.Asset_Loading
{
    public interface ISingleAssetLoader<T>
    {
        object Key { get; }
        T Load();
        T LoadAndInstantiate(Transform parent, bool isActive = true);
        Task<T> LoadAsync();
        Task<T> LoadAndInstantiateAsync(Transform parent, bool isActive = true);
        void Unload();
    }
}