using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyItem : MonoBehaviour
{
    public playerScript player;

    public Button[] buttons;

    public Button[] buyButtons;
    

    public int roofPrice1 = 0;
    public int roofPrice2 = 0;

    public int enginePrice1 = 0;
    public int enginePrice2 = 0;

    public int hullPrice1 = 0;
    public int hullPrice2 = 0;

    public int boosterPrice1 = 0;
    public int boosterPrice2 = 0;

    List<int> priceList;

    void Start()
    {
        priceList = new List<int> {roofPrice1, roofPrice2, enginePrice1, enginePrice2, hullPrice1, hullPrice2, boosterPrice1, boosterPrice2 };
    }

    int price;


    [SerializeField]
    public void buyPart(int index)
    {
        price = priceList[index];
        if (player.getMoney() - price > 0)
        {
            buttons[index].interactable = true;
            buyButtons[index].interactable = false;
            player.addMoney(-price);
        }
    }
}
