using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class OrderList : MonoBehaviour
{
    //��ǰ ������ �޾ƿ� Ŭ���� ����
    [System.Serializable]
    public class OrderInfos
    {
        public string productName;
        public int orderPrice;
        public int orderStock;
    }

    //�ֹ������ ������
    [SerializeField]
    private GameObject orderListPrefab;
    
    //�ֹ� ��Ͽ� �� ��ǰ ���� ����Ʈ
    [SerializeField]
    public List<OrderInfos> orderInfoList;

    [SerializeField]
    private RectTransform orderContens;
    


    private void Start()
    {
        orderInfoList = new List<OrderInfos>();   
    }

   //�ֹ� ��Ͽ� �� ��ǰ ��� ���� �޾ƿ��� 
    public void GetProductInfo(string _name, int _price)
    {
        OrderInfos orderInfo = new OrderInfos();

        foreach ( OrderInfos list in orderInfoList )
        {
            if(list.productName == _name)
            {
                return;
            }
        }
        orderInfo.productName = _name;
        orderInfo.orderPrice = _price;
        orderInfo.orderStock++;
        orderInfoList.Add(orderInfo);
        

    }



    //�ֹ� ��� ������ ����
    public void SetOrderBtn()
    {
        DestroyOrderList();
        for (int i = 0; i < orderInfoList.Count; i++)
        {
            GameObject orderGo = Instantiate(orderListPrefab, this.transform);
            OrderBox orderbox = orderGo.GetComponent<OrderBox>();
            orderbox.OrderBoxInit(orderContens);
        
            orderbox.AddOrderProduct(orderInfoList[i].productName, 
                orderInfoList[i].orderPrice, orderInfoList[i].orderStock);

        }
    }

    //�ֹ���� ������Ʈ�� ���� ��� �ڽ�(������) ����
    private void DestroyOrderList()
    {
        OrderBox[] destroyOrder = null;
        destroyOrder = GetComponentsInChildren<OrderBox>();

        foreach (OrderBox deleteItem in destroyOrder)
        {
            Destroy(deleteItem.gameObject);
        }
    }
}
