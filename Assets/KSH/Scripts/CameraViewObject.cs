using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewObject : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> findList = null;
    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < findList.Count; ++i)
        {
            Vector3 viewPos = cam.WorldToViewportPoint(findList[i].transform.position);

            if(viewPos.x >= 0 && viewPos.x <= 1 
                && viewPos.y >= 0 && viewPos.y <= 1 
                && viewPos.z > 0)
            {
                Debug.Log($" Camera in Object : {findList[i].name}");

                Debug.Log(findList[i].tag);
            }
            else
            {
                Debug.Log("None");
            }
        }
    }
}
