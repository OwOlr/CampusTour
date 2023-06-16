using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPGroupMag : MonoBehaviour {
    //[SerializeField] private Transform[] PGroupTr;
    private WPParent[] par;

    private void Awake() { par = GetComponentsInChildren<WPParent>(); }

    public WPParent GetWPParent(int _idx) { return par[_idx]; }
}
