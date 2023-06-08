using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Album : MonoBehaviour
{   
    [SerializeField] private GameObject PhotoArray; //Dragged GameObject 

    [SerializeField] private RawImage[] photos;
    [SerializeField] private Photo[] textureInfo;

    private ScreenShot screenShot;

    private Sprite sprite;

    private string directoryPath;
    private string[] pngFiles;

    private byte[] byteTextures;
    private Texture2D texture;

    private void Awake()
    {

        photos = PhotoArray.GetComponentsInChildren<RawImage>();
        textureInfo = PhotoArray.GetComponentsInChildren<Photo>();

        directoryPath = Application.persistentDataPath + "/ScreenShots/";

    }

    private void Start()
    {
            

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Debug.Log("Folder created: " + directoryPath);
        }

        SystemIOFileLoad();
    }

    public void SystemIOFileLoad()
    {  
        Debug.Log("Album Loaded");        

        pngFiles = Directory.GetFiles(directoryPath, "*.png");

        Debug.Log(pngFiles.Length);
        Debug.Log(photos.Length);

        for (int i = 0; i < photos.Length; i++) 
        {
            photos[i].texture = null;

            if (pngFiles.Length > i)
            {
                byteTextures = File.ReadAllBytes(pngFiles[i]);
                texture = new Texture2D(2, 2);
                texture.LoadImage(byteTextures);
                photos[i].texture = texture;
            }
                        
            if (photos[i].texture == null)
            {
                photos[i].gameObject.SetActive(false);
            }
            else
            {
                photos[i].gameObject.SetActive(true);
            }
        }

        //for (int i = 0; i < pngFiles.Length; i++) 
        //{
        //    byteTextures = File.ReadAllBytes(pngFiles[i]);
        //    texture = new Texture2D(2, 2);
        //    texture.LoadImage(byteTextures);
        //    photos[i].texture = texture;

        //}

        //Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

        //photos[0].SetNativeSize(); //Covered All Screen
    }

    public void DeletePhotoes() //Call by Delete Button
    {
        bool delComplete = false;

        if (pngFiles.Length != 0)
        {
            for (int i = 0; i < photos.Length; i++)
            {
                if (textureInfo[i].Outerline.enabled && i < textureInfo.Length)
                {
                    File.Delete(pngFiles[i]);

                    delComplete = true;
                }
            }

            for (int i = 0; i < textureInfo.Length; i++)
            {
                if (textureInfo[i].Outerline.enabled)
                    textureInfo[i].OutlineOnOff();
            }

            if (delComplete)
                SystemIOFileLoad();
        }
    }

    public void CloseAlbum()
    {
        gameObject.SetActive(false);
    }

    public void PhotoEnableControl()
    {
        for(int i = 0; i < textureInfo.Length; i++)
        {
            textureInfo[i].ButtonEnable();
        }
    }
}
