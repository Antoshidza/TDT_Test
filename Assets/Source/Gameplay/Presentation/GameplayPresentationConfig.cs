using UnityEngine;

namespace Source.Gameplay.Presentation
{
    [CreateAssetMenu(fileName = "GameplayPresentationConfig", menuName = "App/Gameplay/Presentation/Config", order = 0)]
    public class GameplayPresentationConfig : ScriptableObject
    {
        [field: SerializeField] public float CubeDistanceThreshold { get; private set; }
        [field: SerializeField] public float UnitsPerMeter { get; private set; }
        [field: SerializeField] public int ImagesCount { get; private set; }
    }
}