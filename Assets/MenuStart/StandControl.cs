using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
public class StandControl : MonoBehaviour
{
    Stand GetStand;
    [SerializeField] int w1;
    [SerializeField] int h1;
    [SerializeField]
    string[] sizebutton;
    [SerializeField] Button buttonorigin;
    [SerializeField] Button[] loadcolors;
    [SerializeField] GameObject content;
    [SerializeField] GameObject logo;
    [SerializeField]
    GameObject _form;
    [SerializeField]
    GameObject _form2;
    [SerializeField]
    GameObject logo2;
    [SerializeField] GameObject[] sprites = new GameObject[8];
    [SerializeField] GameObject[] sprites2 = new GameObject[8];
    [SerializeField] Sprite[] pl1;
    [SerializeField]
    Sprite[] pl2;
    [SerializeField] private int formlog;
    int page;
    [SerializeField]int player;
    [SerializeField]
    int player2;
    List<Button> buttonscolor = new List<Button>();
    int size;
    public int LoadPage()
    {
        return page;
    }
    public int LoadPl()
    {
        return player;
    }
    public string getColors()
    {
        return sizebutton[UnityEngine.Random.Range(0, sizebutton.Length)];
    }
    #region Swich01
    public void Player2Start()
    {
        if (page == 0)
        {
            if (player == 0)
            {
                player = 1;
                for(int i=0;i<4;i++)
                {
                    sprites2[i].GetComponent<Form_>().operation2(sprites[i].GetComponent<Form_>().operation1());
                }
                foreach (var bt in buttonscolor)
                {
                    bt.GetComponent<FormLogo>().player = 1;
                    bt.GetComponent<FormLogo>().stand = GetStand;
                    bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
                }
            }
            else if (player == 1)
            {
                player = 0;
                for(int i=0;i<4;i++)
                {
                    sprites[i].GetComponent<Form_>().operation2(sprites2[i].GetComponent<Form_>().operation1());
                }
                foreach (var bt in buttonscolor)
                {
                    bt.GetComponent<FormLogo>().player = 0;
                    bt.GetComponent<FormLogo>().stand = GetStand;
                    bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
                }
            }
        }
        else if (page == 1)
        {
            if (player2 == 0)
            {
                player2 = 1;
                for(int i=4;i<8;i++)
                {
                    sprites2[i].GetComponent<Logo>().operation2(sprites[i].GetComponent<Logo>().operation1());
                }
                foreach (var bt in buttonscolor)
                {
                    bt.GetComponent<FormLogo>().player2 = 1;
                    bt.GetComponent<FormLogo>().stand = GetStand;
                    bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
                }
            }
            else if (player2 == 1)
            {
                player2 = 0;
                for(int i=4;i<8;i++)
                {
                    sprites[i].GetComponent<Logo>().operation2(sprites2[i].GetComponent<Logo>().operation1());
                }
                foreach (var bt in buttonscolor)
                {
                    bt.GetComponent<FormLogo>().player2 = 0;
                    bt.GetComponent<FormLogo>().stand = GetStand;
                    bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
                }
            }
        }
    }
    #endregion
    public void setRandomColor(Button bt)
    {
        bt.GetComponent<FormLogo>().c = sizebutton[UnityEngine.Random.Range(0, sizebutton.Length)];
        //bt.GetComponent<FormLogo>().layer = 1;
        bt.GetComponent<FormLogo>().stand = GetStand;
        bt.GetComponent<FormLogo>().SetForm();
    }
    public void btn1()
    {
        #region Page
        //if (page == 0)
        //{
        //    foreach (var bt in buttonscolor)
        //    {
        //        bt.GetComponent<FormLogo>().layer = 0;
        //        bt.GetComponent<FormLogo>().stand = GetStand;
        //        bt.GetComponent<FormLogo>().player = player;
        //        bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
        //    }
        //}
        //else
        //{
        //    foreach (var bt in buttonscolor)
        //    {
        //        bt.GetComponent<FormLogo>().layer = 4;
        //        bt.GetComponent<FormLogo>().stand = GetStand;
        //        bt.GetComponent<FormLogo>().player = player;
        //        bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
        //    }
        //}
        #endregion
        page = 1;
    }
    public void btn2()
    {
        #region Page
        //if (page == 0)
        //{
        //    foreach (var bt in buttonscolor)
        //    {
        //        bt.GetComponent<FormLogo>().layer = 1;
        //        bt.GetComponent<FormLogo>().stand = GetStand;
        //        bt.GetComponent<FormLogo>().player = player;
        //        bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
        //    }
        //}
        //else
        //{
        //    foreach (var bt in buttonscolor)
        //    {
        //        bt.GetComponent<FormLogo>().layer = 5;
        //        bt.GetComponent<FormLogo>().stand = GetStand;
        //        bt.GetComponent<FormLogo>().player = player;
        //        bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
        //    }
        //}
        #endregion
        page = 0;
    }
    public void btn3()
    {
        page = 1;
    }
    public void btn4()
    {

        #region Page
        if (page == 0)
        {
            foreach (var bt in buttonscolor)
            {
                bt.GetComponent<FormLogo>().layer = 2;
                bt.GetComponent<FormLogo>().stand = GetStand;
                bt.GetComponent<FormLogo>().player = player;
                bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
            }
        }
        else
        {
            foreach (var bt in buttonscolor)
            {
                bt.GetComponent<FormLogo>().layer = 7;
                bt.GetComponent<FormLogo>().stand = GetStand;
                bt.GetComponent<FormLogo>().player = player;
                bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
            }
        }
        #endregion
        page = 0;
    }
    public void NextSt()
    {
        _form.transform.SetParent(FindObjectOfType<CollShip>().gameObject.transform);
        _form.transform.localPosition = Vector3.zero;
        _form.transform.localScale = new Vector3(50,50,50);
        FindObjectOfType<CollShip>().setStart();
        FindObjectOfType<CollShip>().setStop(false);
        FindObjectOfType<CollShip>().setSphere2(_form.gameObject);
        //page++; 
        //if (page < 0) { page = 2; }
        //if (page > 2) { page = 0; }
        //if (page == 0)
        //{
        //    foreach (var bt in buttonscolor)
        //    {
        //        bt.GetComponent<FormLogo>().layer = 1;
        //        bt.GetComponent<FormLogo>().stand = GetStand;
        //        bt.GetComponent<FormLogo>().player = player;
        //        bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
        //    }

        //}
        //else if(page == 1)
        //{
        //    foreach (var bt in buttonscolor)
        //    {
        //        bt.GetComponent<FormLogo>().layer = 7;
        //        bt.GetComponent<FormLogo>().stand = GetStand; 
        //        bt.GetComponent<FormLogo>().player = player;
        //        bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
        //    }
        //}
    }
    public void PreviousSt()
    {
        page--;
        if (page < 0) { page = 2; }
        if (page > 2) { page = 0; }
        if (page == 0)
        {
            foreach (var bt in buttonscolor)
            {
                bt.GetComponent<FormLogo>().layer = 1;
                bt.GetComponent<FormLogo>().stand = GetStand; bt.GetComponent<FormLogo>().player = player;
                bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
            }
        }
        else if(page == 1)
        {
            foreach (var bt in buttonscolor)
            {
                bt.GetComponent<FormLogo>().layer = 7;
                bt.GetComponent<FormLogo>().stand = GetStand; bt.GetComponent<FormLogo>().player = player;
                bt.onClick.AddListener(bt.GetComponent<FormLogo>().SetForm);
            }
        }
    }
    private void Awake()
    {
        GetStand = new Stand();
        GetStand.Start(w1, h1);
        size = sizebutton.Length;
        int plus = 0;
        int pl = 0;
        buttonorigin.GetComponent<FormLogo>().c =  sizebutton[UnityEngine.Random.Range(0, sizebutton.Length)];
        buttonorigin.GetComponent<FormLogo>().layer = 1;
        buttonorigin.GetComponent<FormLogo>().stand = GetStand;
        buttonscolor.Add(buttonorigin);
        foreach (var lbt in loadcolors)
        {
            lbt.GetComponent<FormLogo>().c = sizebutton[UnityEngine.Random.Range(0, sizebutton.Length)];
            lbt.GetComponent<FormLogo>().layer = 1;
            lbt.GetComponent<FormLogo>().player = player;
            lbt.GetComponent<FormLogo>().stand = GetStand;
            buttonscolor.Add(lbt);
        }
        foreach (var bt in sizebutton)
        {
            var btns = Instantiate(buttonorigin, content.transform);
            btns.GetComponent<RectTransform>().anchoredPosition = new Vector2(buttonorigin.GetComponent<RectTransform>().anchoredPosition.x + 30*(pl+1), buttonorigin.GetComponent<RectTransform>().anchoredPosition.y - (plus * 16));
            btns.GetComponent<FormLogo>().c = bt;
            btns.GetComponent<FormLogo>().layer = 1;
            btns.GetComponent<FormLogo>().player = player;
            btns.GetComponent<FormLogo>().stand = GetStand;
            btns.onClick.AddListener(btns.GetComponent<FormLogo>().SetForm);
            buttonscolor.Add(btns);
            pl++;
            if (pl == 5) 
            { 
                plus++; pl = 0;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player == 0)
        {
            _form.SetActive(true);
            //_form2.SetActive(false);
            if (page == 0) {  }
            if (page == 1) {  }
            if (page == 2) {  }
        }
        if (player == 1)
        {
            _form.SetActive(false);
            #region form2
            //_form2.SetActive(true);
            //if (page == 0) { _form2.transform.position = new Vector2(0, 1.98f); }
            //if (page == 1) { _form2.transform.position = new Vector2(0, 1.98f); }
            //if (page == 2) { _form2.transform.position = new Vector2(-1.2f, 1.98f); }
            #endregion
        }
        if (player2 == 0)
        {
            //if (page == 0) { logo.SetActive(false);}
            //if (page == 1) { logo.SetActive(true);}
            //if (page == 2) { logo.SetActive(true); }
        }
        if (player2 == 1)
        {
            //if (page == 0) { logo2.transform.position = new Vector2(0, 1.98f); logo.SetActive(false); logo2.SetActive(false); }
            //if (page == 1) { logo2.transform.position = new Vector2(0, 1.98f); logo.SetActive(false); logo2.SetActive(true); }
            //if (page == 2) { logo2.transform.position = new Vector2(1.33f, 1.98f); logo.SetActive(false);logo2.SetActive(true); }
        }
    }
}
