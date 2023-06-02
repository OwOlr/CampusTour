using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Post : MonoBehaviour
{
    [SerializeField]
    public string title;
    [SerializeField]
    public string time;
    [SerializeField]
    public bool isNew;
    
    [SerializeField]
    private TextMeshProUGUI tmpTitle;
    [SerializeField]
    private TextMeshProUGUI tmpTime;
    [SerializeField]
    private TextMeshProUGUI tmpNew;
    private void Start()
    {

        tmpTitle = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tmpTime = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        tmpNew = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmpTitle.text = title;
        tmpTime.text = time;
        if (isNew)
        {
            tmpNew.gameObject.SetActive(true);
        }
        else
        {
            tmpNew.gameObject.SetActive(false);
        }
    }
}
