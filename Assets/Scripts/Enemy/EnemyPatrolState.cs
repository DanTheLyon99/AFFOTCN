using System.Collections;
using System.Linq;
using Pathfinding;
using UnityEngine;


    public class EnemyPatrolState : StateMachineBehaviour
    {
       [SerializeField] private EnemyPatrolStateController _enemyPatrolStateController;
        private Transform[] _enemyWaypoints;
        private AIDestinationSetter _destinationSetter;
        private AIPath _aiPath;
        private int _currentWaypointIndex = 0;
        private bool _returnToStartingWaypoint;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        { 
            _enemyPatrolStateController = animator.GetComponent<EnemyPatrolStateController>();
           _enemyWaypoints = _enemyPatrolStateController.wayPoints;
           _destinationSetter = animator.GetComponent<AIDestinationSetter>();
           _aiPath = animator.GetComponent<AIPath>();

           _aiPath.slowdownDistance = 0;
           _aiPath.whenCloseToDestination = CloseToDestinationMode.Stop;
           GoToNextWaypoint();

        }

    

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            float distance = Vector2.Distance(_destinationSetter.target.position,animator.transform.position) ;
            if (distance <= _aiPath.pickNextWaypointDist)
            {
                if (_returnToStartingWaypoint)
                    _currentWaypointIndex--;
                else
                    _currentWaypointIndex++;
            }
        }
     
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            
        }

       
        
        private void GoToNextWaypoint()
        {
            if ( _currentWaypointIndex >= _enemyWaypoints.Length)
                _returnToStartingWaypoint = true;
            else if (_currentWaypointIndex <= 0)
                _returnToStartingWaypoint = false;

            _destinationSetter.target = _enemyWaypoints[_currentWaypointIndex];
        }
    }
