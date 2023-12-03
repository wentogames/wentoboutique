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
    private DressingSO _scriptableObject;

    public void PopulatePrefab(DressingSO scriptable)
    {
        nameText.text = scriptable.name;
        itemIcon.sprite = scriptable.icon;
        _scriptableObject = scriptable;
        priceText.text = scriptable.price.ToString();
    }

    public void WearItem()
    {
        AvatarCustomizer.Instance.WearItem(_scriptableObject);
    }
}
