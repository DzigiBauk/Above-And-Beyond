using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothing = 0.01f;

    public Vector3 offset;
    public Vector3 velocity = Vector3.one;

    void FixedUpdate()
    {
        Vector3 finalPos = target.position + offset;
        Vector3 smoother = Vector3.SmoothDamp(transform.position, finalPos, ref velocity, smoothing);
        transform.position = finalPos;
    }
}
