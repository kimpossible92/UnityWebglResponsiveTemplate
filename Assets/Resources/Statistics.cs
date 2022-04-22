using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.CanvasScaler canvasStatus;
    [SerializeField]
    private UnityEngine.UI.Text SecondsText;
    [SerializeField] 
    private UnityEngine.UI.Text BonusText;
    [SerializeField]
    private UnityEngine.UI.Text WinOrLoseText;
    [SerializeField] 
    private UnityEngine.UI.Button ButtonNext;
    public UnityEngine.UI.Button _buttonNext => ButtonNext;
    public UnityEngine.UI.Text _winOrloseText => WinOrLoseText;
    public UnityEngine.UI.Text _bonusText => BonusText;
    public UnityEngine.UI.Text _secondsText => SecondsText;
    public UnityEngine.UI.CanvasScaler _canvasScaler => canvasStatus;

    // Start is called before the first frame update
    void Start()
    {
        _buttonNext.gameObject.SetActive(false);
    }
    public void _resetTime()
    {
        second = 0;
    }
    public void SetStart()
    {
        second=0;
        InvokeRepeating("Seconds", 1f,1f);
    }
    float second;
    public float Sec => second;
    private void Seconds()
    {
        second += 1;
    }
    // Update is called once per frame
    void Update()
    {
        _secondsText.text = second.ToString();
    }
}
