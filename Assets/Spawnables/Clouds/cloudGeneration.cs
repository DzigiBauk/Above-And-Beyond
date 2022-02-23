using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int rnd = (int)Random.Range(10f, 15f);
        Vector3 randScale = new Vector3(rnd, rnd, rnd);
        transform.localScale = randScale;
    }

}
