using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public float Y_angleMin;
    public float Y_angleMax;

    public Transform player;
    private Camera cam;
    public float height;
    public float distance = 10.0f;


    private float currentX = 0.0f;
    public float sensivityX = 4.0f;

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X");

        }
    }
    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(0, currentX, 0);
        transform.position = player.position + rotation * dir;
        transform.LookAt(player);
    }
}
