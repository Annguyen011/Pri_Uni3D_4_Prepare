using UnityEngine;

namespace Gyu_
{

    public interface IState 
    {
        public void Enter();
        public void Exit();
        public void HandleInput();
        // Same update
        public void Update();
        // Same fixedUpdate
        public void PhysicsUpdate();
    }
}
