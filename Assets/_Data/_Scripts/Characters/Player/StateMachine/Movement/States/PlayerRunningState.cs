using UnityEngine;
using UnityEngine.InputSystem;

namespace Gyu_
{

    public class PlayerRunningState : PlayerGroundedState
    {
        #region [Elements]



        #endregion

        #region [Override]

        public PlayerRunningState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            stateMachine.ResusableData.MovementModifier = movementData.PlayerRunData.SpeedModifier;
        }

        #endregion

        #region [Input]

        protected override void AddInputActionCallbacks()
        {
            base.AddInputActionCallbacks();

            stateMachine.Player.Input.playerActions.Movement.canceled += OnMovementCancel;
        }


        protected override void RemoveInputActionCallbacks()
        {
            base.RemoveInputActionCallbacks();

            stateMachine.Player.Input.playerActions.Movement.canceled -= OnMovementCancel;
        }

        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);

            stateMachine.ChangeState(stateMachine.WalkingState);
        }
        #endregion
    }
}
