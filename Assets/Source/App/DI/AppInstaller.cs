using Reflex.Core;
using Source.App.Config;
using Source.App.ImageLoader;
using Source.App.Initialization;
using Source.Gameplay;
using UnityEngine;

namespace Source.App.DI
{
    public class AppInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private GameplayConfig _gameplayConfig;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            // install gameplay
            containerBuilder.AddSingleton(new MovableModel(_gameplayConfig.CubeMoveSpeed, _gameplayConfig.CubeMaxMoveSpeed), typeof(MovableModel));
            containerBuilder.AddSingleton(typeof(InputSystemForMovable), typeof(IInitializable));

            containerBuilder.AddSingleton(typeof(ImageLoadService), typeof(ImageLoadService));
            
            containerBuilder.OnContainerBuilt += container => container.All<IInitializable>().Initialize();
        }
    }
}
