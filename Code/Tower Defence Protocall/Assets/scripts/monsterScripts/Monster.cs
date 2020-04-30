using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject healthbar;
    public float healthbarsize;
    public float attackCooldown;

    public float maxHealth;
    public float remainingHealth;
    public float damageDealt;
    public int moneyDrop;
    public float speed;
    public float difficulty;

    private bool stop = false;
    private float coolDown = 0;
    private bool moving = false;
    private GameObject castle;

    /*public void SetStats(float health, float damage, float drop, float sp, float diff)
    {
        maxHealth = health;
        remainingHealth = health;
        damageDealt = damage;
        moneyDrop = drop;
        speed = sp;
        difficulty = diff;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Castle")
        {
            stop = true;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }
        else if(other.tag == "bullet")
        {
            float damage = other.GetComponent<bulletScript>().getDamageVal();
            Destroy(other.gameObject);
            takeDamage(damage);
        }
    }

    public void SetCastle(GameObject c)
    {
        castle = c;
    }

    void Update()
    {
        if (stop)
        {
            if (coolDown < attackCooldown)
            {
                coolDown+= Time.deltaTime;
            }
            else
            {
                attack();
                coolDown = 0;
            }
        }
        else if (moving)
        {
            this.GetComponent<Rigidbody>().velocity = this.transform.forward * speed;
        }
    }

    private void attack()
    {
        castle.GetComponent<CastleandSpawnerScript>().takedamage(damageDealt);
    }

    private float drop()
    {
        return moneyDrop;
    }

    public void takeDamage(float damage)
    {
        //Debug.Log(remainingHealth);
        remainingHealth -= damage;
        //Debug.Log(remainingHealth);
        setHealthBar();
        if (remainingHealth <= 0)
        {
            castle.GetComponent<CastleandSpawnerScript>().monsterDied(difficulty, moneyDrop);
            Destroy(this.gameObject);
        }
    }

    public float getDiffVal()
    {
        return difficulty;
    }

    public void Move()
    {
        moving = true;
        setHealthBar();
    }

    private void setHealthBar()
    {
        float ratio = remainingHealth / (float)maxHealth * healthbarsize;
        healthbar.transform.localScale = new Vector3(ratio, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
    }

    public void HealthBarRotation(Vector3 camPos)
    {
        healthbar.transform.LookAt(camPos, -Vector3.up);
    }
}
