using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;
using UnityEngine.InputSystem;

public class ScreenShot : MonoBehaviour
{
    [SerializeField] private InputActionReference screenShot;
    [SerializeField] private Camera camera;       //보여지는 카메라.
    private string fileName;
    private int resWidth;
    private int resHeight;

    private string path;
    public string Path { get { return path; } }

    //[SerializeField] RenderTexture myRt;

    [SerializeField] private TextMeshProUGUI tmpText;

    [SerializeField] RawImage rawImage;

    Renderer renderer = null;

    private int mag;

    //private int numOfpng;
    //public int NumOfpng { get => NumOfpng; }

    private void Start()
    {
        Debug.Log("Press \"SPACE\" to Capture Screen");

        resWidth = Screen.width;
        resHeight = Screen.height;
        path = Application.persistentDataPath + "/ScreenShots/";


        tmpText.text = " ";
        tmpText.gameObject.SetActive(false);

        mag = 50;
    }

    private void Update()
    {
        //InputCaptureKey();
        screenShot.action.performed += MakeScreenShot;

        ZoomInOut();
    }

    private void InputCaptureKey()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{ 
        //    MakeScreenShot; // ObjectFindInCamera() is in;           
        //}

    }

    private void MakeScreenShot(InputAction.CallbackContext obj)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);            
        }

        Debug.Log("File count : " + dir.GetFiles().Length);

        if (dir.GetFiles().Length >= 64)
        {            
            return;
        }

        string strNow = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

        fileName = path + strNow + ".png";
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        camera.targetTexture = rt;
        rawImage.texture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();

        byte[] bytes = screenShot.EncodeToPNG();
        File.WriteAllBytes(fileName, bytes);

        tmpText.text = fileName;
        tmpText.gameObject.SetActive(true);
        Invoke("TextOff", 2f);


        ObjectFindInCamera(strNow);
    }

    private void ObjectFindInCamera(string strNow) //in MakeScreenShot();
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        List<string> ObjInfo = new List<string>();

        foreach (GameObject obj in allObjects)
        {
            renderer = obj.GetComponent<Renderer>();

            if (renderer != null && renderer.enabled && IsObjectVisibleFromCamera(renderer, camera) && !obj.CompareTag("Untagged"))
            {
                Debug.Log("Visible Object: " + obj.tag);

                ObjInfo.Add(obj.tag);                
            }
        }

        SaveData ScreenShotInfo = new SaveData(ObjInfo);
        DataManager.Save(ScreenShotInfo, strNow);
                
    }

    private bool IsObjectVisibleFromCamera(Renderer renderer, Camera camera)
    {
        Plane[] frustumPlanes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(frustumPlanes, renderer.bounds);
    }

    private void TextOff()
    {
        tmpText.gameObject.SetActive(false);
    }

    private void ZoomInOut()
    {
        if (Input.GetKey(KeyCode.RightBracket))
        {
            camera.fieldOfView -= Time.deltaTime * mag;

            if(camera.fieldOfView < 10)
                camera.fieldOfView = 10;            
        }
        else if(Input.GetKey(KeyCode.LeftBracket))
        {
            camera.fieldOfView += Time.deltaTime * mag;

            if (camera.fieldOfView > 60)
                camera.fieldOfView = 60;
        }

        
    }

    


}

//카메라를 받지않고 게임화면 저장하는 내용
//timestamp = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");          
//path = Application.persistentDataPath + "/ScreenShots/";
//fileName = path + timestamp + ".png";
//System.IO.Directory.CreateDirectory(path);
//ScreenCapture.CaptureScreenshot(fileName);
//Debug.Log(fileName);

//bool CheckObjectInCamera(GameObject _target)
//{
//    Vector3 ScreenPoint = camera.WorldToViewportPoint(_target.transform.position);

//    bool onScreen = ScreenPoint.z > 0 && ScreenPoint.x > 0 && ScreenPoint.x < 1 && ScreenPoint.y > 0 && ScreenPoint.y < 1;
//    return onScreen;
//}