using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Poison : MonoBehaviour
{
    [SerializeField]
    private GameObject _poisonCanvas;

    public void Poisoned()
    {
        GameManager.Instance.LockPlayer();
        _poisonCanvas.SetActive(true);
        StartCoroutine(RestartRoutine());
    }

    IEnumerator RestartRoutine()
    {
        yield return new WaitForSeconds(4.0f);
        GameManager.Instance.RestartScene();
    }
}
