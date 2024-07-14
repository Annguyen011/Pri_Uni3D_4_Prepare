using UnityEngine;

namespace Gyu_
{
    [CreateAssetMenu(fileName = "Player", menuName = "SO/Character/Player")]
    public class PlayerSO : ScriptableObject
    {
        [field: SerializeField] public PlayerGroundedData GroundedData { get; private set; }


    }
}
