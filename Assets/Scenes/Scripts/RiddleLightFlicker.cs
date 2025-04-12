using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleLightFlicker : MonoBehaviour
{
    public Light flickerLight;
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.3f;
    public float flickerSpeed = 1f;

    void Update()
    {
        if (flickerLight != null)
        {
            float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0.0f);
            flickerLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        }
    }
}