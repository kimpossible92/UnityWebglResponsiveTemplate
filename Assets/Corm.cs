using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Corm : NetworkBehaviour
{

    void Start()
    {
        if (this.isServer)
        {
            int[] randX;
            randX = new int[15];
            for (int i = 0; i < 15; i++)
            {
                randX[i] = i - 7;
            }
            int[] randY;
            randY = new int[15];
            for (int j = 0; j < 15; j++)
            {
                randY[j] = j - 7;
            }
            transform.position = new Vector3(randX[Random.Range(0, randX.Length)], randY[Random.Range(0, randY.Length)], 0);
        }
    }
    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "w")
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "server")
        {
            Destroy(gameObject);
        }
    }

}
