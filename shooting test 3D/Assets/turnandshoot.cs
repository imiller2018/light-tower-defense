using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnandshoot : MonoBehaviour
{
    public GameObject bullet;
    public int gunAngle = 0;
    public float RotationSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.up * - (RotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
        }
        if (Input.GetKeyDown("v"))
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject bull = Instantiate(bullet, position, transform.rotation) as GameObject;
            Rigidbody bullrigidbody = bull.GetComponent<Rigidbody>();
            bullrigidbody.AddForce(transform.right * 2000);
        }
    }
}
