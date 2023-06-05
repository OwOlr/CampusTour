using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeSchedule : MonoBehaviour
{
    [SerializeField]
    private Sprite[] semesterSchedules;

    [SerializeField]
    private TMP_Dropdown dropDown;

    [SerializeField]
    private Image img_Schedule;

    private void Start()
    {
        img_Schedule.sprite = semesterSchedules[dropDown.value];
    }

    public void OnChangeSchedule()
    {
        img_Schedule.sprite = semesterSchedules[dropDown.value];
    }

}
