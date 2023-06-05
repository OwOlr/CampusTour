using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] GameObject album;

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
        if (album.activeSelf)
            album.SetActive(false);
        else album.SetActive(true);
    }
}
