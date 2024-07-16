using System;
using UnityEngine;

namespace Gyu_
{
    [Serializable]
    public class SlopeData 
    {
        #region [Elements]

        [field: SerializeField] public float StepHeightPercentage {  get; private set; } = .25f;


    	#endregion


    }
}
