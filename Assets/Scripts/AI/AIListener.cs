using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIListener : MonoBehaviour
{
    public List<Vector3> _audiblePosition =  new List<Vector3>();

    public delegate void AIListenerEvents(GameObject actor);
    public AIListenerEvents onAlertableActionDone;

    private void OnDisable()
    {
        
    }

    private void OnEnable()
    {
        
    }
}
