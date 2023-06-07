using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderList : MonoBehaviour
{

    [SerializeField]
    private GameObject orderListPrefab;

    public void Start()
    {
        //Product.OnClickPdBtnDelegate = SelectProduct;
    }
    public void SelectProduct(string _name, int _price)
    {
        GameObject orderGo = Instantiate(orderListPrefab, this.transform);
        TextMeshProUGUI[] texts = orderGo.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = _name;
        texts[1].text = _price.ToString();
    }
}
