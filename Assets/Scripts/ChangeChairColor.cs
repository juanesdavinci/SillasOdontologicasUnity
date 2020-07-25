using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChairColor : MonoBehaviour
{
    public List<Color> Colors;
    public List<Renderer> ChairColorMaterial;

    private int index = 0;
    
    public void ChangeColor(int c)
    {
        foreach (var renderer1 in ChairColorMaterial)
        {
            renderer1.materials[1].color = Colors[c];
        }
    }

}
