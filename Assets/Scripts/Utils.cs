using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    
    
    public void OpenBuyURL()
    {
        Application.OpenURL("https://www.oralgalaxy.com.co/carrito/");
    }
  public void OpenShareURL()
     {
         Application.OpenURL("https://www.oralgalaxy.com.co/contactenos/");
     }
    
    public void OpenTutorialURL()
    {
        Application.OpenURL(" https://www.oralgalaxy.com.co/app3d/Oralgalaxy-Sillas3D-Tutorial.pdf");
    }
}