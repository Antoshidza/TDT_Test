using System.Linq;
using Cysharp.Threading.Tasks;
using Reflex.Core;
using Source.Gameplay.Presentation;
using UnityEngine;
using UnityEngine.UIElements;

namespace Source.Gameplay.DI
{
    public class GameplaySceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private GameplayPresentationConfig _gameplayPresentationConfig;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private CubeVFXView _cubeVFXView;
        [SerializeField] private UIDocument _imagesPanel;
        [SerializeField] private ImagesPanelView _imagesPanelView;
        [SerializeField] private UIDocument _cubesRangePanel;
        [SerializeField] private CubeView[] _cubeViews;
        [SerializeField] private GameObject[] _spheres;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            var viewLayerCt = this.GetCancellationTokenOnDestroy(); 
            
            containerBuilder.AddSingleton(new CubesPresenter(_cubeViews, _spheres, _imagesPanelView), typeof(CubesPresenter));
            containerBuilder.AddSingleton(new CubesRangePresenter(_cubeViews.Select(view => view.transform), _cubeVFXView,
                _gameplayPresentationConfig, _cubesRangePanel), typeof(CubesRangePresenter));
            containerBuilder.AddSingleton(new ImagesPanelPresenter(_imagesPanel, _gameplayPresentationConfig.ImagesCount, viewLayerCt),
                typeof(ImagesPanelPresenter));
            
            containerBuilder.OnContainerBuilt += container => container.Single<MovableModel>().Body = _rigidbody;
        }
    }
}