using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class InterfaceManager : MonoBehaviour
{

    //[SerializeField] private GameObject albumObj;

    [SerializeField]
    private InputActionReference albumInteraction;
    [SerializeField]
    private InputActionReference cameraInteraction;

    private Album album;
    private TextMeshProUGUI albumText;

    //[SerializeField] private TextMeshProUGUI pathText;

    [SerializeField] private GameObject camInterface;

    private void Awake()
    {
        album = GetComponentInChildren<Album>();

        albumText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        //AlbumOnOff();
    }

    private void Update()
    {
        //if(Input.GetKeyUp(KeyCode.P))
        //{
        //    AlbumOnOff();
        //}

        albumInteraction.action.performed += AlbumOnOff;
        cameraInteraction.action.performed += OpenCamera;

        //if (Input.GetKeyUp(KeyCode.O))
        //{
        //    OpenCamera();
        //}
    }

    private void AlbumOnOff(InputAction.CallbackContext obj)
    {
        if (album.gameObject.activeSelf) //for Off
        {            
            album.gameObject.SetActive(false);
            albumText.gameObject.SetActive(false);
        }            
        else //for On
        {
            album.SystemIOFileLoad();
            album.gameObject.SetActive(true);
            albumText.gameObject.SetActive(true);
        }

    }

    private void OpenCamera(InputAction.CallbackContext obj)
    {
        if (!camInterface.activeSelf) //for on
        {
            camInterface.SetActive(true);
        }
        else //for off
        {
            camInterface.SetActive(false);
        }
    }
}
