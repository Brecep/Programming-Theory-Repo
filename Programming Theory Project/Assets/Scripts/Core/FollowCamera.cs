using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOP.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;
        private Vector3 offset;
        void Start()
        {
            offset = transform.position - target.position;
        }


        void LateUpdate()
        {
            transform.position = target.position + offset;
        }
    }
}

