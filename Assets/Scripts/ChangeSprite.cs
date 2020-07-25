using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    public List<Sprite> Sprites;
    public Image thisImage;
    
    private int currSprite;
    public void NextSprite()
    {
        currSprite = ++currSprite % Sprites.Count;
        thisImage.sprite = Sprites[currSprite];
    }

    public void ChangeSpriteTo(int i)
    {
        thisImage.sprite = Sprites[i];
    }
}
