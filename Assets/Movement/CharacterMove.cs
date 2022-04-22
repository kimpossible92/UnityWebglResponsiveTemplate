using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {
    private Camera cam;
    float pointrot = 0f;
    private void Start ()
    {
        cam = Camera.main;
    }

    private void FixedUpdate ()
    {
        Move();
    }
    public void LateralRotate(float amount)
    {
        transform.rotation = Quaternion.Euler(0, 0, amount);
    }
    private void Move ()
    {
        // Getting the direction to move through player input
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        float speed = 15.0f;
        
        LateralRotate(pointrot);
        // Get directions relative to camera
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        // Project forward and right direction on the horizontal plane (not up and down), then
        // normalize to get magnitude of 1
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Set the direction for the player to move
        Vector3 dir =  new Vector3(0,0,vMove)*speed;

        // Set the direction's magnitude to 1 so that it does not interfere with the movement speed
        dir.Normalize();

        // Move the player by the direction multiplied by speed and delta time 
        transform.position += dir * speed * Time.deltaTime;
        //transform.rotation += 
        transform.Rotate(0, hMove / 60 * 360 * Time.deltaTime, 0);
        // Set rotation to direction of movement if moving
        if (dir != Vector3.zero)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(forward), 0.2f);
        }

    }
}