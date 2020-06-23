using System.Collections;
using UnityEngine;


    public class EnemyPatrolStateController : MonoBehaviour
    {
        [SerializeField] public Transform[] wayPoints;
        [SerializeField] public float waitTimeBeforeMovingAgain = 2f;

        public bool WaitForTimer()
        {
            StartCoroutine(Wait());
            return true;
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(waitTimeBeforeMovingAgain);
            
        }
    }
