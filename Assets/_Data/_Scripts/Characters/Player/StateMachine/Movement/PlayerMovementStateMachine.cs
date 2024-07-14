using UnityEngine;

namespace Gyu_
{

    public class PlayerMovementStateMachine : StateMachine
    {
        public PlayerResusableData ResusableData { get; private set; }
        public Player Player { get; private set; }
        public PlayerIdlingState IdlingState { get; }
        public PlayerWalkingState WalkingState { get; }
        public PlayerRunningState RunningState { get; }
        public PlayerSprintingState SprintingState { get; }

        public PlayerMovementStateMachine (Player player)
        {
            this.Player = player;

            ResusableData = new();
            IdlingState = new(this);
            WalkingState = new(this);
            RunningState = new(this);
            SprintingState = new(this);
        }
        
    }
}
