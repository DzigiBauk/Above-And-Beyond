using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public static int money = 100000;

    public static Dictionary<string, int> rocket = new Dictionary<string, int>();

    public List<int> roofStats = new List<int>();
    public List<int> hullStats = new List<int>();
    public List<int> engineStats = new List<int>();


    public int rocketAcceleration = 0;
    public int rocketMaxFuel = 0;
    public int maxThrust = 0; 

    public SpriteRenderer rocketRoof;
    public SpriteRenderer rocketHull;
    public SpriteRenderer rocketBoosters;
    public SpriteRenderer rocketEngine;

    public Sprite[] roofSprite;
    public Sprite[] hullSprite;
    public Sprite[] engineSprite;
    public Sprite[] boosterSprite;



    void Start()
    {
        roofStats.Add(2);
        roofStats.Add(5);
        roofStats.Add(10);

        hullStats.Add(20);
        hullStats.Add(50);
        hullStats.Add(100);

        engineStats.Add(5);
        engineStats.Add(8);
        engineStats.Add(12);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSprite()
    {
        if (rocket.ContainsKey("roof"))
        {
            rocketRoof.sprite = roofSprite[rocket["roof"]];
        }

        if (rocket.ContainsKey("hull"))
        {
            rocketHull.sprite = hullSprite[rocket["hull"]];
        }

        if (rocket.ContainsKey("engine"))
        {
            rocketEngine.sprite = engineSprite[rocket["engine"]];
        }

        if (rocket.ContainsKey("booster"))
        {
            rocketBoosters.sprite = boosterSprite[rocket["booster"]];
        }
    }

    public Dictionary<string, int> getRocket()
    {
        return rocket;
    }

    public int getMoney()
    {
        return money;
    }

    public void buyPart(Button btn, int price)
    {
        if (money - price > 0)
        {
            btn.interactable = true;
            money = money - price;
        }
    }
    public void addMoney(int amount)
    {
        money += amount;
    }

    public void addRoof(int index)
    {
        rocket["roof"] = index;
        rocketRoof.sprite = roofSprite[rocket["roof"]];
    }

    public void addHull(int index)
    {
        rocket["hull"] = index;
        rocketHull.sprite = hullSprite[rocket["hull"]];
    }

    public void addEngine(int index)
    {
        rocket["engine"] = index;
        rocketEngine.sprite = engineSprite[rocket["engine"]];
    }

    public void addBooster(int index)
    {
        rocket["booster"] = index;
        rocketBoosters.sprite = boosterSprite[rocket["booster"]];
    }

    public void setStats()
    {
        if (rocket.ContainsKey("roof"))
        {
            rocketAcceleration = roofStats[rocket["roof"]];
        }

        if (rocket.ContainsKey("hull"))
        {
            rocketMaxFuel = hullStats[rocket["hull"]];
        }

        if (rocket.ContainsKey("engine"))
        {
            maxThrust = engineStats[rocket["engine"]];
        }

    }
}
