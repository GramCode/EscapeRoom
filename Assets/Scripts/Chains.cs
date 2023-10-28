using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chains : MonoBehaviour
{
    private const float TIMETOCUT = 3;
    private bool _canCount = false;
    private bool _coroutineStarted = false;

    private void Update()
    {
        if (_canCount && !_coroutineStarted)
        {
            _coroutineStarted = true;
            StartCoroutine("StartTimerRoutine");
        }

        if (_canCount == false)
        {
            StopCoroutine("StartTimerRoutine");
            _coroutineStarted = false;
        }
    }

    public void StartCounting()
    {
        _canCount = true;
    }
    public void StopCounting()
    {
        _canCount = false;
    }

    IEnumerator StartTimerRoutine()
    {
        yield return new WaitForSeconds(TIMETOCUT);
        gameObject.SetActive(false);
    }
}
