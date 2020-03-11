using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class AiAttentionCaller : MonoBehaviour
{

    public event Action<GameObject> onMakeNoise;

    private List<Action> delegates = new List<Action>();



    public void listenToEvent(Action caller)
    {
        delegates.Add(caller);
        caller += callForAttention;
    }

    public void callForAttention()
    {
        onMakeNoise.Invoke(this.gameObject);
    }

    private void OnDisable()
    {
        for (int i = 0; i < delegates.Count; i++)
        {
           delegates[i] -= callForAttention;
        } 
                     
    }

}