using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmo : MonoBehaviour {
    [SerializeField, Range(0.1f, 2f)] private float wpSize = 1f; 
    private void OnDrawGizmos() { 
        foreach (Transform tr in transform) {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(tr.position, wpSize);
        }
        Gizmos.color = Color.blue;
        for(int i = 0; i < transform.childCount -1; ++i) {
            Gizmos.DrawLine(transform.GetChild(i).position,
                transform.GetChild(i + 1).position);
        }
        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1)
            .position, transform.GetChild(0).position);
    }

    public Transform GetNextWaypoint(Transform currentWaypoint) {
        return null;
    }
}
