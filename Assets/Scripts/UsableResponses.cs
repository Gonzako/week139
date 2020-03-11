
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UsableResponses : MonoBehaviour
{

    public UnityEvent onUseResponse;
    public UnityEvent onThrowResponse;
    public UnityEvent onDeequipResponse;
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
        onThrowResponse.Invoke();
    }

    private void callResponse(GameObject args)
    {
        onUseResponse.Invoke();
    }

    private void dequipResponse(GameObject args)
    {
        onDeequipResponse.Invoke();
    }

    private void OnDisable()
    {
        mort.onThisThrow -= throwResponse;
        mort.onThisDeEquip -= dequipResponse;
        mort.onThisUse -= callResponse;
    }
}
