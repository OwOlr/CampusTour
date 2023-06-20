using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotalPos : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "XR Origin")
        {

            SceneManager.LoadScene("Cafeteria");
        }
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Collider")
        {

            SceneManager.LoadScene("Cafeteria");
        }
    }
}
