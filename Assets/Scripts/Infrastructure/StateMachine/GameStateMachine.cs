using System;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.Infrastructure.StateMachine.States;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitState> _states;
        private IExitState _currentState;
        private ServiceLocator _serviceLocator;
        private ISceneLoader _sceneLoader;

        public GameStateMachine(ServiceLocator serviceLocator, ISceneLoader sceneLoader, GameObject loadingCurtain)
        {
            _states = new Dictionary<Type, IExitState>();
            _serviceLocator = serviceLocator;
            _sceneLoader = sceneLoader;
            

            CreateStates(loadingCurtain);
        }

        public void EnterToState<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void EnterToState<TState, TPayloads>(TPayloads payloads) where TState : class, IPayloadState<TPayloads>
        {
            TState state = ChangeState<TState>();
            state.Enter(payloads);
        }


        private void CreateStates(GameObject loadingCurtain)
        {
            _states[typeof(BootstrapState)] = new BootstrapState(this, _serviceLocator,_sceneLoader);
            _states[typeof(LoadProgressState)] = new LoadProgressState(this, _serviceLocator);
            _states[typeof(LoadMenuSceneState)] = new LoadMenuSceneState(this, _serviceLocator, loadingCurtain);
            _states[typeof(LoadPlaySceneState)] = new LoadPlaySceneState(this, _serviceLocator, loadingCurtain);
            _states[typeof(GameLoopState)] = new GameLoopState(this, _serviceLocator);
        }


        private TState ChangeState<TState>() where TState : class, IExitState
        {
            if(_currentState != null)
            {
                _currentState.Exit();
            }
            TState state = GetState<TState>();
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}
