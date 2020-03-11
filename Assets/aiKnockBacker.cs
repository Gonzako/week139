using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiKnockBacker : MonoBehaviour
{
    public Vector2 velTorqueWhenThrownHit = new Vector2(4, 20);
    public float timeToWait = 2f;
    Rigidbody2D rb;
    eventDisabler disabler;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void turnIntoDinamic(GameObject caller)
    {
        rb.isKinematic = false;
        disabler.OnEventRaised(timeToWait);
        StartCoroutine(back2Dinamic(timeToWait));
        Vector2 direction = this.transform.position - caller.transform.position;
        direction = direction.normalized;
        rb.velocity = direction * velTorqueWhenThrownHit.x;
        rb.angularVelocity = Random.value * 10 % 2 == 0 ?  velTorqueWhenThrownHit.y : - velTorqueWhenThrownHit.y;
    }

    IEnumerator back2Dinamic(float time)
    {
        yield return new WaitForSeconds(time);
        rb.isKinematic = true;
    }
}
