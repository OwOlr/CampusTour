using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBar: MonoBehaviour
{
    [SerializeField]
    private GameObject[] views;
    [SerializeField]
    private Image[] Icon;
    [SerializeField]
    private Sprite[] onIcon;
    [SerializeField]
    private Sprite[] offIcon;

    private void Start()
    {
        for (int i = 0; i < views.Length; i++)
        {
            views[i].SetActive(false);
            Icon[i].sprite = offIcon[i];
        }
        views[0].SetActive(true);
        Icon[0].sprite = onIcon[0];
    }

    public void HomeView()
   {
        for (int i = 0; i < views.Length; i++)
        {
            views[i].SetActive(false);
            Icon[i].sprite = offIcon[i];
        }
        views[0].SetActive(true);
        Icon[0].sprite = onIcon[0];


   }

   public void ScheduleView()
   {
        for (int i = 0; i < views.Length; i++)
        {
            views[i].SetActive(false);
            Icon[i].sprite = offIcon[i];
        }
        views[1].SetActive(true);
        Icon[1].sprite = onIcon[1];


    }

   public void ToDoListView()
   {

   }
   public void AlarmView()
   {

   }
}
