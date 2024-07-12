namespace Gyu_
{

    public abstract class StateMachine
    {
        #region [Elements]

        protected IState currentState;

        #endregion

        public void ChangeState(IState state)
        {
            currentState?.Exit();

            currentState = state;

            currentState.Enter();
        }

        public void HandleInput()
        {
            currentState?.HandleInput();
        }
        public void Update()
        {
            currentState?.Update();
        }
        public void PhysicsUpdate()
        {
            currentState?.PhysicsUpdate();
        }
    }
}
