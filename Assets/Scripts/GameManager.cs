using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _lights;
    [SerializeField]
    private GameObject _outsideLight;
    [SerializeField]
    private GameObject _canvas;
    [SerializeField]
    private GameObject[] _pointLights;

    public static bool PowerEnabled = false;

    /// <summary>
    /// Checks if the Power is ON
    /// If the Power is ON
    /// Enable all area lights game objects in the array
    /// Else
    /// Display UI Canvas
    /// </summary>
    public void LightsOn()
    {
        if (PowerEnabled)
        {
            foreach (var light in _lights)
            {
                light.SetActive(true);
            }

            UIManager.Instance.CanvasesToDisplayWithLights();
        }
        else
        {
            UIManager.Instance.DisplayDoorLeftCanvas();
        }
    }

    public void LightsOff()
    {
        if (PowerEnabled)
        {
            foreach (var light in _lights)
            {
                light.SetActive(false);
            }
        }
    }

    public void PowerOn()
    {
        PowerEnabled = true;
    }

    /// <summary>
    /// Checks if the Power is ON
    /// If the Power is ON
    /// Enable one light in the hallway outside the room
    /// Else
    /// Display UI Canvas
    /// </summary>
    public void OutsideLightOn()
    {
        if (PowerEnabled)
        {
            _outsideLight.SetActive(true);
        }
        else
        {
            UIManager.Instance.DisplayDoorRightCanvas();
        }
    }

    public void OutsideLightOff()
    {
        if (PowerEnabled)
            _outsideLight.SetActive(false);
    }
    /// <summary>
    /// Checks if the Power is ON
    /// If the Power is ON
    /// Enable all point lights game objects in the array
    /// Else
    /// Display UI Canvas
    /// </summary>
    public void PointLightsOn()
    {
        if (PowerEnabled)
        {
            foreach (var light in _pointLights)
            {
                light.SetActive(true);
            }
        }
        else
        {
            UIManager.Instance.DisplayDoorLeftCanvas();
        }
       
    }

    public void PoitLightsOff()
    {
        foreach(var light in _pointLights)
        {
            light.SetActive(false);
        }
    }
}
