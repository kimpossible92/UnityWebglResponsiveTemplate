using System.Collections;
using UnityEngine.UI;
using UnityEngine;
public class Form_ : MonoBehaviour
{

    [SerializeField] string color; 
    internal Stand stand;
    [SerializeField] Button btn;
    [SerializeField] int lay;
    [SerializeField] Material GetMaterial;
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
        if(PlayerPrefs.GetString(gameObject.name)!=string.Empty) color = PlayerPrefs.GetString(gameObject.name);
        //color = "white";
    }

    // Update is called once per frame
    void Update()
    {
        stand.setColor(GetMaterial, color);
        if(FindObjectOfType<CollShip>().IsMenu==false)return;
        if (FindObjectOfType<StandControl>() != null||FindObjectOfType<StandControl>().LoadPage() == 0)
        {
            btn.GetComponent<FormLogo>().c = color;
            stand.SetImageColor(btn.GetComponent<Image>(), color);
        }
        PlayerPrefs.SetString(gameObject.name, color);
    }
}