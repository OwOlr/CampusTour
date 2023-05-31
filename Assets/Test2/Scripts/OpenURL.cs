using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OpenURL : MonoBehaviour
    , IPointerClickHandler
{


    [SerializeField]
    public string posterUrl;

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(posterUrl);
    }

   

    public void GoogleURL()
    {
        Application.OpenURL(posterUrl);
    }
}
