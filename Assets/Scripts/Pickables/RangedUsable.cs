using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedUsable : DefaultUsable
{
    public GameObject bulletPrefab;
    public Transform firingPoint;
    public Transform bulletParent;

    public override void onPlayerUse()
    {
        base.onPlayerUse();
        //no pooling, might get problems later on
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation, bulletParent);
    }

}
