using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public Camera camera;
    public float health;
    public float maxhealth;

    public void takedamage(float damage)
    {
        health -= damage;
    }


}
