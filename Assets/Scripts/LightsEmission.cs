using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightsEmission : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer[] _pointLightsMesh;
    [SerializeField]
    private MeshRenderer[] _areaLightsMesh;

    private void Start()
    {
        foreach (var pointLight in _pointLightsMesh)
        {
            pointLight.material.DisableKeyword("_EMISSION");
        }

        foreach (var areaLight in _areaLightsMesh)
        {
            areaLight.material.DisableKeyword("_EMISSION");
        }
    }

    public void AreaLightEmissionEnabled()
    {

        foreach (var areaLight in _areaLightsMesh)
        {
            areaLight.material.EnableKeyword("_EMISSION");
        }
    }

    public void AreaLightEmissionDissabled()
    {
        foreach (var areaLight in _areaLightsMesh)
        {
            areaLight.material.DisableKeyword("_EMISSION");
        }
    }

    public void PointLightsEmissionEnabled()
    {
        foreach (var pointLight in _pointLightsMesh)
        {
            pointLight.material.EnableKeyword("_EMISSION");
        }
    }

    public void PointLightsEmissionDisabled()
    {
        foreach (var pointLight in _pointLightsMesh)
        {
            pointLight.material.DisableKeyword("_EMISSION");
        }
    }
}
