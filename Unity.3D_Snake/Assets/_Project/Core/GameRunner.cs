using System;
using Zenject;

namespace Assets._Project.Core
{
    public class GameRunner : IInitializable, IDisposable
    {
        public void Initialize() => RunAsync();

        private void RunAsync()
        {

            //Hide loading screen
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
