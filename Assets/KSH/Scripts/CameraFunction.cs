using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFunction : MonoBehaviour
{
    Camera selectedCamera;
    public bool CanWarp = false;
    // Start is called before the first frame update
    void Start()
    {
        selectedCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        CheckEnemy(GameObject.FindGameObjectWithTag("Enemy"));
    }
    public bool CheckEnemy(GameObject _Enemy)//카메라 뷰 안에 적이 있는지 없는지
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            Vector3 screenPoint = selectedCamera.WorldToViewportPoint(_Enemy.transform.position);
            bool OnScreen = screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

            if (OnScreen == false)
            {
                CanWarp = true;
            }
            else
            {
                CanWarp = false;
            }
            return CanWarp;
        }
        else
        {
            return CanWarp = true;
        }
    }
}
