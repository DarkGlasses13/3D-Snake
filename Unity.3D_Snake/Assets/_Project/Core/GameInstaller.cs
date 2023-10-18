using UnityEngine;
using Zenject;

namespace Assets._Project.Core
{
    [CreateAssetMenu(fileName = "Game Installer", menuName = "Installers/Game Installer")]
    public class GameInstaller : ScriptableObjectInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {

        }
    }
}