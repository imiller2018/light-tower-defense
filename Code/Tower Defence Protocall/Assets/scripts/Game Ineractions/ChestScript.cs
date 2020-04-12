using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : TableScript
{
    public new GameObject remove()
    {
        if (holding)
        {
            holding = false;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Collider>().enabled = false;
            return item;
        }
        else
        {
            return Instantiate(specialItem, new Vector3(0f, -1f, 0f), Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        }
    }
}
