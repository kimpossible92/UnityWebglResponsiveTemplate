using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class FormLogo : MonoBehaviour
{
    [SerializeField]public string c;
    [SerializeField] Color c2;
    [SerializeField] GameObject[] sprites;
    [SerializeField] GameObject[] sprites2;
    [SerializeField] GameObject logo;
    [SerializeField]
    GameObject _form;
    [SerializeField] internal int layer = 1;
    [SerializeField] internal int player=0;[SerializeField]
    internal int player2 = 0;
    internal Stand stand;
    [SerializeField] int btn;
    public void SetForm()
    {
        //print(FindObjectOfType<StandControl>().LoadPage());
        stand = new Stand();
        if (FindObjectOfType<StandControl>().LoadPage() == 0)
        {
            logo.GetComponent<Logo>().operation2(c);
            stand.setColor(logo.GetComponent<Renderer>().material, c);
        }
        else if (FindObjectOfType<StandControl>().LoadPage() == 1)
        {
            _form.GetComponent<Form_>().operation2(c);
            stand.setColor(_form.GetComponent<Renderer>().material, c);
        }
    }
    // Use this for initialization
    void Start()
    {
        player = 0;
        if (tag == "color") {
            //c = FindObjectOfType<StandControl>().getColors(); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (stand != null) { stand.SetImageColor(GetComponent<Image>(),c); }
        else{ }
        if (tag == "color")
        {
            if (FindObjectOfType<StandControl>().LoadPage() == 0)
            {
                stand = new Stand(); 
                stand.SetImageColor(GetComponent<Image>(), c);
            }
            if (FindObjectOfType<StandControl>().LoadPage() == 1)
            {
                stand = new Stand();
                stand.SetImageColor(GetComponent<Image>(), c);
            }
        }
    }
}