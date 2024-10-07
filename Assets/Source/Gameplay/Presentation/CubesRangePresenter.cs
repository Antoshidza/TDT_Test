using System;
using System.Collections.Generic;
using System.Linq;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace Source.Gameplay.Presentation
{
    public class CubesRangePresenter : IDisposable
    {
        private readonly IDisposable _sub;

        public CubesRangePresenter(IEnumerable<Transform> cubes, CubeVFXView cubeRangeVfx, GameplayPresentationConfig config, UIDocument cubesRangeUiPanel)
        {
            var cubeViews = cubes as Transform[] ?? cubes.ToArray();

            if (cubeViews.Length != 2)
                throw new GameplayException($"{nameof(CubesRangePresenter)} expects exactly 2 cubes simulated!");
            
            var rangeLabel = cubesRangeUiPanel.rootVisualElement.Q<Label>();
            _sub = Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    var distance = Vector3.Distance(cubeViews[0].position, cubeViews[1].position);
                    rangeLabel.text = $"{distance / config.UnitsPerMeter:F2} m";
                    if (distance < config.CubeDistanceThreshold)
                        cubeRangeVfx.Play(cubeViews[0], cubeViews[1]);
                    else
                        cubeRangeVfx.Stop();
                });

        }

        public void Dispose() => _sub?.Dispose();
    }
}