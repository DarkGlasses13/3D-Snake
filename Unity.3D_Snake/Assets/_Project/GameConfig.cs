using UnityEngine;

namespace Assets._Project
{
    [CreateAssetMenu]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public int StartFoodAmount { get; private set; }
    }
}
