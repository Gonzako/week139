﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using System;

public class characterItemManager : MonoBehaviour
{
    /// <summary>
    /// Callback mostly for UI prompting
    /// </summary>
    public GameObjectGameEvent onAnyHighLight;

    /// <summary>
    /// When the player picks up an Object, object sent is the usable
    /// </summary>
    public GameObjectGameEvent onAnyPickup;

    /// <summary>
    /// When the player either pickups or leaves 
    /// </summary>
    public GameEvent onNoHighLight;

    public GameObjectGameEvent onAnyThrow;

    [SerializeField]
    Transform weaponPoint;

    [SerializeField]
    int pickableLayerIndex;
    [SerializeField]
    Transform itemPoint;
    pickerState currentState = 0;

    private DefaultUsable currentItem;
    private Transform currentItemOldParent;
    //nearest stack like behaviour with remove functionality
    LinkedList<DefaultPickable> pickList = new LinkedList<DefaultPickable>();

    #region UnityAPI
    void Start()
    {
        Debug.Log(string.Format("Player started checking for pickables in layer {0}", LayerMask.LayerToName(pickableLayerIndex)));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            PickupCurrentShown();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            ThrowWeapon();
        }

    }




    //this function assummes collided object always has BasePickable
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == pickableLayerIndex)
        {
            var pickable = other.gameObject.GetComponent<DefaultPickable>();
            pickList.AddFirst(pickable);
            Debug.Log(string.Format("Item called {0} added to the pickables list", other.gameObject.name));
            onAnyHighLight.Raise(pickable.gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == pickableLayerIndex)
        {
            var pickable = other.gameObject.GetComponent<DefaultPickable>();
            if (pickList.First.Value == pickable)
            {
                pickList.RemoveFirst();
                Debug.Log(string.Format("Item called {0} removed from the top of pickables list", other.gameObject.name));
                if (pickList.Count == 0)
                {
                    onNoHighLight.Raise();
                }
                else
                {
                    onAnyHighLight.Raise(pickList.First.Value.gameObject);
                }

            }
            else
            {
                //if its not the 1st one we dont need to rehighlight it or check the size of the LL
                pickList.Remove(pickable);

                Debug.Log(string.Format("Item called {0} removed from the pickables list", other.gameObject.name));
            }

        }
    }

    #endregion

    #region Private Functions
    private void PickupCurrentShown()
    {
        if(currentState == pickerState.holding)
        {
            currentItem.onDeEquip(currentItemOldParent);
            currentItemOldParent = null;
            if (pickList.Count == 0) return;
        }
        if (pickList.Count != 0)
        {
            var selectedItem = pickList.First.Value.onPickup();
            pickList.RemoveFirst();
            currentItemOldParent = selectedItem.transform.parent;
            selectedItem.transform.SetParent(weaponPoint, false);
            selectedItem.transform.localPosition = Vector3.zero;
            onAnyPickup.Raise(selectedItem); 
        }
    }
    
    private void ThrowWeapon()
    {
        if (currentState == pickerState.holding)
        {
            currentItem.gameObject.transform.SetParent(currentItemOldParent, true);
            currentItem.onThrow();
            currentItemOldParent = null;
            onAnyThrow.Raise(currentItem.throwGO);
        }    
    }
    #endregion
}

internal enum pickerState
{
    none, holding
}