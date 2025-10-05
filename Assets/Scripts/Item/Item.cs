using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public List<ItemData> itemDatas = new List<ItemData>();
    public ItemData data;
    void Start()
    {
        data = itemDatas[Random.Range(0, itemDatas.Count)];
    }

    void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent<PlayerInventory>(out PlayerInventory plyInv))
        {
            plyInv.AddItem(data);
            gameObject.SetActive(false);
        }
    }
}
