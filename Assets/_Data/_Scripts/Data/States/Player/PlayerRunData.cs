using System;
using UnityEngine;

namespace Gyu_
{
    [Serializable]
    public class PlayerRunData
    {
        [field: SerializeField] public float SpeedModifier { get; private set; } = 1f;

    }

}
