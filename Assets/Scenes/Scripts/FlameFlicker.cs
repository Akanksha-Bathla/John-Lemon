using UnityEngine;

public class FlameFlicker : MonoBehaviour
{
    private Light candleLight;
    private float baseIntensity;

    void Start()
    {
        candleLight = GetComponent<Light>();
        baseIntensity = candleLight.intensity;
    }

    void Update()
    {
        candleLight.intensity = baseIntensity + Random.Range(-0.2f, 0.2f);
    }
}