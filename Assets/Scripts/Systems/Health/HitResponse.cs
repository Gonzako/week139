using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Mortal))]
public class HitResponse : MonoBehaviour
{

    public UnityAction onHitResponse;
    private Mortal mort;

    private void OnEnable()
    {
        mort = GetComponent<Mortal>();

        mort.onHit -= callResponse;
        mort.onHit += callResponse;
    }

    private void callResponse(int amount, int health, int maxhealth)
    {
        onHitResponse.Invoke();
    }

    private void OnDisable()
    {
        mort.onHit -= callResponse;
    }
}
