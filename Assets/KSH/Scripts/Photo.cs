using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    [SerializeField] Outline outerLine;
    public Outline Outerline { get => outerLine; }

    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Clicked() //Called by Button Component
    {
        OutlineOnOff();
    }

    public void OutlineOnOff()
    {
        if(outerLine.enabled)
            outerLine.enabled = false;
        else outerLine.enabled = true;

    }

    public void ButtonEnable()
    {
        if (button.interactable)
            button.interactable = false;
        else button.interactable = true;
    }

}
