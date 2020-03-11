using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BasePickable
{
    void onHighlight(GameObject caller);
    GameObject onPickup(GameObject caller);

}
