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

    [SerializeField]
    private RectTransform orderContents;


    public void OrderBoxInit(RectTransform _orderContens)
    {
        orderContents = _orderContens;
        orderList = orderContents.GetComponent<OrderList>();


    }

    public void AddOrderProduct(string _name, int _price, int _stock)
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = _name;
        texts[1].text = _price.ToString();
        texts[2].text = _stock.ToString();
        orderList.accountManager.GetTotal();
    }

    public void OnClickPlusBtn()
    {
        foreach (OrderList.OrderInfos list in orderList.orderInfoList)
        {
            if (list.productName == texts[0].text)
            {
                list.orderStock++;
                texts[2].text = list.orderStock.ToString();
                orderList.accountManager.GetTotal();
                return;
            }
        }
    }

    public void OnClickMinusBtn()
    {
        foreach (OrderList.OrderInfos list in orderList.orderInfoList)
        {
            if (list.productName == texts[0].text && list.orderStock >  0)
            {
                list.orderStock--;
                texts[2].text = list.orderStock.ToString();
                orderList.accountManager.GetTotal();
                return;
            }
        }
    }

}
