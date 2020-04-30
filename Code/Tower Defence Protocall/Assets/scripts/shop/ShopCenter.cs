using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCenter : TableScript
{
    [System.Serializable]
    public struct HUD
    {
        public string name;
        public int val;
        public Sprite pic;
        public int price;
        public string need;
        public GameObject obj;
    }
    public GameObject Castle;
    public List<HUD> hud;
    private List<HUD> visualhud = null;
    public GameObject[] placement = new GameObject[3];
    private int position;

    public void Update()
    {
        if (holding && item.tag == "Light")
        {
            item.GetComponent<LightSource>().Charge();
        }
    }

    public void showUI()
    {
        if (visualhud == null)
        {
            changeUI();
        }
        /*placement[0].GetComponent<SpriteRenderer>().sprite = visualhud[(position - 1) % visualhud.Count].pic;
        placement[1].GetComponent<SpriteRenderer>().sprite = visualhud[position].pic;
        placement[2].GetComponent<SpriteRenderer>().sprite = visualhud[(position + 1) % visualhud.Count].pic;*/
        placement[1].GetComponent<SpriteRenderer>().sprite = visualhud[position].pic;

        if (position > 0)
            placement[0].GetComponent<SpriteRenderer>().sprite = visualhud[position - 1].pic;
        else
            placement[0].GetComponent<SpriteRenderer>().sprite = visualhud[visualhud.Count - 1].pic;

        if (position < visualhud.Count-1)
            placement[2].GetComponent<SpriteRenderer>().sprite = visualhud[position + 1].pic;
        else
            placement[2].GetComponent<SpriteRenderer>().sprite = visualhud[0].pic;
    }
    private void changeUI()
    {
        position = 0;
        visualhud = new List<HUD>();
        foreach (HUD H in hud)
        {
            if (H.need == "" || (holding && H.need == item.tag) || (H.need == "None" && !holding))
            {
                visualhud.Add(H);
            }
        }
    }

    public void moveNext()
    {
        if (position < visualhud.Count - 1)
            position = position + 1;
        else
            position = 0;
        showUI();
    }
    public void movePrev()
    {
        if (position > 0)
            position = position - 1;
        else
            position = visualhud.Count - 1;
        showUI();
    }

    public bool Buy()
    {
        if (Castle.GetComponent<CastleandSpawnerScript>().Buy(hud[position].price))
        {
            switch (visualhud[position].val)
            {
                case 0:
                    Castle.GetComponent<CastleandSpawnerScript>().addHealth(30);
                    break;
                case 1:
                case 2:
                    GameObject newObj = Instantiate(hud[position].obj, holder.transform.position, holder.transform.rotation);
                    item = newObj;
                    holding = true;
                    changeUI();
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            changeUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void attach(GameObject go)
    {
        item = go;
        go.transform.position = holder.transform.position;
        go.transform.rotation = gameObject.transform.rotation;
        go.GetComponent<Rigidbody>().isKinematic = true;
        go.GetComponent<Collider>().enabled = true;
        holding = true;
        changeUI();
    }

    public override GameObject remove()
    {
        if (holding)
        {
            holding = false;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Collider>().enabled = false;
            changeUI();
            return item;
        }
        return null;
    }

    public void turnOffUI()
    {
        placement[0].GetComponent<SpriteRenderer>().sprite = null;
        placement[1].GetComponent<SpriteRenderer>().sprite = null;
        placement[2].GetComponent<SpriteRenderer>().sprite = null;
    }
}
