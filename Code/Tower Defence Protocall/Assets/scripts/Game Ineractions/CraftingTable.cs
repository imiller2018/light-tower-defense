using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : TableScript
{
    public float totalCraftingTime;
    public CraftingRecipe CraftRec;
    public GameObject[] holders = new GameObject[3];
    public bool isCraftable;
    private List<GameObject> items = new List<GameObject>();
    private List<Item> itemDataList = new List<Item>();
    public float craftTime = 0;
    private int itemcounter = -1;

    public override bool holdingStatus()
    {
        return (items.Count == 3);
    }

    private void craft()
    {
        item = Instantiate(CraftRec.Craft()) as GameObject;
        item.transform.position = holder.transform.position;
        item.transform.rotation = gameObject.transform.rotation;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Collider>().enabled = true;
        item.tag = "item";
        holding = true;
    }

    public void increaseCraftBar()
    {
        if (isCraftable && !holding)
        {
            craftTime += Time.deltaTime;
            if (craftTime >= totalCraftingTime)
            {
                craftTime = 0;
                itemcounter = 0;
                craft();
                isCraftable = false;
                removeAllItems();
            }
        }
    }

    public override void attach(GameObject go)
    {
        itemcounter++;
        items.Add(go);
        itemDataList.Add(go.GetComponent<Item>());
        go.transform.position = holders[itemcounter].transform.position;
        updateCrafting();
        Updatebar();
    }

    public override GameObject remove()
    {
        if (holding)
        {
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Collider>().enabled = false;
            holding = false;
            return item;
        }
        else if (itemcounter >= 0)
        {
            GameObject lastitem = items[itemcounter];
            items.RemoveAt(itemcounter);
            itemDataList.RemoveAt(itemcounter);
            itemcounter--;
            lastitem.GetComponent<Rigidbody>().isKinematic = false;
            lastitem.GetComponent<Collider>().enabled = false;
            return lastitem;
        }
        updateCrafting();
        Updatebar();
        return null;
    }

    private void updateCrafting()
    {
        isCraftable = CraftRec.CanCraft(itemDataList);
    }

    private void Updatebar()
    {
        
    }

    private void removeAllItems()
    {
        foreach (GameObject i in items)
        {
            Destroy(i);
        }
        items.Clear();
        itemDataList.Clear();
        itemcounter = -1;
    }
}
