using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnandshoot : MonoBehaviour
{
    public GameObject bullet;
    public int gunAngle = 0;
    public float RotationSpeed;
    public float ReloadSpeed;
    float counter;
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ReloadSpeed >= counter)
        {
            counter += Time.deltaTime;
        }
        if (Input.GetKey("a")|| Input.GetKey("left"))
        {
            transform.Rotate(Vector3.up * - (RotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (ReloadSpeed <= counter)
            {
                counter = 0;
                Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                GameObject bull = Instantiate(bullet, position, transform.rotation) as GameObject;
                Rigidbody bullrigidbody = bull.GetComponent<Rigidbody>();
                bullrigidbody.AddForce(transform.right * 2000);
            }
        }
    }
}
