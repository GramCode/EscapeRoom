using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsCollider : MonoBehaviour
{
    [SerializeField]
    private Chains _chains;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HandSaw")
        {
            _chains.StartCounting();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "HandSaw")
        {
            _chains.StopCounting();
        }
    }
}
