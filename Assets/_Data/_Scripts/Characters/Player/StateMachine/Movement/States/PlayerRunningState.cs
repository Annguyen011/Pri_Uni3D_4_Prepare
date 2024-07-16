using UnityEngine;
using UnityEngine.InputSystem;

namespace Gyu_
{

    public class PlayerRunningState : PlayerMovingState
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

        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);

            stateMachine.ChangeState(stateMachine.WalkingState);
        }
        #endregion
    }
}
