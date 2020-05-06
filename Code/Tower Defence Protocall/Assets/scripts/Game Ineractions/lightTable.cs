using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightTable : TableScript
{
    public Camera headCamera;
    public bool powered = false;
    public string conectionType;

    void Update()
    {
        if (powered)
        {
            if (!item.GetComponent<LightSource>().useCharge())
            {
                powered = false;
                headCamera.GetComponent<camera>().changestatus(conectionType);
            }
        }
    }

    public override void attach(GameObject go)
    {
        item = go;
        go.transform.position = holder.transform.position;
        go.transform.rotation = gameObject.transform.rotation;
        go.GetComponent<Rigidbody>().isKinematic = true;
        go.GetComponent<Collider>().enabled = true;
        if (go.GetComponent<LightSource>().hasCharge())
        {
            headCamera.GetComponent<camera>().changestatus(conectionType);
            powered = true;
        }
        holding = true;
    }

    public override GameObject remove()
    {
        if (powered)
        {
            powered = false;
            headCamera.GetComponent<camera>().changestatus(conectionType);
        }
        if (holding)
        {
            holding = false;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Collider>().enabled = false;
            return item;
        }
        return null;
    }
}
