using UnityEngine;

namespace Gyu_
{
    [RequireComponent (typeof(PlayerInput))]
    [RequireComponent (typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        #region [Elements]

        private PlayerMovementStateMachine movementStateMachine;

        // Components
        public PlayerInput Input { get; private set; }
        public Rigidbody Rigidbody { get; private set; }

        #endregion

        #region [Unity Methods]

        private void Awake()
        {
            Input = GetComponent<PlayerInput>();
            Rigidbody = GetComponent<Rigidbody>();

            movementStateMachine = new(this);
        }

        private void Start()
        {
            movementStateMachine.ChangeState(movementStateMachine.IdlingState);
        }

        private void Update()
        {
            movementStateMachine.HandleInput();
            movementStateMachine.Update();
        }

        private void FixedUpdate()
        {
            movementStateMachine.PhysicsUpdate();
        }

        #endregion

        #region [Override]



        #endregion

    }
}
