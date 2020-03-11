using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeeleeHitter))]
public class MeeleeUsable : DefaultUsable
{
    public float cooldownTime = 0.4f;
    public float activeTime = 0.2f;

    MeeleeHitter hitter;
    private float attackTimer;
    private float cooldownTimer;
    private void Start()
    {
        hitter = GetComponent<MeeleeHitter>();
    }

    public override void onThrow(Transform args1)
    {
        base.onThrow(args1);
        var pickable = pickableGO.GetComponent<MeeleePickable>();
        //hitter.originPoint.position -= (Vector3)pickable.weaponPointOffset;
        hitter.originPoint = null;
        
    }

    public override void onPlayerUse()
    {
        base.onPlayerUse();
        if(cooldownTimer < Time.time)
        {
            Debug.Log("attackCalled");
            StartCoroutine(attackTillActiveFrames());
        }
    }

    IEnumerator attackTillActiveFrames()
    {
        attackTimer = Time.time + activeTime;
        cooldownTimer = Time.time + activeTime + cooldownTime;
        while(attackTimer > Time.time)
        {
            Debug.Log("tried to Hitter");
            hitter.Attack();
            yield return null;
        }
        hitter.ClearList();
    }
}
