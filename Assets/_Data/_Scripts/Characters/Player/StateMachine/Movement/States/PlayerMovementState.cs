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
        protected Vector3 currentTargetRotation;
        protected Vector3 timeToReachTargetRotation;
        protected Vector3 dampedTargetRotationCurrentVelocity;
        protected Vector3 dampedTargetRotationPassedTime;

        protected PlayerMovementStateMachine stateMachine;

        #endregion

        public PlayerMovementState(PlayerMovementStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;

            Init();
        }

        private void Init()
        {
            timeToReachTargetRotation.y = .14f;
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

            float targetRotationYAngle = Rotate(GetMovementInputDirection());
            Vector3 targetRotationDirection = GetTargetRotationDirection(targetRotationYAngle);

            stateMachine.Player.Rigidbody.AddForce(targetRotationDirection * GetMovementSpeed() - GetPlayerHorizontalVelocity(), ForceMode.VelocityChange);
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

        #region [Rotate]
        protected float Rotate(Vector3 direction)
        {
            float directionAngle = UpdateTargetRotation(direction);

            RotateTowardTargetRotation();

            return directionAngle;
        }

        protected float UpdateTargetRotation(Vector3 direction, bool shouldConsiderCameraRotation = true)
        {
            float directionAngle = GetDirectionAngle(direction);

            if (shouldConsiderCameraRotation)
                directionAngle = AddCameraDirectionAngle(directionAngle);

            if (directionAngle != currentTargetRotation.y)
                UpdateRotationData(directionAngle);

            return directionAngle;
        }

        private void UpdateRotationData(float targetAngle)
        {
            currentTargetRotation.y = targetAngle;

            dampedTargetRotationPassedTime.y = 0f;
        }

        protected void RotateTowardTargetRotation()
        {
            float currentYAngle = stateMachine.Player.Rigidbody.rotation.eulerAngles.y;

            if (currentYAngle.Equals(currentTargetRotation.y))
                return;

            float smoothedYAngle = Mathf.SmoothDampAngle(currentYAngle, currentTargetRotation.y,
                ref dampedTargetRotationCurrentVelocity.y, timeToReachTargetRotation.y -
                dampedTargetRotationPassedTime.y);

            dampedTargetRotationPassedTime.y += Time.deltaTime;

            Quaternion targetRotation = Quaternion.Euler(0f, smoothedYAngle, 0f);
            stateMachine.Player.Rigidbody.MoveRotation(targetRotation);
        }

        private float AddCameraDirectionAngle(float directionAngle)
        {
            directionAngle += stateMachine.Player.MainCameraTransform.eulerAngles.y;

            if (directionAngle > 360f)
                directionAngle -= 360f;
            return directionAngle;
        }

        private static float GetDirectionAngle(Vector3 direction)
        {
            float directionAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

            if (directionAngle < 0f)
                directionAngle += 360f;
            return directionAngle;
        }


        protected  Vector3 GetTargetRotationDirection(float targetAngle)
        {
            return Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        #endregion
    }
}
