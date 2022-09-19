using System;
using System.Collections.Generic;

namespace Architecture
{
    public class SceneConfigExample : SceneConfig
    {
        public const string SCENE_NAME = "SampleScene";
        public override string SceneName => SCENE_NAME;

        public override Dictionary<Type, Repository> CreateAllRepository()
        {
            var repositoryMap = new Dictionary<Type, Repository>();

            CreateRepository<BankRepository>(repositoryMap);

            return repositoryMap;
        }

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            var interactorsMap = new Dictionary<Type, Interactor>();

            CreateInteractor<BankInteractor>(interactorsMap);
            CreateInteractor<PlayerInteractor>(interactorsMap);

            return interactorsMap;
        }
    }
}
