namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public interface IPayloadState<TPayloads>:IExitState
    {
        public void Enter(TPayloads payloads); 
    }
}
