using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;
[System.Serializable]
public class MyIntEvent
{
    private string colorcube;
    private string[] colors = { "red", "green", "blue" };
    private Color[] rendColor = { Color.red, Color.green, Color.blue };
    public string _colorCube => colorcube;
    public Renderer renderer;
    public int c = 0;
    [Command]
    public void SetColor()
    {
        colorcube = colors[c];
        Setrenderer(c);
    }
    [ClientRpc]
    private void Setrenderer(int r)
    {
        renderer.material.color = rendColor[r];
    } 
}
public class ProjectileGO : NetworkBehaviour
{
    public NetworkConnection Author;
    [SerializeField]
    public List<SpawnGroup> spawnGroup;
    [SerializeField]
    public List<SpawnGroup> removeSpawnGroup;
    public List<GameObject> wirms; public List<GameObject> wList2 = new List<GameObject>();
    public List<GameObject> wList = new List<GameObject>();
    [SyncVar,SerializeField]
    protected int m_PlayerId;
    [SerializeField]
    public SelectSpawn selectSpawn;
    NetworkClient myClient;
    [SerializeField]
    public GameObject[] unitPrefabs;
    bool unspawn = false;
    [SyncVar]
    public int sec = 0;
    [SerializeField]
    protected TextMesh textmesh;
    [SyncVar]
    public Vector3 mDirection;
    public Vector3 newdir;
    [SerializeField]
    public List<Transform> waypoints = new List<Transform>();
    [SerializeField]
    public List<Transform> rubipos;
    [SyncVar]
    public int addmove = 0;
    [SyncVar]
    public int newHead = 0;
    float dirspeed = 0.3f;
    [SerializeField]
    NetworkConnection wirmConnection;
    public GameObject MySpawnManager;
    public GameObject SelectSpawnprefab;
    [SerializeField]
    public GameObject Ruby;
    Vector3 myrubipos;
    [Server]
    public void SetPlayerId(int id)
    {
        m_PlayerId = id;
    }
    public override void OnStartServer()
    {
        base.OnStartServer();
    }
    public int severcount = 0;
    string firstmessage;
    string allmessage;
    public GameObject[] findall;
    public GameObject[] findone;
    NetworkTransform Networktransform; 
    public bool serveractive = true;
    public bool disconnectplayer = false;
    [SerializeField] private GameObject SetObject;
    [SerializeField] private Button buttonObjects;
    GameObject Xgo, Ygo, Zgo;
    #region colorbuttons    
    private string colorcube;
    public string _colorCube => colorcube; 
    private string[] colors = { "red", "green", "blue" };
    private Button[] colorButtons = new Button[3];
    private MyIntEvent[] m_MyEvent = new MyIntEvent[3];
    int c = 0;
    public void SetColor()
    {
        colorcube = colors[c];c++;
    }
    #endregion

    public void Start()
    {
        c = 0;
        disconnectplayer = false;
        findone = GameObject.FindGameObjectsWithTag("w");
        serveractive = true;
        sec = 1;
        spawnGroup = new List<SpawnGroup>();
        Networktransform = GetComponent<NetworkTransform>();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        wirmConnection = this.connectionToClient;
        NetworkIdentity netId = this.GetComponent<NetworkIdentity>();
        if (this.isServer)
        {
            this.wirmConnection = netId.connectionToClient;
        }
        else
        {
            this.wirmConnection = netId.connectionToServer;
        }
    }
    //[Command]
    void CmdTextMesh(Vector3 _position)
    {
        GameObject worm = MonoBehaviour.Instantiate(this.textmesh.gameObject, _position, Quaternion.identity) as GameObject;
        //NetworkIdentity wormId = this.GetComponent<NetworkIdentity>();
        //NetworkServer.SpawnWithClientAuthority(worm, this.connectionToClient);
        wList2.Add(worm);
        new WaitForSeconds(0.001f);
        //RpcTextMesh(worm);
    }
    [ClientRpc]
    void RpcTextMesh(GameObject w)
    {
        //waypoints.Insert(0, w.transform);
    }
    [Command]
    void CmdSpawn()
    {
        for (int i = 0; i < unitPrefabs.Length; i++)
        {
            
            GameObject worm = MonoBehaviour.Instantiate(this.unitPrefabs[i], new Vector3(1,0,0) * (i * 2), Quaternion.identity) as GameObject;
            NetworkIdentity wormId = this.GetComponent<NetworkIdentity>();
            NetworkServer.SpawnWithClientAuthority(worm, this.connectionToClient);
            wList.Add(worm);
            new WaitForSeconds(0.001f);
            RpcSpawn(worm);
        }
    }
    [ClientRpc]
    void RpcSpawn(GameObject w)
    {
        //waypoints.Insert(0, w.transform);
        SetObject = w;
    }
    void CmdTranslate(Vector3 v)//, Vector3 Direction)
    {
        //transform.Translate(mDirection);
        RpcTranslate(v);
        new WaitForSeconds(0.005f);
    }
    [ClientRpc]
    void RpcTranslate(Vector3 v)
    {
        v = transform.position;
        if (waypoints.Count > 0)
        {
            waypoints.Last().position = v;
            waypoints.Insert(0, waypoints.Last());
            waypoints.RemoveAt(waypoints.Count - 1);
        }
        new WaitForSeconds(0.005f);
    }
    public void SetObj(GameObject w)
    {
       wList.Add(w);
    }
    Vector3 rotateStart,rotateKoef;
    Vector3 positionStart, positionKoef;
    [Command]
    void CmdRotateTransform(float koef)
    {
        RpcRotateTransform(koef);
    }
    [ClientRpc]
    void RpcRotateTransform(float koef)
    {
        if (SetObject == null) { SetObject = wList[0]; }
        SetObject.transform.position -= Vector3.back * koef;
    }
    // Update is called once per frame с возможностью управления обозревателей мышью
    void Update()
    {
        if (!isLocalPlayer) return;
        //CmdRotateTransform(Input.mouseScrollDelta.y);
       
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            positionStart = Input.mousePosition;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rotateStart = Input.mousePosition;
        }
        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            rotateKoef = rotateStart-Input.mousePosition;
            SetObject.GetComponent<Wirm>().CmdRotate(new Vector3(rotateKoef.x, rotateKoef.y, 0));
        }
        //if (Input.GetMouseButtonDown(1)) { SetObject.GetComponent<Wirm>().CmdTransform(); }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                // Calculate the Direction to Move based on the tranform of the Player
                Vector3 moveDirectionForward = transform.forward * raycastHit.point.y * 3f * Time.deltaTime;
                Vector3 moveDirectionSide = transform.right * raycastHit.point.x * 3f * Time.deltaTime;
                
                myPoint = new Vector3(raycastHit.point.x, raycastHit.point.y, 0);
            }
        }
        //if (isClient) speed = 7.5f;
        float step = speed * Time.deltaTime;
        if (SetObject != null)
        {
            if(isServer) delays = NetworkServer.maxDelay*2;
            SetObject.GetComponent<Wirm>().ToTarget(Vector3.MoveTowards(
            SetObject.GetComponent<NetworkTransform>().transform.position,
            myPoint, _Step*delays));

            float[] _points = { myPoint.x, myPoint.y, myPoint.z };
            for (int i = 0; i < 3; i++)
            {
                if (wList2[i] != null) wList2[i].GetComponent<TextMesh>().text = _points[i].ToString();
            }
        }
    }
    float delays = 1;
    float _Step;
    float speed = 5f;
    Vector3 myPoint = new Vector3(3,0,0);
    int objectposition = 1;
    void setCube()
    {
        if (objectposition == 0)
        {
            SetObject = wList[1]; objectposition = 1;
        }
        else if(objectposition == 1)
        {
            SetObject = wList[0]; objectposition = 0;
        }
    }
    Vector3[] _positionsText= { new Vector3(12,-4,51), new Vector3(15, 9, 51), new Vector3(25, 0, 51) };
    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        CmdSpawn();
        InvokeRepeating("stepTime", 0.1f, 0.1f);
        for (int i = 0; i < 3; i++)
        {
            CmdTextMesh(_positionsText[i]);
        }
    }
    private void stepTime()
    {
        //if (isClient) { _Step = 0.1f; }
        //else {
            if (_Step > 2.5f) _Step = 0; 
        _Step = 0.5f; 
        //}
    }
    [Command]
    void CmdStep()
    {
        RpcStep();
    }
    [ClientRpc]
    void RpcStep()
    {
        
    }
    public override bool OnSerialize(NetworkWriter writer, bool initialState)
    {
        if (initialState)
        {
            writer.WritePackedUInt32((uint)this.sec);
            writer.WritePackedUInt32((uint)this.newHead);
            writer.WritePackedUInt32((uint)this.addmove);
            foreach (Transform ways in waypoints)
            {
                writer.WritePackedUInt32((uint)ways.position.x);
                writer.WritePackedUInt32((uint)ways.position.y);
                writer.WritePackedUInt32((uint)ways.position.z);
            }
            return true;
        }
        return base.OnSerialize(writer, initialState);
    }
    public override void OnDeserialize(NetworkReader reader, bool initialState)
    {
        if (initialState)
        {
            this.sec = (int)reader.ReadPackedUInt32();
            this.newHead = (int)reader.ReadPackedUInt32();
            this.addmove = (int)reader.ReadPackedUInt32();
            return;
        }
        int num = (int)reader.ReadPackedUInt32();
        if ((num & 1) != 0)
        {
            this.sec = (int)reader.ReadPackedUInt32();
        }
        if ((num & 2) != 0)
        {
            this.newHead = (int)reader.ReadPackedUInt32();
        }
        if ((num & 3) != 0)
        {
            this.addmove = (int)reader.ReadPackedUInt32();
        }
    }
    public override void OnNetworkDestroy()
    {
        base.OnNetworkDestroy();
        foreach (var w in wList)
        {
            NetworkServer.UnSpawn(w);
            Destroy(w);
        }
        findall = GameObject.FindGameObjectsWithTag("w");
    }
    private void OnGUI()
    {
        if (SetObject != null)
        {
            if (GUI.Button(new Rect(10, 140, 100, 20), SetObject.name))
            {
                setCube();
            }
        }
    }
}
