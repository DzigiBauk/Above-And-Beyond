using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public RocketScript rs;

    private CinemachineVirtualCamera vCam;

    //Screen Shake
    private float shakeRemaining;
    private float shakeImpact;

    public float shakeFade = 0;
    public float shakeTM_Input = 0;
    public float shakeIMP_Input = 0;

    public bool isNearGround = true;

    Vector3 resetVector = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && isNearGround == true && rs.fuel > 0)
        {
            intShake(shakeTM_Input, shakeIMP_Input);
        }

        if (shakeRemaining > 0)
        {
            shakeRemaining -= Time.deltaTime;
            if (shakeRemaining <= 0f)
            {
                CinemachineBasicMultiChannelPerlin vCamPerlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                vCamPerlin.m_AmplitudeGain = Mathf.MoveTowards(vCamPerlin.m_AmplitudeGain, 0f, shakeFade);
            }
        }

        if (shakeRemaining <= 0f)
        {
            CinemachineBasicMultiChannelPerlin vCamPerlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            vCamPerlin.m_AmplitudeGain = Mathf.MoveTowards(vCamPerlin.m_AmplitudeGain, 0f, shakeFade);
        }
    }

    public void LateUpdate()
    {
        
    }

    public void intShake(float length, float impact)
    {
        CinemachineBasicMultiChannelPerlin vCamPerlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        vCamPerlin.m_AmplitudeGain = impact;
        shakeRemaining = length;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("HIT");
        isNearGround = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("UNHIT");
        isNearGround = false;
    }
}
