using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chains : MonoBehaviour
{
    [SerializeField]
    private Animator _doorAnim;
    [SerializeField]
    private GameObject _gameOverCanvas;
    [SerializeField]
    private AudioSource _chainAudioSource;
    [SerializeField]
    private AudioSource _doorAudioSource;
    [SerializeField]
    private AudioSource _handSawAudioSource;

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

        StartCoroutine(ChainsFlickerRoutine());

        _chainAudioSource.Play();
        _gameOverCanvas.SetActive(true);
        GameManager.Instance.LockPlayer();
        
        Invoke("OpenExitDoor", 1.8f);
    }

    IEnumerator ChainsFlickerRoutine()
    {
        float count = 0f;
        while (count <= 1.8f)
        {
            yield return new WaitForSeconds(0.2f);
            gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            gameObject.SetActive(false);

            count += 0.6f;
        }
        
    }

    private void OpenExitDoor()
    {
        _doorAnim.SetTrigger("OpenDoor");
        _doorAudioSource.Play();
    }
    public void PlayHandSawSound()
    {
        _chainAudioSource.Play();
    }

    public void StopHandSawSound()
    {
        _chainAudioSource.Stop();
    }
}
