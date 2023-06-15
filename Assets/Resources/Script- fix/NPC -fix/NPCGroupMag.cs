using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGroupMag : MonoBehaviour {
    [SerializeField] private WPGroupMag wpMng = null;

    private NPCMovement[] npcs = null;

    private void Awake() { npcs = GetComponentsInChildren<NPCMovement>(); }

    private void Start()
    {
        for (int i = 0; i < npcs.Length; ++i)
            npcs[i].SetWPParent(wpMng.GetWPParent(i));
    }
}
