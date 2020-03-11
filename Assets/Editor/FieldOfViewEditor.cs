using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AIScanner))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        AIScanner scan = (AIScanner)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(scan.transform.position, Vector3.forward, Vector3.right, 360, scan.viewRadius);
        Vector3 viewAngleA = scan.DirFromAngle(-scan.viewAngle / 2, false);
        Vector3 viewAngleB = scan.DirFromAngle(scan.viewAngle / 2, false);

        Handles.DrawLine(scan.transform.position, scan.transform.position + viewAngleA * scan.viewRadius);
        Handles.DrawLine(scan.transform.position, scan.transform.position + viewAngleB * scan.viewRadius);


        Handles.color = Color.red;
        foreach(Transform visibleTarget in scan._visibleTargets)
        {
            Handles.DrawLine(scan.transform.position, visibleTarget.position);
        }

    }
}
