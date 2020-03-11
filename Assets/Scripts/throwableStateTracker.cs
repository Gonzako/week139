using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwableStateTracker : MonoBehaviour
{
    public float dragAsThrowable = 1;
    public float angularDragThr = 0.3f;
    public PhysicsMaterial2D materialAsThrowable;

    private int layerAsPickable ;
    private int layerAsThrowable;

    public List<Behaviour> behavsAsPickable;
    public List<Behaviour> behavsAsThrowable;

    private PhysicsMaterial2D matAsPick;
    private float startingDrag;
    private float startingAngular;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingDrag = rb.drag;
        startingAngular = rb.angularDrag;
        matAsPick = rb.sharedMaterial;
        layerAsPickable = LayerMask.NameToLayer("Pickables");
        layerAsThrowable = LayerMask.NameToLayer("Throwables");
        foreach (Behaviour n in behavsAsThrowable)
        {
            n.enabled = false;
        }
        foreach (Behaviour n in behavsAsPickable)
        {
            n.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void goToPickable()
    {
        gameObject.layer = layerAsPickable;
        foreach(Behaviour n in behavsAsThrowable)
        {
            n.enabled = false;
        }
        foreach(Behaviour n in behavsAsPickable)
        {
            n.enabled = true;
        }
        rb.drag = startingDrag;
        rb.angularDrag = startingAngular;
        rb.sharedMaterial = matAsPick;
    }

    internal void goToThrowable()
    {
        gameObject.layer = layerAsThrowable;
        rb.sharedMaterial = materialAsThrowable;
        rb.drag = dragAsThrowable;
        rb.angularDrag = angularDragThr;
        foreach (Behaviour n in behavsAsPickable)
        {
            n.enabled = false;
        }
        foreach (Behaviour n in behavsAsThrowable)
        {
            n.enabled = true;
        }
    }
}
