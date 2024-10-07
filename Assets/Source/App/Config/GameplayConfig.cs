using UnityEngine;

namespace Source.App.Config
{
    [CreateAssetMenu(fileName = "GameplayConfig", menuName = "App/Gameplay/Config", order = 0)]
    public class GameplayConfig : ScriptableObject
    {
        [field: SerializeField] public float CubeMoveSpeed { get; private set; }
        [field: SerializeField] public float CubeMaxMoveSpeed { get; private set; }
    }
}