using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OOP.Combat;

namespace OOP.Combat
{
    public class Healht : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        bool isDead = false;

        private void Start()
        {

        }
        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            if (health == 0)
            {
                Die();
                
            }
        }

        private void Die()
        {
            if (isDead == true)
            {
                return;
            }
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }

}
