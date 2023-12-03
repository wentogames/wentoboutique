using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLists : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] RectTransform hairListContent;
    [SerializeField] RectTransform hatListContent;
    [SerializeField] RectTransform clothesListContent;

    [SerializeField] List<DressingSO> hairList;
    [SerializeField] List<DressingSO> hatList;
    [SerializeField] List<DressingSO> clothesList;

    private void Start()
    {
        foreach (var item in hairList)
        {
            var newItem = Instantiate(itemPrefab, hairListContent);
            newItem.GetComponent<ShopItem>().PopulatePrefab(item);
        }

        foreach (var item in hatList)
        {
            var newItem = Instantiate(itemPrefab, hatListContent);
            newItem.GetComponent<ShopItem>().PopulatePrefab(item);
        }

        foreach (var item in clothesList)
        {
            var newItem = Instantiate(itemPrefab, clothesListContent);
            newItem.GetComponent<ShopItem>().PopulatePrefab(item);
        }
    }
}
