using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] private Album album;
    [SerializeField] private TextMeshProUGUI albumText;

    private void Start()
    {
        AlbumOnOff();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            AlbumOnOff();
        }
    }

    private void AlbumOnOff()
    {
        if (album.gameObject.activeSelf)
        {
            album.gameObject.SetActive(false);
            albumText.gameObject.SetActive(false);
        }            
        else
        {
            album.SystemIOFileLoad();
            album.gameObject.SetActive(true);
            albumText.gameObject.SetActive(true);
        }

    }
}
