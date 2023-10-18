using Assets._Project.Core.Scene_Shange;
using UnityEngine;
using Zenject;

namespace Assets._Project.Core
{
    [CreateAssetMenu(fileName = "Project Installer", menuName = "Installers/Project Installer")]
    public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
    {
        public override void InstallBindings()
        {
            BindBootstrap();
            BindSceneChanger();
        }

        private void BindSceneChanger()
        {
            Container
                .Bind<ISceneChanger>()
                .To<AddressablesSceneChanger>()
                .FromNew()
                .AsSingle();
        }

        private void BindBootstrap()
        {
            Container
                .BindInterfacesTo<Bootstrap>()
                .AsSingle()
                .NonLazy();
        }
    }
}