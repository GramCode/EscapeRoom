using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTriggerRight : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _colliders;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Page")
        {
            int ID = other.GetComponent<CurrentPage>().PageID();
            Debug.Log("Page ID is: " + ID);
            switch (ID)
            {
                case 0:
                    //Enable first and second collider
                    _colliders[0].SetActive(true);
                    _colliders[1].SetActive(false);
                    break;
                case 1:
                    //Disable first collider
                    //Enable second collider
                    _colliders[0].SetActive(false);
                    _colliders[1].SetActive(true);
                    break;
            }
        }
    }
}
