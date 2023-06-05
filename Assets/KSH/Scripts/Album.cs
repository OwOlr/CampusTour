using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Album : MonoBehaviour
{
    [SerializeField] RawImage[] photos; 

    private ScreenShot screenShot;

    private Sprite sprite;

    private string directoryPath;
    private string[] pngFiles;

    private byte[] byteTextures;
    private Texture2D texture;

    private void Awake()
    {
        photos = GetComponentsInChildren<RawImage>();
        
    }

    private void Start()
    {
        directoryPath = Application.persistentDataPath + "/ScreenShots/";        

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

        for(int i = 0; i < photos.Length; i++) 
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

    private void Update()
    {
        if(pngFiles.Length != 0 && Input.GetKeyUp(KeyCode.Delete))
        {
            for(int i = 0; i < photos.Length; i++)
            {
                //if (photos[i].Isout)
                File.Delete(pngFiles[0]);
            }
             
            SystemIOFileLoad();
        }
    }
}
