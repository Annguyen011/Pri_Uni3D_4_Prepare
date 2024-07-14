using UnityEngine;

namespace Gyu_
{

    public class PlayerResusableData
    {
        public Vector2 MovementInput { get; set; }
        public float MovementModifier { get; set; } = 1f;
        public bool ShouldWalk { get; set; }
        private Vector3 currentTargetRotation;
        private Vector3 timeToReachRotation;
        private Vector3 dampedTargetRotationCurrentVelocity;
        private Vector3 dampedTargetRotationPassedTime;

        public ref Vector3 CurrentTargetRotation
        {
            get
            {
                return ref currentTargetRotation;
            }
        }
        public ref Vector3 TimeToReachRotation
        {
            get
            {
                return ref timeToReachRotation;
            }
        }
        public ref Vector3 DampedTargetRotationCurrentVelocity
        {
            get
            {
                return ref dampedTargetRotationCurrentVelocity;
            }
        }
        public ref Vector3 DampedTargetRotationPassedTime
        {
            get
            {
                return ref dampedTargetRotationPassedTime;
            }
        }

    }
}
