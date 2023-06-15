using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private GameObject information2;
    //[SerializeField] private GameObject information3;

    private string fileName;
    private SaveData tagInfo;
    [SerializeField] private TextMeshProUGUI tagText; //이후 string 리스트를 만들고 여기에 하나로 만들어 붙여 보이게하기

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

        infoImage.texture = image.texture;

        Infomation();
    }

    public void SetTexture(Texture2D _image)
    {
        image.texture = _image;
    }

    public void SetFileName(string _fileName)
    {
        fileName = _fileName;
    }

    public void Infomation()
    {
        if (!information.activeSelf)
        {
            information.SetActive(true);
            information2.SetActive(false);
        }
        else information.SetActive(false);
    }

    public void Information2()
    {
        if (!information2.activeSelf)
        {
            information2.SetActive(true);
        }
        else information2.SetActive(false);
    }

    public void InfoLoad()
    {
        Debug.Log(fileName);

        tagInfo = DataManager.Load(fileName);        

        if (tagInfo == null) 
        {
            return;
        }
        else
        {
            tagText.text = null;

            foreach (string data in tagInfo.objInfo)
            {
                tagText.text += data + " ";

                Debug.Log(tagText.text);
            }
        }
    }

}
