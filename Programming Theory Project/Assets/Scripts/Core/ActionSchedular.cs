using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOP.Core
{
    public class ActionSchedular : MonoBehaviour
    {
        IAction currentAction;
        
        public void StartAction(IAction action)
        {
            if (currentAction == action)
            {
                return;
            }
            if (currentAction != null)
            {
                currentAction.Cancel();
            }
            currentAction = action;
        }
    }
}

