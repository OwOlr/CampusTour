using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreMenuButton : MonoBehaviour
{
    [SerializeField]
    private Button[] menuBtns;
    [SerializeField]
    private Color onColor;
    [SerializeField]
    private TextMeshProUGUI[] btnTxt;



    private void Start()
    {
        menuBtns = this.GetComponentsInChildren<Button>();
        btnTxt = new TextMeshProUGUI[menuBtns.Length];

        for (int i = 0; i < menuBtns.Length; i++)
        {

            btnTxt[i] = menuBtns[i].GetComponentInChildren<TextMeshProUGUI>();

        }

        btnTxt[0].text = "<color=#AACE37>카메라</color>";

    }



    public void OnCameraMenu()
    {
        for (int i = 0; i < menuBtns.Length; i++)
        {
            btnTxt[i].color = new Color(170, 206, 55);

        }
        btnTxt[0].text = "<color=#AACE37>카메라</color>";

    }
    public void OnStoreProductMenu()
    {
        for (int i = 0; i < menuBtns.Length; i++)
        {
            btnTxt[i].color = new Color(170, 206, 55);

        }
        btnTxt[1].color = new Color(0, 0, 0);

    }



}
