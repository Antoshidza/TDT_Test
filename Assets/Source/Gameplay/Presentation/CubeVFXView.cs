using System;
using R3;
using UnityEngine;
using UnityEngine.VFX;

namespace Source.Gameplay.Presentation
{
    public class CubeVFXView : MonoBehaviour, IDisposable
    {
        private static readonly int SpawnPointAPropID = Shader.PropertyToID("_spawnPointA");
        private static readonly int SpawnPointBPropID = Shader.PropertyToID("_spawnPointB");
        
        [SerializeField] private VisualEffect _vfx;
        private bool _isPlaying;
        private IDisposable _updateSub;

        private void Start() => _vfx.Stop();

        public void Play(Transform cubeA, Transform cubeB)
        {
            if(_isPlaying) return;
            _isPlaying = true;
            
            _vfx.Play();
            _updateSub = Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    _vfx.SetVector3(SpawnPointAPropID, cubeA.transform.position);
                    _vfx.SetVector3(SpawnPointBPropID, cubeB.transform.position);
                })
                .AddTo(cubeA)
                .AddTo(cubeB);
        }

        public void Stop()
        {
            if(!_isPlaying) return;
            _isPlaying = false;
            
            _vfx.Stop();
            _updateSub?.Dispose();
        }

        public void Dispose() 
            => _updateSub?.Dispose();
    }
}