using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().Play("C4D Animation Take", -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
