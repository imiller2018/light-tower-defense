using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public GameObject healthbar;
    public float MaxHealth;
    float health;
    private void OnTriggerEnter(Collider other)
    {
        //transform.position = new Vector3((float)num, transform.position.y, transform.position.z);
        if (other.gameObject.tag == "bullet")
        {
            bullet bull = other.gameObject.GetComponent<bullet>();
            health -= bull.damage;
            float bar = 8.0f * health / MaxHealth;
            healthbar.transform.localScale = new Vector3(bar, 1.5f, 0.1f);
            Destroy(other.gameObject);
            if (health <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
