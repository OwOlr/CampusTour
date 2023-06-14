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

        Debug.Log(textureInfo.Length);

        for (int i = 0; i < textureInfo.Length; i++)
        {
            //textureInfo[i].Image.texture = null;
            textureInfo[i].SetTexture(null);

            if (pngFiles.Length > i)
            {
                byteTextures = File.ReadAllBytes(pngFiles[i]);
                texture = new Texture2D(2, 2);
                texture.LoadImage(byteTextures);
                //textureInfo[i].Image.texture = texture;
                textureInfo[i].SetTexture(texture);
            }

            if (textureInfo[i].Image.texture == null)
            {
                textureInfo[i].Image.gameObject.SetActive(false);
            }
            else
            {
                textureInfo[i].Image.gameObject.SetActive(true);
            }
        }


        //for (int i = 0; i < photos.Length; i++) 
        //{
        //    photos[i].texture = null;

        //    if (pngFiles.Length > i)
        //    {
        //        byteTextures = File.ReadAllBytes(pngFiles[i]);
        //        texture = new Texture2D(2, 2);
        //        texture.LoadImage(byteTextures);
        //        photos[i].texture = texture;
        //    }
                        
        //    if (photos[i].texture == null)
        //    {
        //        photos[i].gameObject.SetActive(false);
        //    }
        //    else
        //    {
        //        photos[i].gameObject.SetActive(true);
        //    }
        //}

    }

    public void DeletePhotoes() //Call by Delete Button
    {
        bool delComplete = false;

        if (pngFiles.Length != 0)
        {
            //for (int i = 0; i < photos.Length; i++)
            for (int i = 0; i < textureInfo.Length; i++)
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

    public void PhotoEnterControl()
    {
        for(int i = 0; i < textureInfo.Length; i++)
        {
            textureInfo[i].ButtonEnterAndSelect();
        }
    }
}
