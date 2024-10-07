using System;
using System.Collections.Generic;
using R3;
using UnityEngine;

namespace Source.Gameplay.Presentation
{
    public class CubesPresenter : IDisposable
    {
        private readonly IDisposable _subs;
        
        public CubesPresenter(IEnumerable<CubeView> cubesViews, IEnumerable<GameObject> spheres, ImagesPanelView imagesPanelView)
        {
            var disposableBuilder = Disposable.CreateBuilder();
            var spheresAreVisible = false;
            foreach (var cubeView in cubesViews)
            {
                cubeView.Clicked
                    .Subscribe(clickFlags =>
                    {
                        if ((clickFlags & CubeView.ClickFlags.ShowSpheres) == CubeView.ClickFlags.ShowSpheres)
                        {
                            spheresAreVisible = !spheresAreVisible;
                            foreach (var sphere in spheres)
                                sphere.SetActive(spheresAreVisible);
                        }

                        if((clickFlags & CubeView.ClickFlags.ShowUIImages) == CubeView.ClickFlags.ShowUIImages)
                            imagesPanelView.Visible = true;
                    })
                    .AddTo(ref disposableBuilder);
            }
            _subs = disposableBuilder.Build();
        }

        public void Dispose() => _subs?.Dispose();
    }
}