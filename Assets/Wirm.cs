using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Wirm : NetworkBehaviour
{
    public NetworkConnection Auth;
    protected Vector3 mypoint;
    [SerializeField] float ypos,xpos=20;
    [SerializeField]private bool toTarget=false;

    // Use this for initialization
    void Start () {
        toTarget = true;
    }

    [Command]
    public void CmdRotate(Vector3 v)
    {
        RpcRotate(v);
    }
    [ClientRpc]
    void RpcRotate(Vector3 v)
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(v.x, v.y, 0));
    }
    public void ToTarget(Vector3 point)
    {
        CmdTransform(point);
    }
    [Command]
    void CmdTransform(Vector3 point)
    {
        //toTarget = true;
        RpcTransform(point);
    }
    [ClientRpc]
    void RpcTransform(Vector3 point)
    {
        //GetComponent<NetworkTransform>().
        transform.position = point;
    }
    [Command]
    public void CmdRotateTransform(float koef)
    {
        RpcRotateTransform(koef);
    }
    [ClientRpc]
    void RpcRotateTransform(float koef)
    {
        this.transform.position -= Vector3.back * koef;
    }
    // Update is called once per frame
    void Update ()
    {
        //transform.position = Vector3.MoveTowards();
    }

    public static void Copyng(Wirm origin, Wirm copy)
    {
        copy.transform.position = origin.transform.position;
    }
    int score = 0;
    private void OnGUI()
    {
        if (isServer) { xpos = 40; }
        GUI.Label(new Rect(xpos, ypos, 140, 20), score.ToString());
    }
    [SerializeField] private List<GameObject> GetBlocks = new List<GameObject>();
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "corm"|| coll.gameObject.tag == "rub")
        {
            score++;
            //GetBlocks.Add(coll.gameObject);
        }
    }
}
