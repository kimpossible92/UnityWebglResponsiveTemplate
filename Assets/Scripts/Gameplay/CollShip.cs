using System.Collections;
using UnityEngine;
using Gameplay.Spaceships;
using Gameplay.ShipSystems;

public class CollShip : MonoBehaviour
{
    public enum slojnost
    {
        easy = 1, normal = 3, hard = 5, nevosmojno = 10
    }
    public slojnost OnSlojnost;
    public static bool isInvincible = false;
    public static float timeSpentInvincible;
    public Texture2D lifeIconTexture;
    public static bool dead = false;
    public static int life = 100;
    public int bonusScore;
    [SerializeField] LayerMask layer; public float speed2 = 0.04f;
    public float speed = 0.1f;[SerializeField]
    bool showGUI = true;
    public float limitx1 = -2, limitx = 16f, limity1 = -1, limity = 7;
    // NEED TO ADD
    public static Vector2 bombermanPosition, bombermanPositionRounded;
    Vector2 dir2; int dr = 5;
    Animator anim; Vector3 startpos1;
    Quaternion Rotstart;
    [SerializeField]GameObject CanvasMenu;
    [SerializeField] Statistics StaticMenu;
    [SerializeField] GameObject sphere2;
    public void setSphere2(GameObject @object) { sphere2 = @object; }
    private bool pause=false;
    public void setStop(bool p) { pause = p; }
    public void SetDead(bool d) { dead = d; if(d == false) { life = 100; } FindObjectOfType<Statistics>()._resetTime(); }
    public bool _pause => pause;

    int Level = 0;
    private void Awake()
    {
        //startpos1 = transform.position;
    }
    public void NewStart()
    {
        dead = false;
        life = 100;
        startpos1 = transform.position;
        Rotstart = transform.rotation;
    }
    bool visibleMenu=false;
    [HideInInspector]public bool IsMenu = false;
    // Use this for initialization
    private void Start()
    {
        pause = true;
        if (!visibleMenu) {
            GetComponent<Rigidbody>().isKinematic = true;
            IsMenu = true;
            return; 
        }
        NewStart();
    }
    public void setStart()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        IsMenu = false;
        CanvasMenu.SetActive(false);
        GetComponent<MeshRenderer>().enabled = false;
        NewStart();
        FindObjectOfType<Statistics>().SetStart();
    }
    private void Update()
    {
        if (dead)
        {
            //Application.LoadLevel("SampleScene"); 
            transform.position = startpos1;
            transform.rotation = Rotstart;
            foreach (var pi in FindObjectsOfType<Gameplay.Spawners.Spawner>())
            {
                pi.StopSpawn();
            }
            GameObject.Find("Status").transform.Find("Canvas2").transform.Find("Button").gameObject.SetActive(true);

        }
        if (isInvincible)
        {
            timeSpentInvincible += Time.deltaTime;

            if (timeSpentInvincible < 3f)
            {
                float remainder = timeSpentInvincible % .3f;
                sphere2.GetComponent<Renderer>().enabled = remainder > .15f;
            }

            else
            {
                sphere2.GetComponent<Renderer>().enabled = true;
                isInvincible = false;
            }
        }
    }
    void DisplayLifeCount()
    {
        Rect lifeIconRect = new Rect(10, 150, 32, 32);
        GUI.DrawTexture(lifeIconRect, lifeIconTexture);

        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.yellow;

        Rect labelRect = new Rect(lifeIconRect.xMax + 10, lifeIconRect.y, 60, 32);
        GUI.Label(labelRect, life.ToString(), style);
        Rect rect2 = new Rect(lifeIconRect.xMax + 10, lifeIconRect.y-40, 60, 32);
        GUI.Label(rect2, bonusScore.ToString(), style);
    }
    void OnGUI()
    {
        if (!showGUI)
            return;
        DisplayLifeCount();
        if (dead) StaticMenu._winOrloseText.text = Level.ToString() + "lose";
        else StaticMenu._winOrloseText.text = Level.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            #region old1
            life -= (int)100;
            if (life <= 0)
            {
                dead = true;
            }
            isInvincible = true;
            timeSpentInvincible = 0;
            #endregion


        }
        if (collision.gameObject.tag == "bonus")
        {
            collision.gameObject.SetActive(false);
            bonusScore += 1;
        }
        if (collision.gameObject.tag == "powerup")
        {
            NewLevelLoad(collision.gameObject);
        }
    }
    public void NewLevelLoad(GameObject FinishGO)
    {
        setStop(true);
        Level = PlayerPrefs.GetInt("Level");
        Level += 1;
        //transform.position = FinishGO.transform.position + Vector3.forward;
        startpos1 = transform.position;
        Rotstart = transform.rotation;
        GameObject.Find("Status").transform.Find("Canvas2").transform.Find("Button").gameObject.SetActive(true);

        //PlayerPrefs.SetInt("Level", Level);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Level",Level);
    }
}