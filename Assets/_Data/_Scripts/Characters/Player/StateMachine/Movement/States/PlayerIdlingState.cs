using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Gyu_
{

    public class PlayerIdlingState : PlayerGroundedState
    {
        #region [Elements]



        #endregion

        #region [Unity Methods]



        #endregion

        #region [Override]

        public PlayerIdlingState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            speedModifier = 0f;
            ResetVelocity();
        }

        public override void Update()
        {
            base.Update();

            if (movementInput.Equals(Vector2.zero))
                return;

            OnMove();
        }

        #endregion

        #region [Move]

        private void OnMove()
        {
            if (shouldWalk)
            {
                stateMachine.ChangeState(stateMachine.WalkingState);
                return;
            }

            stateMachine.ChangeState(stateMachine.RunningState);
        }

        #endregion
    }
}
