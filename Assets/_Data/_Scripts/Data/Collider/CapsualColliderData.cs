using UnityEngine;

namespace Gyu_
{

    public class CapsualColliderData
    {
        #region [Elements]

        public CapsuleCollider Collider { get; private set; }
        public Vector3 ColliderCenterInLocalSpace {  get; private set; }


    	#endregion

        public void Init(GameObject gameObject)
        {
            if (Collider == null)
                return;

            Collider = gameObject.GetComponent<CapsuleCollider>();
            UpdateColliderData();
        }

        public void UpdateColliderData()
        {
            ColliderCenterInLocalSpace = Collider.center;
        }
    }
}
