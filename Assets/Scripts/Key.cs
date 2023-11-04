using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Vector3 _startingPosition;
    void Start()
    {
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            transform.position = _startingPosition;
        }
    }
}
