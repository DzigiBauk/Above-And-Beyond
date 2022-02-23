using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrustGroundCheckSC : MonoBehaviour
{
    public CameraShake cmScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("HIT");
        if (col.gameObject.name.Equals("ground"))
        {
            cmScript.isNearGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("UNHIT");
        if (col.gameObject.name.Equals("ground"))
        {
            cmScript.isNearGround = false;
        }
    }
}
