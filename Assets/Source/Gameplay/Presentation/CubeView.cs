using System;
using R3;
using UnityEngine;

namespace Source.Gameplay.Presentation
{
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private ClickFlags _clickFlags;
        private readonly Subject<ClickFlags> _clicked = new();

        public Observable<ClickFlags> Clicked => _clicked;

        private void OnMouseDown() 
            => _clicked.OnNext(_clickFlags);
        
        [Flags]
        public enum ClickFlags
        {
            None = 0,
            ShowSpheres = 1,
            ShowUIImages = 2
        }
    }
}