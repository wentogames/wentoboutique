using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dressings", menuName = "ScriptableObjects/Dressings", order = 1)]
public class DressingSO : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public Sprite sprite;
    public Type type;
    public int itemId;
    public int price;
    public bool ownedItem;
}
