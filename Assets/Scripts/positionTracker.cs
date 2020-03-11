using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionTracker : MonoBehaviour
{

    public Transform objToFollow;

    private void LateUpdate()
    {
        transform.position = objToFollow.position;
    }

}
