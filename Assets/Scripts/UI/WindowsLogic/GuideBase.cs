using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;
using Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder;
using Assets.Scripts.UI.WindowsLogic;

public class GuideBase : WindowBase
{
    public override void Construct(ISaveLoadService saveLoadService, IAudioService audioService)
    {
        base.Construct(saveLoadService, audioService);
    }

    protected override void Initialize()
    {
        base.Initialize();
    }
}
