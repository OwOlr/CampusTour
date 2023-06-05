using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScreenShot : MonoBehaviour
{

    [SerializeField] private Camera camera;       //보여지는 카메라.
    private string fileName;
    private int resWidth;
    private int resHeight;

    private string path;
    public string Path { get { return path; } }

    [SerializeField] RenderTexture myRt;

    [SerializeField] private TextMeshProUGUI tmpText;
    //public TextMeshProUGUI TmpText { get { return tmpText; } }

    [SerializeField] RawImage rawImage;

    [SerializeField] GameObject go;

    Renderer renderer = null;

    private int mag;

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
        InputCaptureKey();

        ZoomInOut();
    }

    private void InputCaptureKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            MakeScreenShot();
            ObjectFindInCamera();
        }

        if(Input.GetKeyUp(KeyCode.C)) 
        {
            ObjectFindInCamera();
        }

    }

    private void MakeScreenShot()
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);
        }
        fileName = path + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
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

    }

    private void ObjectFindInCamera()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            renderer = obj.GetComponent<Renderer>();

            if (renderer != null && renderer.enabled && IsObjectVisibleFromCamera(renderer, camera))
            {
                Debug.Log("Visible Object: " + obj.name);
            }
        }
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