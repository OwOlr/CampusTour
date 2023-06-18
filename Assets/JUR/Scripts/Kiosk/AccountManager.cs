using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccountManager : MonoBehaviour
{
    [SerializeField]
    private GameObject homePanel;
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject completedPanel;

    [SerializeField]
    private OrderList orderList;

    [SerializeField]
    private TextMeshProUGUI totalText;
    [SerializeField]
    private TextMeshProUGUI noBalance;

    [SerializeField]
    private AccountData accountData;

    [SerializeField]
    private Transform kioskPos;
    [SerializeField]
    private GameObject itemPrepab;
    
    private int total;
    public int stock;

    private void Start()
    {
        accountData = GameObject.Find("GameManager").GetComponent<AccountData>();
        noBalance.text = "";
    }

    void Update()
    {
        totalText.text = "총 금액 : " + total.ToString();
    }

    public void GetTotal()
    {
        total = 0;
        stock = 0;
        foreach (OrderList.OrderInfos products in  orderList.orderInfoList)
        {
            total += products.orderPrice * products.orderStock;
            stock += products.orderStock;
        }
    }

    public void BuyProduct()
    {
        //잔액부족 조건
        if (total > accountData.PlayerMoney)
        {
            noBalance.text = "잔액이 부족합니다.";
            return;
        }
        //플레이어 재산에서 총 제품금액을 차감.
        accountData.PlayerMoney -= total;
        ResetOrderList();

        float offset = 0;
        //아이템 생성
        for (int i = 0; i < stock; i++)
        {
            CreateItem(offset);
            offset += 0.1f;
        }

        //메인메뉴 창 끄고, 결제완료 창 킨다.
        completedPanel.SetActive(true);
        mainMenuPanel.SetActive(false);


    }

    public void ReturnHome()
    {
        ResetOrderList();
        homePanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    //주문 목록 리셋
    private void ResetOrderList()
    { 
        //총 제품금액, 장바구니 리스트 내용 초기화.
        total = 0;
        noBalance.text = "";
        orderList.orderInfoList.Clear();
        orderList.DestroyOrderList(); 
    }

    private void CreateItem(float _offset)
    {
        GameObject createItem = Instantiate(itemPrepab);
        createItem.transform.position = new Vector3(kioskPos.position.x - 0.8f,
            kioskPos.position.y + _offset, kioskPos.position.z);
    }
}
