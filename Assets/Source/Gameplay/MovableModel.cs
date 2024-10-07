using Unity.Mathematics;
using UnityEngine;

namespace Source.Gameplay
{
    public class MovableModel
    {
        private readonly float _moveSpeed;
        private readonly float _maxMoveSpeed;

        public Rigidbody Body { private get; set; }

        public MovableModel(in float moveSpeed, in float maxMoveSpeed)
        {
            _moveSpeed = moveSpeed;
            _maxMoveSpeed = maxMoveSpeed;
        }

        public void Move(float2 movement)
        {
            if (!Body)
                throw new GameplayException($"There is nothing set to move.");
            
            movement *= _moveSpeed;
            var movement3d = new float3(movement.x, 0f, movement.y);
            
            Body.AddForce(movement3d);
            if (Body.linearVelocity.sqrMagnitude > _maxMoveSpeed)
                Body.linearVelocity = Body.linearVelocity.normalized * _maxMoveSpeed;
        }
    }
}