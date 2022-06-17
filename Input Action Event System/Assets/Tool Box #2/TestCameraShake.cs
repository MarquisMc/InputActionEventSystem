using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraShake : MonoBehaviour
{
    public float shakeTime;
    public float shakeMagnitude;
    public float xRange, yRange;


    public CameraShake camShake;

    public void shakeCam()
    {
        StartCoroutine(camShake.ShakeWithTime(shakeTime, shakeMagnitude, xRange, yRange)); // shake the camera
    }
}
