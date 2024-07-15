using UnityEngine;

namespace Gyu_
{

    public class PlayerInput : MonoBehaviour
    {
        #region [Elements]

        public PlayerInputActions inputActions { get; private set; }
        public PlayerInputActions.PlayerActions playerActions { get; private set; }

        #endregion

        #region [Unity Methods]

        private void Awake()
        {
            inputActions = new();

            playerActions = inputActions.Player;
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }


        private void OnDisable()
        {
            inputActions.Disable();
        }

        #endregion

    }
}
