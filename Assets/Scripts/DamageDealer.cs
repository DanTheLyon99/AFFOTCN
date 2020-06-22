using UnityEngine;


    public class DamageDealer : MonoBehaviour
    {
        //Gets the damage from the WeaponController
        public int Damage { get; set; }
        public void OnHit(GameObject damaged)
        {
            Health health = damaged.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(Damage,this,damaged);
            }
        }
    }
