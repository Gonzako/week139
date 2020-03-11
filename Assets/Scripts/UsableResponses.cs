
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UsableResponses : MonoBehaviour
{

    public UnityEvent<GameObject> onHitResponse;
    public UnityEvent<GameObject> onThrowResponse;
    public UnityEvent<GameObject> onDeequipResponse;
    private DefaultUsable mort;

    private void OnEnable()
    {
        mort = GetComponent<DefaultUsable>();

        mort.onThisUse -= callResponse;
        mort.onThisUse += callResponse;
        
        mort.onThisThrow -= throwResponse;
        mort.onThisThrow += throwResponse;
        
        mort.onThisDeEquip -= dequipResponse;
        mort.onThisDeEquip += dequipResponse;


    }

    private void throwResponse(GameObject obj)
    {
        onThrowResponse.Invoke(obj);
    }

    private void callResponse(GameObject args)
    {
        onHitResponse.Invoke(args);
    }

    private void dequipResponse(GameObject args)
    {
        onDeequipResponse.Invoke(args);
    }

    private void OnDisable()
    {
        mort.onThisThrow -= throwResponse;
        mort.onThisDeEquip -= dequipResponse;
        mort.onThisUse -= callResponse;
    }
}
