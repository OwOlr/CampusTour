using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    [SerializeField]
    private Image testImg;
    [SerializeField]
    private bool isVisible;
    [SerializeField]
    private void Awake()
    {
        testImg.gameObject.SetActive(false);
        isVisible = false;
    }

    public void ImgCatOnOff()
    {
        if (isVisible != true)
        {
            testImg.gameObject.SetActive(true);
            isVisible = true;
        }
        else
        {
            testImg.gameObject.SetActive(false);
            isVisible = false;
        }
    }

}
