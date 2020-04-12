 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Recipe
{
    public List<int> material;
    public GameObject result;
}


[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<Recipe> recipies;
    private GameObject result;

    public bool CanCraft(List<Item> items)
    {
        orderlist(items);
        foreach (Recipe R in recipies)
        {
            if (R.material.Count == items.Count)
            {
                for (int i =0; i<R.material.Count; i++)
                {
                    if (R.material[i] != items[i].ID)
                        break;
                }
                result = R.result;
                return true;
            }
        }
        return false;
    }

    public GameObject Craft()
    {
        GameObject newGO = result;
        result = null;
        return newGO;
    }

    private void orderlist(List<Item> items)
    {
        if (items.Count > 1)
        {
            bool swapped = false;
            do
            {
                for (int j = 0; j < items.Count - 1; j++)
                {
                    if (items[j].ID > items[j + 1].ID)
                    {
                        swapped = true;
                        Item temp = items[j];
                        items[j] = items[j+1];
                        items[j + 1] = temp;
                    }
                }
            } while (swapped);
        }
    }
}


