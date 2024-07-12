using UnityEngine;

namespace Gyu_
{

    public class PlayerMovementState : IState
    {
        #region [Elements]



        #endregion

        #region [Unity Methods]



        #endregion

        #region [Override]

        public virtual void Enter()
        {
            Debug.Log(GetType().Name);
        }

        public virtual void Exit()
        {
        }

        public virtual void HandleInput()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Update()
        {
        }

        #endregion
    }
}
