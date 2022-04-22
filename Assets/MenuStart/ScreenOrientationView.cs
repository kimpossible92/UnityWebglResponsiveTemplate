using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOrientationView : MonoBehaviour
{
    public DeviceOrientation deviceOrientation;//� ���������� ���������� ������� ����������

    //�������� �������, ������� � ������� ��� ��������� ���������� ������
    ButtonModels buttons;
    public GameObject[] rotateOff;             //������ ���������� ������������ � ���� ����� � � ���� settings �� �����
    public GameObject[] menuScale;             //������ ���� ��� �������� ������
    public GameObject[] imagesMenuLose;        //������ �������� ����, ������� �� ��������� � ���� ����, ����� ������ �������.
    public GameObject[] locks;

    public Transform scaleBoard;               //������ � ������� ������� �����, ���������� ��� �������� ������

    public static int lvl;                     //������ �� ���������� ������� � �����, ������������� ���-�� ����� ���� ������. LevelManager ��������� � case.
    int rotationIndex = 0;                     //0-portrait, 1 - landscapeLeft, 2 -landscapeRight;

    public static bool landscape;              //������� ������
    public bool autorotate;                    //�����������
    [SerializeField] CanvasScaler canvasScalerGlobal;
    Animator anim, anim2, animRight, animLeft; //��������� ��� ������� � ���� ��� �������� ������.
    Coroutine coroutine = null;                //�������� ��� �������� ������.
    //[SerializeField] AnimationManager[] animationManagers;
    //[SerializeField] Image MenuPlayImage;
    // Start is called before the first frame update

    string teamName;
    void Start()
    {
        autorotate = true;
        buttons = GetComponent<ButtonModels>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (landscape)
                landscape = false;

            else
                landscape = true;
        }

        if (coroutine == null)
        {
            //coroutine = StartCoroutine(Rotator());
            //ChangeOrientation(); //�������� ��� �������� ������.
        }
        PanelPos();
    }
    public void pospan(int wi,int he)
    {
        buttons.Text.GetComponent<RectTransform>().localScale = new Vector2(wi, he);
        buttons.inputFieldTeam.GetComponent<RectTransform>().localScale = new Vector2(wi, he);
        buttons.panelButton.GetComponent<RectTransform>().localScale = new Vector2(wi, he);
        buttons.panelRight.GetComponent<RectTransform>().localScale = new Vector2(wi, he);
        buttons.leftBar.GetComponent<RectTransform>().localScale = new Vector2(wi, he);
        buttons.panelLeft.GetComponent<RectTransform>().localScale = new Vector2(wi, he);
        if (wi > 2)
        {

        }
        {
            for (int i = 0; i < buttons.panelBtns.Length; i++)
            {
                buttons.panelBtns[i].GetComponent<RectTransform>().localScale = new Vector2(wi, he);
                if (wi > 2)
                {
                    buttons.panelBtns[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-240 + (i * 180), buttons.panelBtns[i].GetComponent<RectTransform>().anchoredPosition.y);
                }
                else{
                    buttons.panelBtns[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-36.2f + (i * 25), buttons.panelBtns[i].GetComponent<RectTransform>().anchoredPosition.y);
                }
            }
        }
    }
    void PanelPos() //�������, ������ � 2 ������� ������ �� ����� ���� ��� �������� ������. �������, ��������, �������.
    {
        buttons.panelDown.SetActive(true);
        float aspect = (float)Screen.height / (float)Screen.width;
        //print((float)Screen.width);
        aspect = (float)Math.Round(aspect, 2);
        //print(aspect);
        buttons.panelDown.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -45);

        if ((float)Screen.width <= 197)
        {
            buttons.leftBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(24.5f, -25);
            buttons.panelDown.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -45);
            pospan(1, 1); buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            buttons.panelRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(-21, -66);
            buttons.panelLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(24.5f, -66);
            if (aspect == 1.6f) {/*16:10*/  buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(1, 1); }
            else if (aspect == 1.78f) {/*16:9*/  buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(1, 1);}
            else if (aspect == 1.5f){/*3:2*/}
            else if (aspect == 1.33f) {/*4:3*/}
            else if (aspect == 1.67f){/*5:3*/}
            else if (aspect == 1.25f){/*5:4*/}
            else if (aspect == 2f) {/*18:9*/ buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(0.7f, 1); }
            else if (aspect == 2.06f) {/*1440x2960*/  buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(0.7f, 1); }
            else if (aspect == 2.16f) {/*1440x2960*/  buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(0.7f, 1); }
            else if (aspect >= 2.33f)/*|| aspect == 2.1666f)*/{ buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(0.7f, 1);}
            else{}
            buttons.panelButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 42);
        }
        else
        {
            
            buttons.leftBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(120, -120);
            buttons.panelDown.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -280);
            pospan(5, 5); buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(4, 4);
            
            if (aspect == 1.6f){/*16:10*/pospan(4, 4); buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(4, 4); }
            else if (aspect == 0.62f)
            {
                pospan(2, 2); buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(2, 2);
                buttons.panelDown.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -70);
                buttons.panelButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 40);
                buttons.panelRight.SetActive(false);
                buttons.panelLeft.SetActive(false);
            }
            else if (aspect == 1.78f){/*16:9*/pospan(4, 4); buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(4, 4); }
            else if (aspect == 1.5f){/*3:2*/}
            else if (aspect == 1.33f) { buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(3, 3); }
            else if (aspect == 1.67f) { buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(4.5f, 5);/*5:3*/}
            else if (aspect == 1.25f) { buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(4.5f, 5);/*5:4*/ }
            else if (aspect == 2f) {/*18:9*/  pospan(8, 8); buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(4.5f, 5); }
            else if (aspect == 2.06f) {/*1440x2960*/  pospan(8, 8); buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(4f, 4);}
            else if (aspect == 2.16f) {/*1440x2960*/  pospan(8, 8); buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(3.8f, 3.8f);}
            else if (aspect >= 2.33f)/*|| aspect == 2.1666f)*/ { buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(4f, 4);}
            else{}
             if ((float)Screen.width <= 800){
                buttons.panelRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(-66, -400);
                buttons.panelLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(66, -400);
                buttons.panelButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 100);
             }else{
                // buttons.panelButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 300);
                //buttons.panelRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(-66, -700);
                //buttons.panelLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(66, -700);
                //if ((float)Screen.width >= 1400){
                //    pospan(8, 8); buttons.panelDown.GetComponent<RectTransform>().localScale = new Vector2(8f, 8f);
                //}
            }
        }
        if (FindObjectOfType<StandControl>().LoadPage() == 0) {buttons.Text.GetComponent<Text>().text = "Form";}
        if (FindObjectOfType<StandControl>().LoadPage() == 1) {buttons.Text.GetComponent<Text>().text = "Logo";}
        if (FindObjectOfType<StandControl>().LoadPage() == 2)
        {
            buttons.Text.GetComponent<Text>().text = "Team";
            buttons.panelDown.GetComponent<RectTransform>().anchoredPosition = new Vector2(2250, buttons.panelDown.GetComponent<RectTransform>().anchoredPosition.y);
            buttons.panelRight.SetActive(false);
            buttons.panelLeft.SetActive(false);
            buttons.leftBar.SetActive(false);
            buttons.inputFieldTeam.SetActive(true);
            teamName = buttons.inputFieldTeam.GetComponent<InputField>().text;
            if (buttons.inputFieldTeam.GetComponent<InputField>().text.Length > 10)
            {
                buttons.inputFieldTeam.GetComponent<Image>().color = Color.red;
                buttons.panelButton.GetComponent<Image>().enabled = false;
                buttons.panelButton.GetComponent<Button>().enabled = false;
               // buttons.inputFieldTeam.GetComponent<Image>()
            }
            else
            {
                buttons.inputFieldTeam.GetComponent<Image>().color = Color.white;
                buttons.panelButton.GetComponent<Image>().enabled = true;
                buttons.panelButton.GetComponent<Button>().enabled = true;
            }
            for (int i = 0; i < buttons.panelBtns.Length; i++)
            {
                buttons.panelBtns[i].SetActive(false);
            }
        }
        else {
            buttons.panelDown.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, buttons.panelDown.GetComponent<RectTransform>().anchoredPosition.y);
            //buttons.panelRight.SetActive(true);
            //buttons.panelLeft.SetActive(true); 
            buttons.leftBar.SetActive(true);
            buttons.inputFieldTeam.SetActive(false);
            for (int i = 0; i < buttons.panelBtns.Length; i++)
            {
                buttons.panelBtns[i].SetActive(true);
            }
        }
    }
}
