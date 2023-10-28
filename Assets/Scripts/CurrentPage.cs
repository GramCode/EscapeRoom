using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPage : MonoBehaviour
{
    [SerializeField]
    private int _pageID;

    public int PageID()
    {
        return _pageID;
    }
}
