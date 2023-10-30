using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chains : MonoBehaviour
{
    [SerializeField]
    private Animator _doorAnim;
    [SerializeField]
    private GameObject _gameOverCanvas;

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
        _gameOverCanvas.SetActive(true);
        gameObject.SetActive(false);
        _doorAnim.SetTrigger("OpenDoor");
        GameManager.Instance.LockPlayer();
        

    }
}
