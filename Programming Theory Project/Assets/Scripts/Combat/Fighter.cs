using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OOP.Movement;
using UnityEngine.AI;
using OOP.Core;

namespace OOP.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponRange;
        [SerializeField] float weaponDamage = 10f;

        Transform targetObject;
        float timeSinceLastAttack;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (targetObject == null)
            {
                return;
            }

            if (GetIsInRange() == false)
            {
                GetComponent<Mover>().MoveTo(targetObject.position);

            }
            else
            {
                AttackMethod();
                GetComponent<Mover>().Cancel();
            }
        }

        private void AttackMethod()
        {
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;
                
            }

        }
        void Hit()//animation event
        {
            Healht healht = targetObject.GetComponent<Healht>();
            healht.TakeDamage(weaponDamage);
        }
        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, targetObject.position) < weaponRange;
        }

        public void Attack(CombatTarget target)
        {
            GetComponent<ActionSchedular>().StartAction(this);
            targetObject = target.transform;
        }

        //Interface
        public void Cancel()
        {
            //GetComponent<NavMeshAgent>().isStopped = false;
            targetObject = null;
        }
    }

}

