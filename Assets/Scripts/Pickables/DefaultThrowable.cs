using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultThrowable : MonoBehaviour, IBaseThrowable
{
    public GameObject pickableGO;
    public LayerMask enemyLayers;
    public float timeToBackToPickable;

    private Coroutine back2pickCor;
    private Rigidbody2D rb;
    private bool firstCol = false;
    private throwableStateTracker stateTracker;

    
    public void launchSelf(Vector2 velocity)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        firstCol = true;
        if (back2pickCor != null)
            StopCoroutine(back2pickCor);
        back2pickCor = StartCoroutine(turnSelfIntoPickabble(timeToBackToPickable));
    }

    protected virtual void Awake()
    {
        stateTracker = GetComponent<throwableStateTracker>();
        this.enabled = false;
    }


    void backToPick()
    {
        stateTracker.goToPickable();
        Debug.LogFormat("{0} turned back to pickable", gameObject.name);
    }

    IEnumerator turnSelfIntoPickabble(float time)
    {
        if (firstCol)
        {
            yield return new WaitForSeconds(time);
            backToPick(); 
        }
    }

    void OnCollisionEnter2D(Collision2D otherCol)
    {
        if (this.enabled)
        {
            if ((enemyLayers.value & 1 << otherCol.gameObject.layer) > 0  && firstCol)
            {

                //Hitting enemy with throwable code here
            }

            back2pickCor = StartCoroutine(turnSelfIntoPickabble(0.1f));
            firstCol = false;


        }
    }
}
