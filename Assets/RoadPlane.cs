using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPlane : MonoBehaviour
{
    [SerializeField]
    float localX1, localX2, localY1, localY2;
    int RandX, RandY;
    int RandCount;
    [SerializeField]
    GameObject[] objectObstacles;
    [SerializeField]
    GameObject[] Bonuses;
    List<float> positionsObstacles = new List<float>();
    GameObject[] CurrentObstacles;
    GameObject[] CurrentBonuses;
    private void CurrentSetObstacles()
    {

        if (CurrentObstacles==null||CurrentObstacles.Length == 0) return;
        RandCount = Random.Range(1, CurrentObstacles.Length);
        for (int i = 0; i < RandCount; i++)
        {
            int setVisible = Random.Range(0, 2);
            if (setVisible == 0)
            {
                CurrentObstacles[i].SetActive(true);
            }
            else
            {
                CurrentObstacles[i].SetActive(false);
            }
        }   
    }
    private void CurrentSetBonus()
    {
        if (CurrentBonuses == null || CurrentBonuses.Length == 0) return;
        RandCount = Random.Range(1, CurrentBonuses.Length);
        for (int i = 0; i < RandCount; i++)
        {
            int setVisible = Random.Range(0, 2);
            if (setVisible == 0)
            {
                CurrentBonuses[i].SetActive(true);
            }
            else
            {
                CurrentBonuses[i].SetActive(false);
            }
        }
    }
    private void SetObstacles()
    {
        if (objectObstacles == null||objectObstacles.Length == 0) return;
        RandCount = Random.Range(6, 12);

        for (int i = 0; i < RandCount; i++)
        {
            int z1 = Random.Range((int)localY1 / 10, (int)localY2 / 10);
            int x1 = Random.Range(2, 8) + (int)localX1;
            var obj1 = Instantiate(objectObstacles[Random.Range(0, objectObstacles.Length)], transform);
            obj1.transform.localPosition = new Vector3(x1, 1, z1 * 10);
            positionsObstacles.Add(z1);
        }
    }
    private void SetBonuses()
    {
        if (Bonuses == null || Bonuses.Length == 0) return;
        RandCount = Random.Range(4, 8);

        for (int i = 0; i < RandCount; i++)
        {
            int z1 = Random.Range((int)localY1 / 10, (int)localY2 / 10);
            int x1 = (int)localX1+5;
            var obj1 = Instantiate(Bonuses[Random.Range(0, Bonuses.Length)], transform);
            if (positionsObstacles.Contains(z1)) { obj1.transform.localPosition = new Vector3(x1, 1, (z1 * 10) + 5); }
            else { obj1.transform.localPosition = new Vector3(x1, 1, z1 * 10); }
        }
    }
    private void Awake()
    {
        CurrentSetObstacles();
        CurrentSetBonus();
        SetObstacles(); 
        SetBonuses();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
