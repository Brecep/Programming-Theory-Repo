using OOP.Combat;
using OOP.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace OOP.Movement
{
    public class Mover : MonoBehaviour,IAction
    {
        void Update()
        {
            UpdateAnimator();
        }
        public void StartMoveAction(Vector3 hit)
        {
            GetComponent<ActionSchedular>().StartAction(this);
            GetComponent<NavMeshAgent>().isStopped = false;
            GetComponent<Fighter>().Cancel();
            GetComponent<NavMeshAgent>().destination = hit;
        }
        public void MoveTo(Vector3 hit)
        {
            GetComponent<NavMeshAgent>().destination = hit;
            GetComponent<NavMeshAgent>().isStopped = false;
        }
        public void Cancel()
        {
            GetComponent<NavMeshAgent>().isStopped = true;
        }
        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
     
    }
}


