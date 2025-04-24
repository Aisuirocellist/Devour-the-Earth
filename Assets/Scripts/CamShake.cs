using UnityEngine;
using Unity.Cinemachine;
public class CamShake : MonoBehaviour
{
    public static CamShake Instance { get; private set; }

    private CinemachineVirtualCameraBase vertualCam;
    private CinemachineBasicMultiChannelPerlin shaker;
    public float shakeTimer;
    private float shakeTimerTotal;
    private float startStrength;

    private void Awake()
    {
        Instance = this;
        vertualCam = GetComponent<CinemachineVirtualCameraBase>();
        shaker = vertualCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void shake(float strength, float time)
    {
        shaker.AmplitudeGain = strength;
        shakeTimer = time;
        shakeTimerTotal = time;
        startStrength = strength;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            shaker.AmplitudeGain = Mathf.Lerp(0f, startStrength, shakeTimer / shakeTimerTotal);
        }
    }
}
