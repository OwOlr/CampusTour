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

    [SerializeField]
    private string[] str_btnTxts;
   
    private string hexOncolor = "#000000";
    private string hexOffcolor = "#AACE37";





    private void Start()
    {
        menuBtns = this.GetComponentsInChildren<Button>();
        btnTxt = new TextMeshProUGUI[menuBtns.Length];
        str_btnTxts = new string[menuBtns.Length];


        for (int i = 0; i < menuBtns.Length; i++)
        {
            btnTxt[i] = menuBtns[i].GetComponentInChildren<TextMeshProUGUI>();
            str_btnTxts[i] = btnTxt[i].text;
        }

        btnTxt[0].text = "<color="+ hexOncolor + ">" + str_btnTxts[0] + "</color>";
        menuBtns[0].image.color = new Color32(255, 255, 255, 255);

    }



    public void OnCameraMenu()
    {
        for (int i = 0; i < menuBtns.Length; i++)
        {
            btnTxt[i].text = "<color=" + hexOffcolor + ">" + str_btnTxts[i] + "</color>";
            menuBtns[i].image.color = new Color32(101, 46, 141, 255);
        }

        btnTxt[0].text = "<color=" + hexOncolor + ">" + str_btnTxts[0] + "</color>";
        menuBtns[0].image.color = new Color32(255, 255, 255, 255);


    }
    public void OnStoreProductMenu()
    {
        for (int i = 0; i < menuBtns.Length; i++)
        {
            btnTxt[i].text = "<color=" + hexOffcolor + ">" + str_btnTxts[i] + "</color>";
            menuBtns[i].image.color = new Color32(101, 46, 141, 255);
        }
        btnTxt[1].text = "<color=" + hexOncolor + ">" + str_btnTxts[1] + "</color>";
        menuBtns[1].image.color = new Color32(255, 255, 255, 255);
    }



}
