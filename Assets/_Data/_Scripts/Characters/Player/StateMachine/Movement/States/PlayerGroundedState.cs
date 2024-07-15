using UnityEngine;
using UnityEngine.InputSystem;

namespace Gyu_
{

    public class PlayerGroundedState : PlayerMovementState
    {
        #region [Elements]



        #endregion

        #region [Override]
        public PlayerGroundedState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
        {
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

        protected virtual void OnMovementCancel(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }

        #endregion

        protected virtual void OnMove()
        {
            if (stateMachine.ResusableData.ShouldWalk)
            {
                stateMachine.ChangeState(stateMachine.WalkingState);
                return;
            }

            stateMachine.ChangeState(stateMachine.RunningState);
        }

    }
}
