using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField]
    private GameObject _doorLeftCanvas;

    [SerializeField]
    private GameObject _doorRightCanvas;

    [SerializeField]
    private GameObject _safeCanvas;

    [SerializeField]
    private Image _backgroundImage;
    [SerializeField]
    private Color[] _colors; // 0 = green, 1 = red, 2 = blue

    [SerializeField]
    private GameObject[] _canvasToDisplayWithLight;

    [SerializeField]
    private TMP_Text _trashCountCanvasText;

    private void DisableDoorRightCanvas()
    {
        _doorRightCanvas.SetActive(false);
    }

    private void DisableDoorLeftCanvas()
    {
        _doorLeftCanvas.SetActive(false);
    }
    public void DisplayDoorLeftCanvas()
    {
        _doorLeftCanvas.SetActive(true);
        Invoke("DisableDoorLeftCanvas", 1.6f);
    }

    public void DisplayDoorRightCanvas()
    {
        _doorRightCanvas.SetActive(true);
        Invoke("DisableDoorRightCanvas", 1.6f);
    }

    public void SafeCanvasBehaviour(int colorIndex, bool canvasVisible)
    {
        _backgroundImage.color = _colors[colorIndex];
        StartCoroutine(ColorFlickerRoutine());

        if (!canvasVisible)
        {
            Invoke("HideSafeCanvas", 0.6f);
        }
    }

    private void HideSafeCanvas()
    {
        _safeCanvas.SetActive(false);
    }

    IEnumerator ColorFlickerRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        _backgroundImage.color = _colors[2];
    }

    public void CanvasesToDisplayWithLights()
    {
        foreach (var canvas in _canvasToDisplayWithLight)
        {
            canvas.SetActive(true);
        }
    }

    public void UpdateTrashCount(int num)
    {
        _trashCountCanvasText.text = num.ToString() + " / 3";
    }
}
