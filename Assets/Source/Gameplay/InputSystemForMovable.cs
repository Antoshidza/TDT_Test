using System;
using R3;
using Reflex.Attributes;
using Source.App.Initialization;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Gameplay
{
    public class InputSystemForMovable : IInitializable, IDisposable
    {
        [Inject] private readonly MovableModel _movableModel;
        private InputAction _movement;
        private IDisposable _sub;
        
        public void Initialize()
        {
            _movement = InputSystem.actions.FindAction("Move", true);
            _sub = Observable.EveryUpdate()
                .Subscribe(_ => 
                {
                    if(_movement.IsPressed())
                        _movableModel.Move(_movement.ReadValue<Vector2>());
                });
        }

        public void Dispose() => _sub.Dispose();
    }
}