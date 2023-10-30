using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField]
    private GameObject _thirdLockerHandleCollider;
    [SerializeField]
    private AudioSource _audioSource;

    private int _clothesCount = 0;

    private void Update()
    {
        if (_clothesCount >= 2)
        {
            //play sound
            //unlock locker
            _thirdLockerHandleCollider.SetActive(true);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Clothes")
        {
            
            _clothesCount++;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Clothes")
        {
            _clothesCount--;
        }
    }
}
