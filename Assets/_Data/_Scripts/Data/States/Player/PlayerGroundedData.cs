using System;
using UnityEngine;

namespace Gyu_
{
    [Serializable]
    public class PlayerGroundedData
    {
        [field: SerializeField] public float BaseSpeed { get; private set; } = 5f;
        [field: SerializeField] public PlayerRotationData BaseRotationData { get; private set; }
        [field: SerializeField] public PlayerWalkData PlayerWalkData { get; private set; }
        [field: SerializeField] public PlayerRunData PlayerRunData { get; private set; }
    
        
    }
}
