using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPickable : MonoBehaviour, BasePickable
{
    public event Action<GameObject> onThisHighLight;
    public event Action<GameObject> onThisPickup;
    public GameObject UsableGO { get => usableGO.gameObject; }



    [SerializeField]
    protected DefaultUsable usableGO;


    public virtual void onHighlight(GameObject caller)
    {
        throw new System.NotImplementedException();
    }

    public virtual GameObject onPickup(GameObject caller)
    {
        gameObject.SetActive(false);
        usableGO.gameObject.SetActive(true);
        onThisPickup?.Invoke(usableGO.gameObject);
        return usableGO.gameObject;
    }

}
