using System.Collections.Generic;

namespace Assets._Project.Core.Object_Pool
{
    public interface IPool<T>
    {
        T Get();
        IReadOnlyCollection<T> All { get; }
        void ReleaseAll();
    }
}
