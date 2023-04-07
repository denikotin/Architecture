using UnityEngine;

namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public class GameLoopState : IState
    {
        public GameLoopState(IGameStateMachine gameStateMachine, ServiceLocator serviceLocator)
        {
        }
        public void Enter()
        {
            Debug.Log($"Entered {this.GetType().Name}");
        }

        public void Exit()
        {
        }
    }
}
