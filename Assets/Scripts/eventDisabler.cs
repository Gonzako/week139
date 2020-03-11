using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class eventDisabler : MonoBehaviour, IGameEventListener<float>
{
    public FloatGameEvent eventToListen;
    public List<Behaviour> behavsToDisable;
    public float defaultTimeToWait = 2f;
    private Coroutine corot;

    public void OnEventRaised(float value)
    {
        if (value == default(float))
            value = defaultTimeToWait;
        Debug.LogFormat("{0} disabled for {1} seconds", gameObject.name, value);
        foreach(Behaviour n in behavsToDisable)
        {
            n.enabled = false;
        }
        corot = StartCoroutine(backToNormal(value));
    }

    IEnumerator backToNormal(float time)
    {
        yield return new WaitForSeconds(time);
        foreach(Behaviour n in behavsToDisable)
        {
            n.enabled = true;
        }
    }

    // Start is called before the first frame update


    private void Start()
    {
        eventToListen?.AddListener(this);
    }
}
