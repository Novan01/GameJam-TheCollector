using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;

    public static LightingManager instance;

    [SerializeField] private float slowMultiplier; // how slow you want the time to be (smaller the number the slower it is)

    // Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;

    //multiplier to increase time
    private void Start()
    {
        slowMultiplier = 0.1f;
    }

    private void Update()
    {
        if (Preset == null)
            return;
        //if the game is started increase time
        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime * slowMultiplier;
            TimeOfDay %= 24;

            UpdateLighting(TimeOfDay / 24f);
            
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    //control the direction of the light as the game progressos
    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, -170, 0));
        }
    }
    
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();

            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

    //method to return time of day
    public float getTimeOfDay()
    {
        return TimeOfDay;
    }
}