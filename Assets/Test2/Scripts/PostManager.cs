using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostManager : MonoBehaviour
{

    //class�� struct ����� �� Serializable ���
    [System.Serializable]
    public class PostData
    {
        public string title;
        public string time;
        public bool isnew;
    }

    //�迭����
    [SerializeField]
    public PostData[] posts;
    //������Post �޾ƿ���
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
