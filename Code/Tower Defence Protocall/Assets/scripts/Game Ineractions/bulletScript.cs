using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private float damage;
    private string effect;

    public float getDamageVal()
    {
        return damage;
    }

    public void setstats(float dam, string eff)
    {
        damage = dam;
        effect = eff;
    }

    public void setMaterial(Material m)
    {
        this.GetComponent<Renderer>().material = m;
    }

    public string getEffect()
    {
        return effect;
    }
}
