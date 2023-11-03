using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Safe : MonoBehaviour
{
    [SerializeField]
    private TMP_Text[] _numbersText;
    [SerializeField]
    private AudioSource _audioSource;

    private Animator _anim;
    
    private const string PASSCODE = "2749";
    private int _numbersCount = 0;
    private string _text;

    private void Start()
    {
        _anim = GetComponent<Animator>();

        if (_anim == null)
        {
            Debug.LogError("Animator in Safe in NULL");
        }
    }

    private void InsertNumber()
    {
        Debug.Log("Inserting number on slot: " +  _numbersCount);
        switch (_numbersCount)
        {
            case 0:
                //Insert Number in first textfield
                _numbersText[0].text = _text;
                break;
            case 1:
                //Insert Number in second textfield
                _numbersText[1].text = _text;
                break;
            case 2:
                //Insert Number in third textfield
                _numbersText[2].text = _text;
                break;
            case 3:
                //Insert Number in last textfield
                _numbersText[3].text = _text;
                break;
        }

        if (_numbersCount >= 3)
        {
            if (InputNumber() == PASSCODE)
            {
                //Color green
                UIManager.Instance.SafeCanvasBehaviour(0, false);
                _anim.SetTrigger("SafeAnim");
                _audioSource.Play();
            }
            else
            {
                //Color red
                UIManager.Instance.SafeCanvasBehaviour(1, true);
                Invoke("ClearNumbers", 0.3f);
            }
        }
    }

    private string InputNumber()
    {
        string _inputNumber = "";

        foreach (var number in _numbersText)
        {
            string text = number.text;

            _inputNumber += text;
        }

        return _inputNumber;
    }



    public void ClearNumbers()
    {
        this._numbersCount = 0;
        foreach (var number in _numbersText)
        {
            number.text = "_";
        }

    }

    public void NumberEntered(int number)
    {
        _text = number.ToString();
        InsertNumber();
        _numbersCount++;
    }


}
