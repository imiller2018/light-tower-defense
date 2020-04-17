using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float maxHealth;
    public float damageDealt;
    public float moneyDrop;
    public float attackCooldown;
    public GameObject healthbar;

    private float remainingHealth;
    private Vector3 move;
    private bool stop = false;
    private float coolDown;

    public void SetStats(float health, float damage, float drop)
    {
        maxHealth = health;
        remainingHealth = health;
        damageDealt = damage;
        moneyDrop = drop;
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
        else
        {
            
        }
    }

    public void StopAndAttack()
    {
        stop = true;
    }

    private void attack()
    {

    }

    private float drop()
    {
        return moneyDrop;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Castle")
        {
            stop = true;
        }
    }

    public void moveMonster(Vector3 m)
    {
        move = m;
    }

    public void takeDamage()
    {

    }
}
