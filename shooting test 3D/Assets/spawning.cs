using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public float spawnTimeDelay;
    float timer = 0.0f;
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnTimeDelay) 
        {
            timer = 0.0f;
            //if (Random.Range(0.0f, 10.0f) > 7.0f)
            //{
                Vector3 position = new Vector3(26.3f, 1.0f, Random.Range(-12.0f, 8.0f));
                GameObject mon = Instantiate(monster, position, transform.rotation) as GameObject;
                movingscript MovS = mon.GetComponent<movingscript>();
                MovS.speed = 3;
            //}
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
