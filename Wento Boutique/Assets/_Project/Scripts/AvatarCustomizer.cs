using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AvatarCustomizer : MonoBehaviour
{
    public static AvatarCustomizer Instance;
    [SerializeField] Image avatarHairImage;
    [SerializeField] Image avatarHatImage;
    [SerializeField] Image avatarClothesImage;
    [SerializeField] TMP_Text cartPriceText;

    private int _totalPrice = 0;
    private List<int> _cartIdList = new List<int>();

    private void Start()
    {
        if(Instance != null & Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void WearItem(DressingSO obj)
    {
        if(obj.type == Type.Hair)
        {
            avatarHairImage.sprite = obj.sprite;
        }
        else if(obj.type == Type.Hat)
        {
            avatarHatImage.sprite = obj.sprite;
        }
        else
        {
            avatarClothesImage.sprite = obj.sprite;
        }
    }

    public void AddToCart(DressingSO obj)
    {
        _totalPrice += obj.price;
        cartPriceText.text = _totalPrice.ToString();
        _cartIdList.Add(obj.itemId);
    }

    public void RemoveFromCart(DressingSO obj)
    {
        _totalPrice -= obj.price;
        cartPriceText.text = _totalPrice.ToString();
        _cartIdList.Remove(obj.itemId);
    }

    public void PurchaseItems()
    {
        foreach (int id in _cartIdList)
        {
            PlayerInventory.Instance.AddToOwnedItems(id);
        }
    }
}
