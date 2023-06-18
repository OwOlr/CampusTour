using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompletedTimer : MonoBehaviour
{
    [SerializeField]
    private GameObject homePanel;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private float limitTimer = 10;


    private bool isEnable;
    private float time;

    private void Update()
    {
        if (isEnable)
        {
            if (time > limitTimer)
            {
                homePanel.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                return;
            }
            time += Time.deltaTime; 
            timerText.text = ((int)time % 60).ToString();
        }
    }
    private void OnEnable()
    {
        isEnable = true;
    }
    private void OnDisable()
    {
        isEnable = false;
        time = 0;
    }
}
