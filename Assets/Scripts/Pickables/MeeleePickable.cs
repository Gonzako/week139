using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleePickable : DefaultPickable
{
    public Vector2 weaponPointOffset = Vector2.zero;


    Transform weapPoint;
    public MeeleeHitter hitter;
    private Vector3 originalLocal;

    private void Start()
    {
    }
    public override GameObject onPickup(GameObject caller)
    {
        var usableGO = base.onPickup(caller);
        weapPoint = caller.GetComponent<IItemPicker>().WeaponPoint;
        originalLocal = weapPoint.localPosition;
        //weapPoint.localPosition += (Vector3)weaponPointOffset;
        hitter.originPoint = weapPoint;
        
        return usableGO;
    }

}
