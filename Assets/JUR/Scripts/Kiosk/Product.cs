using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    [SerializeField]
    private Button productBtns;
    [SerializeField]
    private Image productImg;
    [SerializeField]
    private TextMeshProUGUI[] productTxts;

    [SerializeField]
    private RectTransform contents;
    [SerializeField]
    private GameObject orderBoxPrefab;

    public void Init(RectTransform _contents)
    {
        productBtns = GetComponent<Button>();
        productImg = GetComponentInChildren<Image>();
        productTxts = GetComponentsInChildren<TextMeshProUGUI>();
        contents = _contents;
        orderBoxPrefab = Resources.Load<GameObject>("Prefabs/OrderBox");
    }

    public void InitInfo(Sprite _img, string _name, int _price, int _stock)
    {
        productImg.sprite = _img;
        productTxts[0].text = _name;
        productTxts[1].text = _price.ToString();
        productTxts[2].text = _stock.ToString() + "°³";
    }

    public void OnClickProduct()
    {
        OrderList orderList = contents.GetComponent<OrderList>();
        //orderList.SendProductBtnInfo(productTxts[0].text, int.Parse(productTxts[1].text));
        orderList.GetProductInfo(productTxts[0].text, int.Parse(productTxts[1].text));
    }   

}
