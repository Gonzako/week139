using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class gamePlayDisabler : MonoBehaviour, IGameEventListener<float>
{
    public FloatGameEvent eventToListen;
    public List<Behaviour> behavsToDisable;

    public void OnEventRaised(float value)
    {
        
    }

    // Start is called before the first frame update


    private void Start()
    {
        eventToListen.AddListener(this);
    }
}
