using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<ItemData, int> inventoryData = new Dictionary<ItemData, int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(ItemData item)
    {
        if (inventoryData.ContainsKey(item))
        {
            inventoryData[item]++;
            Debug.Log("El item "+inventoryData[item]+" se a actializado");
        }
        else
        {
            inventoryData.Add(item, 1);
        }
        Debug.Log("Ahora hay "+inventoryData.Count+" items");
    }
}
