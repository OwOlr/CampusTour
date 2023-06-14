using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

enum MODE
{
    INFO,
    SELECT
}

public class Photo : MonoBehaviour
{
    MODE mode = MODE.INFO;
    private RawImage image; //이 사진의 이미지
    public RawImage Image { get => image; }

    [SerializeField] Outline outerLine;
    public Outline Outerline { get => outerLine; }

    [SerializeField] private GameObject information;
    [SerializeField] private RawImage infoImage;       

    Button button;

    private void Awake()
    {
        image = GetComponent<RawImage>();
        button = GetComponent<Button>();
    }

    public void Clicked() //Called by Button Component
    {
        switch (mode)
        {
            case MODE.INFO:
                ButtonView();
                break;
            case MODE.SELECT:
                OutlineOnOff();
                break;
            default: break;

        }

    }

    public void OutlineOnOff()
    {
        if(outerLine.enabled)
            outerLine.enabled = false;
        else outerLine.enabled = true;

    }

    public void ButtonEnterAndSelect()
    {
        if (mode == MODE.INFO)
        {
            mode = MODE.SELECT;
        }
        else if(mode == MODE.SELECT)
        {
            mode = MODE.INFO;
        }
    }

    public void ButtonView()
    {
        if (image == null && infoImage == null)
        {
            Debug.LogError("image of infoImage is null");
            return;
        }            

        if(infoImage.texture == null)
        {
            infoImage.texture = image.texture;
        }

        if(!information.activeSelf)
        {
            information.SetActive(true);
        }
        else information.SetActive(false);
    }

    public void SetTexture(Texture2D _image)
    {
        image.texture = _image;
    }

}
