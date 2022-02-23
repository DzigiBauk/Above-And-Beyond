using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setMoneyLabel : MonoBehaviour
{
    [SerializeField]
    public playerScript player;
    public Text moneyLabel;

    void Update()
    {
        moneyLabel.text = "MONEY: " + player.getMoney();
    }
}
