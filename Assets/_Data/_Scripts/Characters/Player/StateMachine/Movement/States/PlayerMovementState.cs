using System;
using UnityEngine;

namespace Gyu_
{

    public class PlayerMovementState : IState
    {
        #region [Elements]

        // Movement data
        protected Vector2 movementInput;
        protected float baseMoveSpeed = 5f;
        protected float speedModifier = 1f;

        protected PlayerMovementStateMachine stateMachine;

        #endregion

        public PlayerMovementState(PlayerMovementStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        #region [Override]

        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {
        }

        public virtual void HandleInput()
        {
            ReadMovementInput();
        }

        public virtual void PhysicsUpdate()
        {
            Move();
        }

        public virtual void Update()
        {
        }

        #endregion

        #region [Input]
        private void ReadMovementInput()
        {
            movementInput = stateMachine.Player.Input.playerActions.Movement.ReadValue<Vector2>();
        }

        #endregion

        #region [Move]

        private void Move()
        {
            if (movementInput.Equals(Vector2.zero) || speedModifier.Equals(0))
                return;

            stateMachine.Player.Rigidbody.AddForce(GetMovementInputDirection() * GetMovementSpeed() - GetPlayerHorizontalVelocity(), ForceMode.VelocityChange);
        }

        protected float GetMovementSpeed() => baseMoveSpeed * speedModifier;

        protected Vector3 GetPlayerHorizontalVelocity()
        {
            Vector3 playerHorizontalVelocity = stateMachine.Player.Rigidbody.velocity;
            playerHorizontalVelocity.y = 0f;
            return playerHorizontalVelocity;
        }

        protected Vector3 GetMovementInputDirection() => new(movementInput.x, 0f, movementInput.y);

        #endregion
    }
}
