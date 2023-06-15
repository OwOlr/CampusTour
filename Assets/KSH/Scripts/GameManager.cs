using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    ScreenShot screenShot;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(instance);
        }

        screenShot = GetComponent<ScreenShot>();

    }
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.L))
        {
            SaveData loadThings = DataManager.Load("Test");
            Debug.Log("Loadinging " + loadThings);

            if (loadThings != null) 
            {
                
            }

                        
        }
    }

}
