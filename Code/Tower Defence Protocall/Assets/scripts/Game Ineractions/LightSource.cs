using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    public float Maxcharge;
    public float chargeRate;
    public float useRate;
    private float chargeAmmount = 0;
    private bool charging;

    private void Start()
    {
        chargeAmmount = Maxcharge;
    }

    public void Charge()
    {
        if (chargeAmmount < Maxcharge)
        {
            chargeAmmount += chargeRate * Time.deltaTime;
        }
    }

    public float useCharge()
    {
        if (chargeAmmount > 0)
        {
            chargeAmmount -= useRate * Time.deltaTime;
        }
        return chargeAmmount;
    }
}
