using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{

    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float ShakeIntensity = 1.5f;
    private float ShakeTime = 0.3f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    [SerializeField] private Transform player;
    private void Awake()
    {
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        StopShake();
    }

    public void ShakeCamera()
    {
        _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain= ShakeIntensity;
        timer = ShakeTime;
    }
    
    void StopShake()
    {
        _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 2.45f, transform.position.z);
      
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                StopShake() ;
            }
        }
    }
}
