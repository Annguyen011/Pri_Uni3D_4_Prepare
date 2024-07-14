using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gyu_
{

    public class PlayerMovementState : IState
    {
        #region [Elements]

        // Movement data
        protected PlayerMovementStateMachine stateMachine;
        protected PlayerGroundedData movementData;
        #endregion

        public PlayerMovementState(PlayerMovementStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            movementData = stateMachine.Player.Data.GroundedData;
            Init();
        }

        private void Init()
        {
            stateMachine.ResusableData.TimeToReachRotation = movementData.BaseRotationData.TargetRotationReachTime;
        }

        #region [Override]

        public virtual void Enter()
        {
            AddInputActionCallbacks();
        }


        public virtual void Exit()
        {
            RemoveInputActionCallbacks();
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

        protected virtual void AddInputActionCallbacks()
        {
            stateMachine.Player.Input.playerActions.WalkToggle.started += OnWalkToggleStarted;
        }


        protected virtual void RemoveInputActionCallbacks()
        {
            stateMachine.Player.Input.playerActions.WalkToggle.started -= OnWalkToggleStarted;
        }

        private void ReadMovementInput()
        {
            stateMachine.ResusableData.MovementInput = stateMachine.Player.Input.playerActions.Movement.ReadValue<Vector2>();
        }

        #endregion

        #region [Event]

        protected virtual void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            stateMachine.ResusableData.ShouldWalk = !stateMachine.ResusableData.ShouldWalk;
        }

        #endregion

        #region [Move]

        private void Move()
        {
            if (stateMachine.ResusableData.MovementInput.Equals(Vector2.zero) || stateMachine.ResusableData.MovementModifier.Equals(0))
                return;

            float targetRotationYAngle = Rotate(GetMovementInputDirection());
            Vector3 targetRotationDirection = GetTargetRotationDirection(targetRotationYAngle);

            stateMachine.Player.Rigidbody.AddForce(targetRotationDirection * GetMovementSpeed() - GetPlayerHorizontalVelocity(), ForceMode.VelocityChange);
        }


        protected float GetMovementSpeed() => movementData.BaseSpeed * stateMachine.ResusableData.MovementModifier;

        protected Vector3 GetPlayerHorizontalVelocity()
        {
            Vector3 playerHorizontalVelocity = stateMachine.Player.Rigidbody.velocity;
            playerHorizontalVelocity.y = 0f;
            return playerHorizontalVelocity;
        }

        protected Vector3 GetMovementInputDirection() => new(stateMachine.ResusableData.MovementInput.x, 0f, stateMachine.ResusableData.MovementInput.y);

        protected void ResetVelocity()
        {
            stateMachine.Player.Rigidbody.velocity = Vector3.zero;
        }

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

            if (directionAngle != stateMachine.ResusableData.CurrentTargetRotation.y)
                UpdateRotationData(directionAngle);

            return directionAngle;
        }

        private void UpdateRotationData(float targetAngle)
        {
            stateMachine.ResusableData.CurrentTargetRotation.y = targetAngle;

            stateMachine.ResusableData.DampedTargetRotationPassedTime.y = 0f;
        }

        protected void RotateTowardTargetRotation()
        {
            float currentYAngle = stateMachine.Player.Rigidbody.rotation.eulerAngles.y;

            if (currentYAngle.Equals(stateMachine.ResusableData.CurrentTargetRotation.y))
                return;

            float smoothedYAngle = Mathf.SmoothDampAngle(currentYAngle, stateMachine.ResusableData.CurrentTargetRotation.y,
                ref stateMachine.ResusableData.DampedTargetRotationCurrentVelocity.y, stateMachine.ResusableData.TimeToReachRotation.y -
                            stateMachine.ResusableData.DampedTargetRotationPassedTime.y);

            stateMachine.ResusableData.DampedTargetRotationPassedTime.y += Time.deltaTime;

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
            float directionAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            if (directionAngle < 0f)
                directionAngle += 360f;
            return directionAngle;
        }


        protected Vector3 GetTargetRotationDirection(float targetAngle)
        {
            return Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        #endregion
    }
}
