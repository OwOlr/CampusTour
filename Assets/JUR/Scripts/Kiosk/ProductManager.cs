using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProductManager : MonoBehaviour
{
    [System.Serializable]
    public struct ProductInfo
    {
        public Sprite productImg;
        public string productName;
        public int price;
        public int stock;
    }

    [SerializeField]
    public List<ProductInfo> productList;

    [SerializeField]
    private GameObject productBtnPrefab;

    [SerializeField]
    private RectTransform contents;

    private void Awake()
    {
        InitProduct();
    }

    private void InitProduct()
    {
        for (int i = 0; i < productList.Count; i++)
        {
            GameObject productBtn = Instantiate(productBtnPrefab,transform);
            Product product = productBtn.GetComponent<Product>();
            product.Init(contents);

            Product btn = productBtn.GetComponent<Product>();
            btn.InitInfo(productList[i].productImg, productList[i].productName, 
                productList[i].price, productList[i].stock);
        }
    }



    
}
