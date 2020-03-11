using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCallerTracker : MonoBehaviour
{

    public static AiCallerTracker instance;

    [HideInInspector]
    public List<AiAttentionCaller> attentionCallers = new List<AiAttentionCaller>();


    private void OnEnable()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
        }
        attentionCallers.AddRange(
            FindObjectsOfType<AiAttentionCaller>()
            );
    }

    private void OnDisable()
    {
        if(instance == this)
        {
            instance = null;
        }
    }

}
