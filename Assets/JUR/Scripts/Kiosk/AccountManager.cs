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
        totalText.text = "�� �ݾ� : " + total.ToString();
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
        //�ܾ׺��� ����
        if (total > accountData.PlayerMoney)
        {
            noBalance.text = "�ܾ��� �����մϴ�.";
            return;
        }
        //�÷��̾� ��꿡�� �� ��ǰ�ݾ��� ����.
        accountData.PlayerMoney -= total;
        ResetOrderList();

        float offset = 0;
        //������ ����
        for (int i = 0; i < stock; i++)
        {
            CreateItem(offset);
            offset += 0.1f;
        }

        //���θ޴� â ����, �����Ϸ� â Ų��.
        completedPanel.SetActive(true);
        mainMenuPanel.SetActive(false);


    }

    public void ReturnHome()
    {
        ResetOrderList();
        homePanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    //�ֹ� ��� ����
    private void ResetOrderList()
    { 
        //�� ��ǰ�ݾ�, ��ٱ��� ����Ʈ ���� �ʱ�ȭ.
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
