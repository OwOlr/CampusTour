using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class OrderList : MonoBehaviour
{
    //상품 정보를 받아올 클래스 생성
    [System.Serializable]
    public class OrderInfos
    {
        public string productName;
        public int orderPrice;
        public int orderStock;
    }

    //주문목록의 프리팹
    [SerializeField]
    private GameObject orderListPrefab;
    
    //주문 목록에 들어간 상품 정보 리스트
    [SerializeField]
    public List<OrderInfos> orderInfoList;

    [SerializeField]
    private RectTransform orderContens;
    


    private void Start()
    {
        orderInfoList = new List<OrderInfos>();   
    }

   //주문 목록에 들어갈 상품 목록 정보 받아오기 
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



    //주문 목록 프리팹 생성
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

    //주문목록 업데이트를 위한 모든 자식(프리팹) 삭제
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
