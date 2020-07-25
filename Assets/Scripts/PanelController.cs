using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public List<GameObject> Panels;

    public void DisablePanels()
    {
        foreach (var panel in Panels)
        {
            
            panel.SetActive(false);
        }
    }
}
