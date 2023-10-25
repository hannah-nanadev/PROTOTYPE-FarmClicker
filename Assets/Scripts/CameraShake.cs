using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cvc;
    private float ShakeIntensity = 1f;
    private float ShakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    //Awake is called upon object initialisation
    void Awake()
    {
        cvc = GetComponent<CinemachineVirtualCamera>();
    }

    //Start is called before the first frame - Prevents camera from starting out shaking
    private void Start()
    {
        StopShake();
    }

    //Method to call if something wants to shake/stop shaking camera
    public void ShakeCamera()
    {
        _cbmcp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = ShakeIntensity;

        timer = ShakeTime;
    }

    void StopShake()
    {
        _cbmcp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }

    //Update is called every frame - Makes camera shake if mouse is clicked
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            ShakeCamera();

        if(timer>0)
        {
            timer -= Time.deltaTime;

            if(timer<=0)
                StopShake();
        }
    }
}
