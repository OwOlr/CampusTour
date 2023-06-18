using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountData : MonoBehaviour
{
    [SerializeField]
    private int playerMoney = 100000;
    public int PlayerMoney
    {
        get { return playerMoney; }
        set { playerMoney = value; }
    }

    
}
