using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    [SerializeField] string color;
    internal Stand stand;
    [SerializeField] Button btn;
    [SerializeField] int lay;
    public string operation1()
    {
        return color;
    }
    public void operation2(string c2)
    {
        color = c2;
    }
    // Use this for initialization
    void Start()
    {
        stand = new Stand();
        //color = "white";
        if (PlayerPrefs.GetString(gameObject.name) != string.Empty) color = PlayerPrefs.GetString(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        stand.setColor(GetComponent<Renderer>().material, color);
        if (FindObjectOfType<CollShip>().IsMenu == false) return;
        if (FindObjectOfType<StandControl>()!=null||FindObjectOfType<StandControl>().LoadPage() == 1)
        {
            btn.GetComponent<FormLogo>().c = color;
            stand.SetImageColor(btn.GetComponent<Image>(), color);
        }
        PlayerPrefs.SetString(gameObject.name, color);
    }
}
