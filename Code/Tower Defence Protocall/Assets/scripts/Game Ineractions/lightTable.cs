using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightTable : TableScript
{
    public Camera headCamera;
    public Vector3 position;
    private Vector3 Originalposition;
    // Update is called once per frame

    void Start()
    {
        Originalposition = headCamera.transform.position;
    }

    void Update()
    {
        if (holding)
        {
            if (!item.GetComponent<LightSource>().useCharge())
            {
                headCamera.transform.position = Originalposition;
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
        if(go.GetComponent<LightSource>().hasCharge())
            headCamera.transform.position = position;
        holding = true;
    }

    public override GameObject remove()
    {
        if (holding)
        {
            holding = false;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Collider>().enabled = false;
            headCamera.transform.position = Originalposition;
            return item;
        }
        return null;
    }
}
