using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToogleAction : MonoBehaviour
{
    public bool isActive;

    public UnityEvent actionOn;
    public UnityEvent actionOff;

    public void Toggle()
    {
        isActive = !isActive;
        if(isActive)
            actionOn.Invoke();
        else
            actionOff.Invoke();
    }
}
