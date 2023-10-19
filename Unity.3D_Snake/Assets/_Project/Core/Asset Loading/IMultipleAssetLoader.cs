using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Core.Asset_Loading
{
    public interface IMultipleAssetLoader<T>
    {
        object Key { get; }
        IList<T> Load();
        Task<IList<T>> LoadAsync();
        IList<T> LoadAndInstantiate(Transform parent, bool isActive = true);
        Task<IList<T>> LoadAndInstantiateAsync(Transform parent, bool isActive = true);
        void Unload();
    }
}