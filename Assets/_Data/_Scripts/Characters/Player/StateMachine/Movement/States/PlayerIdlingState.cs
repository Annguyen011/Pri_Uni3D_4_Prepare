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

            stateMachine.ResusableData.MovementModifier = 0f;
            ResetVelocity();
        }

        public override void Update()
        {
            base.Update();

            if (stateMachine.ResusableData.MovementInput.Equals(Vector2.zero))
                return;

            OnMove();
        }

        #endregion


    }
}
