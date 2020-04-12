using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class TableScript : MonoBehaviour
{
    public GameObject holder;
    public int tableType;
    public GameObject specialItem;

    private GameObject item;
    private bool holding = false;
    private Inventory inventory;

    public bool holdingStatus()
    {
        return holding;
    }

    public void attach(GameObject go)
    {
        switch (tableType)
        {
            case 0:
            case 1: //holds resources
                item = go;
                go.transform.position = holder.transform.position;
                go.transform.rotation = gameObject.transform.rotation;
                go.GetComponent<Rigidbody>().isKinematic = true;
                go.GetComponent<Collider>().enabled = true;
                holding = true;
                break;
            case 2: //crafts items
                break;
        }
    }

    public GameObject remove()
    {
        switch (tableType)
        {
            case 0:
                if (holding)
                {
                    holding = false;
                    item.GetComponent<Rigidbody>().isKinematic = false;
                    item.GetComponent<Collider>().enabled = false;
                    return item;
                }
                break;
            case 1:
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
            case 2: //crafts items

                break;
        }
        return null;
        
    }

    public GameObject getItem()
    {
        return item;
    }
}
*/

public class TableScript : MonoBehaviour
{
    public GameObject holder;
    public GameObject specialItem;

    public GameObject item;
    public bool holding = false;

    public bool holdingStatus()
    {
        return holding;
    }

    public void attach(GameObject go)
    {
        item = go;
        go.transform.position = holder.transform.position;
        go.transform.rotation = gameObject.transform.rotation;
        go.GetComponent<Rigidbody>().isKinematic = true;
        go.GetComponent<Collider>().enabled = true;
        holding = true;
    }

    public GameObject remove()
    {
        if (holding)
        {
            holding = false;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Collider>().enabled = false;
            return item;
        }
        return null;
    }

    public GameObject getItem()
    {
        return item;
    }
}