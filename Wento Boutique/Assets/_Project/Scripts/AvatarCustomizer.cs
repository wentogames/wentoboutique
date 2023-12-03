using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarCustomizer : MonoBehaviour
{
    public static AvatarCustomizer Instance;
    [SerializeField] Image avatarHairImage;
    [SerializeField] Image avatarHatImage;
    [SerializeField] Image avatarClothesImage;

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
}
