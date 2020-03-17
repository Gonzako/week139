using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultUsable : MonoBehaviour, IBaseUsable
{
    public event Action<GameObject> onThisDeEquip;
    public event Action<GameObject> onThisUse;
    public event Action<GameObject> onThisThrow;
    public int throwLayer = 16;
    public GameObject pickableGO;
    public GameObject throwGO;

    [SerializeField]
    float leaveVel = 1;
    
    [SerializeField, Tooltip("X is throw speed, Y is rotation force")]
    Vector2 onThrowVelTorgue = Vector2.one*20;

    public virtual void onDeEquip(Transform oldParent)
    {
        transform.SetParent(oldParent, true);
        pickableGO.transform.position = this.transform.position;
        pickableGO.SetActive(true);
        gameObject.SetActive(false);
        var rb = pickableGO.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.one * leaveVel;
        rb.angularVelocity = 200;
        var rot = transform.rotation.eulerAngles;
        rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);
        onThisDeEquip?.Invoke(gameObject);
    }

    public virtual void onPlayerUse()
    {
        Debug.LogFormat("Use called on {0}", gameObject.name);
        onThisUse?.Invoke(this.gameObject);
    }

    public virtual void onThrow(Transform firePoint)
    {
        throwGO.gameObject.layer = throwLayer;
        onThisThrow?.Invoke(this.gameObject);
        throwGO.transform.position = firePoint.position;
        throwGO.transform.rotation = firePoint.rotation;
        gameObject.SetActive(false);
        throwGO.SetActive(true);
        var rb = throwGO.GetComponent<Rigidbody2D>();
        rb.angularVelocity = UnityEngine.Random.value * 10 % 2 == 0 ? onThrowVelTorgue.y : -onThrowVelTorgue.y;
        rb.velocity = firePoint.right * onThrowVelTorgue.x;
        throwGO.GetComponent<throwableStateTracker>().goToThrowable();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
