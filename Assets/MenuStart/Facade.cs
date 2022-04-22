using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Facade : MonoBehaviour
{
    protected Form_ _subsystem1;

    protected Logo _subsystem2;
    protected List<Form_> form_s = new List<Form_>();
    protected List<Logo> logos = new List<Logo>();

    public Facade(Form_ subsystem1, Logo subsystem2)
    {
        this._subsystem1 = subsystem1;
        this._subsystem2 = subsystem2;
    }
    public string Operation()
    {
        string result = "Facade initializes subsystems:\n";
        result += this._subsystem1.operation1();
        result += this._subsystem2.operation1();
        return result;
    }
    private void Update()
    {
        //foreach(var fm in FindObjectsOfType<Form_>())
        //{
        //    if (!form_s.Contains(fm)) form_s.Add(fm);
        //}
        //foreach (var fm in FindObjectsOfType<Logo>())
        //{
        //    if (!logos.Contains(fm)) logos.Add(fm);
        //}
    }
}  