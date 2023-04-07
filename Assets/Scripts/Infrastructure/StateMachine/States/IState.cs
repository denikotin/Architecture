namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public interface IState: IExitState
    {
        public void Enter();
    }
}
