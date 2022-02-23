using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpCheck : MonoBehaviour
{
    public RocketScript rs;
    public playerScript player;

    public AudioSource coinSound;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Fuel(Clone)"))
        {
            if (rs.fuel + 20 > rs.maxFuel)
            {
                rs.fuel = rs.maxFuel;
            }
            else
            {
                rs.fuel += 20;
                Destroy(col.gameObject);
                Debug.Log(gameObject);
            }
        }

        if (col.gameObject.name.Equals("coin(Clone)"))
        {
            player.addMoney(100);
            Destroy(col.gameObject);
            coinSound.Play();
            Debug.Log(gameObject);
        }
    }
}
