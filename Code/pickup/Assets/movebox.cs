using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebox : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform camera;
    public GameObject raycastOrigin;
    public float pickupRange;
 
    private GameObject followObj = null;
    private bool holding = false;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            Vector3 dir = Vector3.Normalize(transform.position - camera.position);
            dir.y = 0;
            transform.position = (dir * speed * Time.deltaTime) + transform.position;
            turn_direction(dir);
        }
        if (Input.GetKey("s"))
        {
            Vector3 dir = Vector3.Normalize(camera.position - transform.position);
            dir.y = 0;
            transform.position = (dir * speed * Time.deltaTime) + transform.position;
            turn_direction(dir);
        }
        if (Input.GetKey("a"))
        {
            Vector3 dir = Vector3.Normalize(new Vector3(camera.position.z - transform.position.z, 0, transform.position.x - camera.position.x));
            transform.position = (dir * speed * Time.deltaTime) + transform.position;
            turn_direction(dir);
        }
        if (Input.GetKey("d"))
        {
            Vector3 dir = Vector3.Normalize(new Vector3(transform.position.z - camera.position.z, 0, camera.position.x - transform.position.x));
            transform.position = (dir * speed * Time.deltaTime) + transform.position;
            turn_direction(dir);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!holding)
            {
                RaycastHit hit;
                Ray thisRaycast = new Ray(raycastOrigin.transform.position, transform.rotation * Vector3.forward);
                if (Physics.Raycast(thisRaycast, out hit, pickupRange))
                {
                    if (hit.collider.tag == "item")
                    {
                        followObj = hit.collider.gameObject;
                        followObj.transform.position = raycastOrigin.transform.position;
                    }
                    holding = true;
                }
            }
            else
            {
                followObj.transform.position = raycastOrigin.transform.position + (transform.rotation * Vector3.forward);
                holding = false;
            }
        }
        if (holding)
        {
            followObj.transform.position = raycastOrigin.transform.position;
            followObj.transform.rotation = transform.rotation;
        }
    }
    private void turn_direction(Vector3 targetDirection)
    {
        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime * 10;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
