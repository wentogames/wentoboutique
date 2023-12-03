using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] Image itemImage;

    public void PopulatePrefab(string name, Sprite sprite)
    {
        nameText.text = name;
        itemImage.sprite = sprite;
    }
}
