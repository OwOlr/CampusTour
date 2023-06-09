using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ContentsManager : MonoBehaviour
{
    [System.Serializable]
    public class Poster
    {
        public Sprite posterImg;
        public string url;
        public string category;

    }
    [SerializeField]
    public Poster[] poster;

    [SerializeField]
    GameObject prePabPoster;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poster.Length; i++)
        {
            GameObject instanceGO = GameObject.Instantiate(prePabPoster);
            instanceGO.transform.SetParent(this.transform,false);
            instanceGO.GetComponent<Image>().sprite = poster[i].posterImg;
            instanceGO.GetComponent<OpenURL>().posterUrl = poster[i].url;

        }
    }


}
