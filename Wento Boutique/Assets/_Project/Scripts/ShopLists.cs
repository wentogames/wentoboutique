using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopLists : MonoBehaviour
{
    public static ShopLists Instance;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] RectTransform hairListContent;
    [SerializeField] RectTransform hatListContent;
    [SerializeField] RectTransform clothesListContent;

    [Header("Lists")]
    [SerializeField] List<DressingSO> hairList;
    [SerializeField] List<DressingSO> hatList;
    [SerializeField] List<DressingSO> clothesList;

    [Header("Cart")]
    public TMP_Text cartValueText;
    public List<DressingSO> cartItems = new List<DressingSO>();

    private int _cartValue = 0;

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
    }

    public void LoadItems()
    {
        foreach(var item in hairList)
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

    public void UpdateCartValue(int value)
    {
        _cartValue += value;
        cartValueText.text = _cartValue.ToString();
    }

    public void PurchaseItems()
    {
        foreach (var item in cartItems)
        {
            PlayerInventory.Instance.AddToOwnedItems(item.itemId);
        }
        CanvasManager.Instance.CloseFittingRoomPanel();
    }
}
