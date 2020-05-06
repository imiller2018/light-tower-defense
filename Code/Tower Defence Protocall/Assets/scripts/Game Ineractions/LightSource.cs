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
    public GameObject Meter;

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
        showCharge();
    }

    public bool useCharge()
    {
        if (chargeAmmount > 0)
        {
            chargeAmmount -= useRate * Time.deltaTime;
            showCharge();
        }
        return (chargeAmmount >= 0);
    }

    public bool hasCharge()
    {
        return (chargeAmmount >= 0);
    }

    private void showCharge()
    {
        float rate = chargeAmmount / (float)Maxcharge;
        Meter.transform.localScale = new Vector3(Meter.transform.localScale.x, Meter.transform.localScale.y, rate * 0.25f);
        Meter.transform.localPosition = new Vector3(Meter.transform.localPosition.x, rate * 0.25f + 0.125f, Meter.transform.localPosition.z);
    }
}
