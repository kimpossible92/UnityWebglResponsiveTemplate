using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWheel : MonoBehaviour
{
    Vector3 CurrentCamPosition = new Vector3(0, 0f, 0);
    [SerializeField] GameObject _camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<CollShip>().IsMenu == true) { return; }
        _camera.transform.position = new Vector3(transform.position.x+CurrentCamPosition.x,transform.position.y +CurrentCamPosition.y,transform.position.z+CurrentCamPosition.z);
        _camera.transform.rotation = transform.rotation;
    }
}
