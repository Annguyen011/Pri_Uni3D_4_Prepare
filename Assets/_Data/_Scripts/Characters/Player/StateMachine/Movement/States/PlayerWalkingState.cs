using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gyu_
{

    public class PlayerWalkingState : PlayerGroundedState
    {
        #region [Elements]



        #endregion


        #region [Override]

        public PlayerWalkingState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            speedModifier = .225f;
        }

        #endregion

        #region [Input]

        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);

            stateMachine.ChangeState(stateMachine.RunningState);
        }
        #endregion
    }
}
