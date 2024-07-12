using UnityEngine;

namespace Gyu_
{

    public class PlayerMovementStateMachine : StateMachine
    {
        public PlayerIdlingState IdlingState { get; }
        public PlayerWalkingState WalkingState { get; }
        public PlayerRunningState RunningState { get; }
        public PlayerSprintingState SprintingState { get; }

        public PlayerMovementStateMachine ()
        {
            IdlingState = new();
            WalkingState = new();
            RunningState = new();
            SprintingState = new();
        }
        
    }
}
