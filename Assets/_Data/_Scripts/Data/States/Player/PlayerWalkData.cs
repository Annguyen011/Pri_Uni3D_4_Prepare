using System;
using UnityEngine;

namespace Gyu_
{
    [Serializable]
    public class PlayerWalkData
    {
        [field: SerializeField]
        public float SpeedModifier { get; private set; } = .225f;        
    }
}
