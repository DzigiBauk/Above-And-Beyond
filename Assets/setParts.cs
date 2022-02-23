using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setParts : MonoBehaviour
{
    public playerScript ps;

    void Start()
    {
        Dictionary<string, int> rocket = ps.getRocket();

        if (rocket.ContainsKey("roof"))
        {
            ps.rocketRoof.sprite = ps.roofSprite[rocket["roof"]];
        } else { ps.rocketRoof.sprite = ps.roofSprite[0]; ps.addRoof(0); }

        if (rocket.ContainsKey("hull"))
        {
            ps.rocketHull.sprite = ps.hullSprite[rocket["hull"]];
        } else { ps.rocketHull.sprite = ps.hullSprite[0]; ps.addHull(0); }

        if (rocket.ContainsKey("engine"))
        {
            ps.rocketEngine.sprite = ps.engineSprite[rocket["engine"]];
        } else { ps.rocketEngine.sprite = ps.engineSprite[0]; ps.addEngine(0); }

        if (rocket.ContainsKey("booster"))
        {
            ps.rocketBoosters.sprite = ps.boosterSprite[rocket["booster"]];
        } else { ps.rocketBoosters.sprite = ps.boosterSprite[0]; ps.addBooster(0); }
    }

    public void setRoof(int index)
    {
        ps.addRoof(index);
    }

    public void setHull(int index)
    {
        ps.addHull(index);
    }

    public void setEngine(int index)
    {
        ps.addEngine(index);
    }

    public void setBooster(int index)
    {
        ps.addBooster(index);
    }

}
