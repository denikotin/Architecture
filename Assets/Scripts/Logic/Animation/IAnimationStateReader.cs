using Assets.Scripts.Data.Enums;

namespace Assets.Scripts.Logic.Animation
{
    public interface IAnimationStateReader
    {
        void EnterState(int stateHash);
        void ExitState(int stateHash);

        AnimatorStates State { get; }
    }
}

