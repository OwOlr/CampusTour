using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderBox : MonoBehaviour
{
    [SerializeField]
    private OrderList orderList;

    [SerializeField]
    private TextMeshProUGUI[] texts;



    public void AddOrderProduct(string _name, int _price, int _stock)
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = _name;
        texts[1].text = _price.ToString();
        texts[2].text = _stock.ToString();
    }

}
