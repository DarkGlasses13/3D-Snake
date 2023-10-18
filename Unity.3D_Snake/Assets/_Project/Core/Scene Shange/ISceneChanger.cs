using System.Threading.Tasks;

namespace Assets._Project.Core.Scene_Shange
{
    public interface ISceneChanger
    {
        Task ChangeAsync(string key);
    }
}
