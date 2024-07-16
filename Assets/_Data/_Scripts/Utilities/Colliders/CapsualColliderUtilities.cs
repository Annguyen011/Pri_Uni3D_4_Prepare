using System;
using UnityEngine;

namespace Gyu_
{
    [Serializable]
    public class CapsualColliderUtilities
    {
        #region [Elements]

        public CapsualColliderData CapsualColliderData { get; private set; }
        [field: SerializeField] public DefaulColliderData DefaulColliderData { get; private set; }
        [field: SerializeField] public SlopeData SlopeData { get; private set; }


        #endregion

        public void Init(GameObject gameObject)
        {
            if (CapsualColliderData != null)
                return;

            CapsualColliderData = new();
            DefaulColliderData = new();

            CapsualColliderData.Init(gameObject);
        }

        public void CalcCaptureColliDimension()
        {
            SetCaptureColliderRadius(DefaulColliderData.Radius);
            SetCaptureColliderHeight(DefaulColliderData.Height * (1f - SlopeData.StepHeightPercentage));
            RecalculateCaptureColliderCenter();

            float halfColliderHeight = CapsualColliderData.Collider.height / 2f;

            if (halfColliderHeight < CapsualColliderData.Collider.radius)
                SetCaptureColliderRadius(halfColliderHeight);

            CapsualColliderData.UpdateColliderData();
        }

        public void SetCaptureColliderRadius(float radius)
        {
            CapsualColliderData.Collider.radius = radius;
        }

        public void SetCaptureColliderHeight(float height)
        {
            CapsualColliderData.Collider.height = height;
        }

        public void RecalculateCaptureColliderCenter()
        {
            float colliderHeightDiff = DefaulColliderData.Height - CapsualColliderData.Collider.height;
            Vector3 newColliderCenter = new Vector3(0f, DefaulColliderData.CenterY + (colliderHeightDiff / 2f), 0f);

            CapsualColliderData.Collider.center = newColliderCenter;        
        }
    }
}
