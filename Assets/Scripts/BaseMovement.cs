using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class BaseMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;


    private Rigidbody2D rb;
    private Vector2 inputVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        if (inputVector.magnitude == 0) rb.velocity = Vector3.zero;

    }

    private void LateUpdate()
    {
    }


    private void FixedUpdate()
    {
        rb.velocity = inputVector * speed;
        inputVector = Vector2.zero;
    }
       
}
