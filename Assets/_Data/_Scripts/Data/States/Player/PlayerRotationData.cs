using System;
using UnityEngine;

namespace Gyu_
{
    [Serializable]
    public class PlayerRotationData
    {
        [field:SerializeField]public Vector3 TargetRotationReachTime { get; private set; }

    }
}
