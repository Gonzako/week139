using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float velocity = 4;

    private void FixedUpdate()
    {
        transform.position += transform.right * velocity * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherMortal = other.gameObject.GetComponent<Mortal>();
        otherMortal?.Damage(1);
        Destroy(this.gameObject);
    }

}
