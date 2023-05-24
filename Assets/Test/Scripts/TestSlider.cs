using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSlider : MonoBehaviour
{

    [SerializeField]
    private Image testImg;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Color color;

    private void Awake()
    {
        color = Color.white;

    }

    public void ChangeAlpha()
    {
        color.a = 1f-slider.value;
        testImg.color = color;
    }


}
