using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayerBird : MonoBehaviour
{
    public float speed;
    public GameObject raycastOrigin;
    public GameObject back;
    public float pickupRange;

    private GameObject followObj = null;
    private bool holding = false;


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 total = new Vector3(0, 0, 0);
        if (Input.GetKey("w"))
        {
            total += Vector3.forward;
        }
        if (Input.GetKey("s"))
        {
            total += Vector3.back;
        }
        if (Input.GetKey("a"))
        {
            total += Vector3.left;
        }
        if (Input.GetKey("d"))
        {
            total += Vector3.right;
        }
        total = Vector3.Normalize(total);
        transform.position = total * speed * Time.deltaTime + transform.position;
        turn_direction(total);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!holding)
            {
                RaycastHit hit;
                Ray thisRaycast = new Ray(back.transform.position, transform.rotation * Vector3.forward);
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
        float singleStep = speed * Time.deltaTime * 4;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
