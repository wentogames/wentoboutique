using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    public DressingSO[] GameItems;

    private const string InventoryList = "InventoryList";

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        if (PlayerPrefs.HasKey(InventoryList))
        {
            string prefs = PlayerPrefs.GetString(InventoryList);
            GameItems = JsonConvert.DeserializeObject<DressingSO[]>(prefs);
        }
        else
        {
            var json = JsonConvert.SerializeObject(GameItems);
            PlayerPrefs.SetString(InventoryList, json);
            PlayerPrefs.Save();
        }
    }

    public void AddToOwnedItems(int id)
    {
        //GameItems[id].ownedItem = true;
        Debug.Log("Items purchased!");

        var json = JsonConvert.SerializeObject(GameItems);
        PlayerPrefs.SetString(InventoryList, json);
        PlayerPrefs.Save();
    }
}
