using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] Image itemIcon;
    [SerializeField] TMP_Text priceText;
    [SerializeField] Button addToCartButton;
    [SerializeField] Sprite addToCartSprite;
    [SerializeField] Sprite removeFromCartSprite;
    private DressingSO _scriptableObject;
    private bool _isOnCart;

    public void PopulatePrefab(DressingSO scriptable)
    {
        nameText.text = scriptable.name;
        itemIcon.sprite = scriptable.icon;
        _scriptableObject = scriptable;
        priceText.text = scriptable.price.ToString();

        if (scriptable.ownedItem)
        {
            addToCartButton.interactable = false;
            priceText.text = "Owned";
        }
    }

    public void WearItem()
    {
        AvatarCustomizer.Instance.WearItem(_scriptableObject);
    }

    public void AddRemoveCart()
    {
        if (!_isOnCart)
        {
            _isOnCart = true;
            addToCartButton.image.sprite = removeFromCartSprite;
            ShopLists.Instance.UpdateCartValue(_scriptableObject.price);
            ShopLists.Instance.cartItems.Add(_scriptableObject);
        }
        else
        {
            _isOnCart = false;
            addToCartButton.image.sprite = addToCartSprite;
            ShopLists.Instance.UpdateCartValue(-_scriptableObject.price);
            ShopLists.Instance.cartItems.Remove(_scriptableObject);
        }
    }
}
