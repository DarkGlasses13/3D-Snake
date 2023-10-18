using Assets._Project.Core.Scene_Shange;
using System;
using UnityEngine;
using Zenject;

namespace Assets._Project.Core
{
    public class Bootstrap : IInitializable, IDisposable
    {
        private readonly ISceneChanger _sceneChanger;

        public Bootstrap(ISceneChanger sceneChanger)
        {
            _sceneChanger = sceneChanger;
        }

        public void Initialize()
        {
            // Show loading screen
            Application.targetFrameRate = 60;
            _sceneChanger.ChangeAsync("Game");
        }

        public void Dispose()
        {
        }
    }
}
