namespace Architecture
{
    public sealed class SceneManagerExample : SceneManagerBase
    {
        public override void InitScenesMap()
        {
            sceneConfigMap[SceneConfigExample.SCENE_NAME] = new SceneConfigExample();
        }
    }
}
