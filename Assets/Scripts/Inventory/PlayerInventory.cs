using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<ItemData, int> inventoryData = new Dictionary<ItemData, int>();
    public ItemStructure itemForInventory;
    public Canvas inventoryCanvas;
    private bool changeState = true;
    public GameObject UIPrefab;
    public GameObject ContentRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryCanvas.enabled = changeState;
            changeState = !changeState;
            PutOnUI();
            //cambiar el estado del mouse
        }
    }
    public void PutOnUI()
    {
        Debug.Log("ora");
        for (int index = 0; 0 < itemForInventory.items.Count; index++)
        {
            Debug.Log("ora2");
            GameObject tempGO = UIPrefab;
            PrefabReferences refs = tempGO.GetComponent<PrefabReferences>();
            refs.titulo.text = itemForInventory.items[index].Name;
            Sprite newSprite = Resources.Load<Sprite>(itemForInventory.items[index].imagePath);
            refs.image.sprite = newSprite;
            refs.description.text = itemForInventory.items[index].Description;
            refs.quantity.text = itemForInventory.items[index].quantity.ToString();
            if (itemForInventory.items[index].typeID == 1)
            {
                refs.buton.SetActive(true);
                refs.Consumible.text = "Consumible";
            }
            if (itemForInventory.items[index].typeID == 11)
            {
                refs.Consumible.text = "No Consumible";
            }
            Instantiate(tempGO, ContentRef.transform);
        }

    }
    public void AddItem(ItemData item)
    {
        if (inventoryData.ContainsKey(item))
        {
            inventoryData[item]++;
            Debug.Log("El item " + inventoryData[item] + " se a actializado");
        }
        else
        {
            inventoryData.Add(item, 1);
        }
        Debug.Log("Ahora hay " + inventoryData.Count + " items");
    }
    [ContextMenu("SaveToJsonTry")]
    public void SaveOnJson()
    {
        string path = Path.Combine(Application.persistentDataPath, "InventoryJSON.json");
        ItemStructure itemStructure = new ItemStructure();
        itemStructure.items = new List<ItemSOB>();
        foreach (ItemData item in inventoryData.Keys)
        {

            ItemSOB tempSob = new ItemSOB();
            tempSob.Name = item.Nombre;
            tempSob.imagePath = item.imagePath;
            tempSob.Description = item.description;
            tempSob.quantity = inventoryData[item];
            tempSob.typeID = item.typeID;

            Debug.Log(itemStructure.items);
            itemStructure.items.Add(tempSob);
            Debug.Log(itemStructure.items.Count + "son los objetos q hay");
        }
        string newJsonToSave = JsonUtility.ToJson(itemStructure, true);
        File.WriteAllText(path, newJsonToSave);
        Debug.Log("Guardado en: " + path);
    }
    [ContextMenu("LoadFromJson")]
    public void LoadFromJson()
    {
        string path = Path.Combine(Application.persistentDataPath, "InventoryJSON.json");
        string jsonson = File.ReadAllText(path);
        itemForInventory = JsonUtility.FromJson<ItemStructure>(jsonson);
    }
}
