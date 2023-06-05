using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostManager : MonoBehaviour
{

    //class와 struct 사용할 때 Serializable 사용
    [System.Serializable]
    public class PostData
    {
        public string title;
        public string time;
        public bool isnew;
    }

    //배열생성
    [SerializeField]
    public PostData[] posts;
    //프리팹Post 받아오기
    [SerializeField]
    GameObject prePabPosts;

    // Update is called once per frame
    void Start()
    {
        for (int i = 0; i < posts.Length; i++)
        {
            GameObject instancePosts = GameObject.Instantiate(prePabPosts);
            instancePosts.transform.SetParent(this.transform, false);
            instancePosts.GetComponent<Post>().title = posts[i].title;
            instancePosts.GetComponent<Post>().time = posts[i].time;
            instancePosts.GetComponent<Post>().isNew = posts[i].isnew;

        }
    }
}
