using UnityEngine;

namespace Gyu_
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        #region [Elements]
        [field: Header("# Settings")]
        [field: SerializeField] public PlayerSO Data { get; private set; }

        [field: Header("# Collision data")]
        [field: SerializeField] public CapsualColliderUtilities ColliderUtilities { get; private set; }

        private PlayerMovementStateMachine movementStateMachine;

        // Components
        public PlayerInput Input { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public Transform MainCameraTransform { get; private set; }
        #endregion

        #region [Unity Methods]

        private void Awake()
        {
            Input = GetComponent<PlayerInput>();
            Rigidbody = GetComponent<Rigidbody>();
            MainCameraTransform = Camera.main.transform;

            movementStateMachine = new(this);
            //ColliderUtilities = new();
            //ColliderUtilities.Init(this.gameObject);
            //ColliderUtilities.CalcCaptureColliDimension();
        }

        //private void OnValidate()
        //{
        //    ColliderUtilities = new();
        //    ColliderUtilities.Init(gameObject);
        //    ColliderUtilities.CalcCaptureColliDimension();
        //}

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
    }
}
