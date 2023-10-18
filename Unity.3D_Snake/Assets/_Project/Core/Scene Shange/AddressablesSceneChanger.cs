using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Assets._Project.Core.Scene_Shange
{
    public class AddressablesSceneChanger : ISceneChanger
    {
        public async Task ChangeAsync(string key)
        {
            await Addressables.LoadSceneAsync("Empty").Task;
            await Addressables.LoadSceneAsync(key).Task;
        }
    }
}
