using UnityEngine;

namespace Assets.Scripts.Logic.Animation
{
    public class AnimationStateReporter : StateMachineBehaviour
    {
        private IAnimationStateReader _stateReader;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            FindReader(animator);

            _stateReader.EnterState(stateInfo.shortNameHash);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            FindReader(animator);

            _stateReader.ExitState(stateInfo.shortNameHash);
        }

        private void FindReader(Animator animator)
        {
            if (_stateReader != null)
            {
                return;
            }
            _stateReader = animator.gameObject.GetComponent<IAnimationStateReader>();
        }
    }
}

