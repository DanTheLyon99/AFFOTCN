using Pathfinding;
using UnityEngine;


    public class EnemyChaseState : StateMachineBehaviour
    {
        private AIDestinationSetter _destinationSetter;
        private Transform _playerPos;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            _destinationSetter = animator.GetComponent<AIDestinationSetter>();
            _playerPos = FindObjectOfType<Player>().transform;
            _destinationSetter.target = _playerPos;

        }
        
        // public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
        //     int layerIndex)
        // {
        // }
        //
        // public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
        //     int layerIndex)
        // {
        // }
    }
