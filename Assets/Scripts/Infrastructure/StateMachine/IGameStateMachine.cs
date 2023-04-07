using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.StateMachine.States;

namespace Assets.Scripts.Infrastructure.StateMachine
{
    public interface IGameStateMachine:IService
    {
        public void EnterToState<TState>() where TState : class, IState;
        public void EnterToState<TState,TPayloads>(TPayloads payloads) where TState : class, IPayloadState<TPayloads>;
    }
}
