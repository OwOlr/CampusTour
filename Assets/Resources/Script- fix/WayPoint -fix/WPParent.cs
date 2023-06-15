using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPParent : MonoBehaviour {
    [SerializeField] private Transform[] GetWp = null;

    private void Awake() { GetWp = GetComponentsInChildren<Transform>();
        Debug.Log("GetW[: " + GetWp.Length);
    }

    public Transform GetWaypointTr(int _idx) { return GetWp[1 + (_idx % (GetWp.Length-1))]; }
}
