﻿using System;
using System.Collections.Generic;

namespace Architecture
{
    public class InteractorsBase
    {
        private Dictionary<Type, Interactor> _interactorsMap;
        private SceneConfig _sceneConfig;
        
        public InteractorsBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void CreateAllInteractors()
        {
           _interactorsMap = _sceneConfig.CreateAllInteractors();
        }

        public void SendOnCreateToAllInteractors()
        {
            foreach(var interactor in _interactorsMap.Values)
            {
                interactor.OnCreate();
            }
        }

        public void SendInitializeToAllInteractors()
        {
            foreach(var interactor in _interactorsMap.Values)
            {
                interactor.Initialize();
            }
        }

        public void SendOnStartToAllInteractors()
        {
            foreach (var interactor in _interactorsMap.Values)
            {
                interactor.OnStart();
            }
        }

        public T GetInteractor<T>() where T: Interactor
        {
            var type = typeof(T);
            return (T) _interactorsMap[type];
        }

    }
}
