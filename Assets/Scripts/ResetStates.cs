using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStates : MonoBehaviour
{
    public List<GameObject> Objects;


    public void ResetObjects()
    {
        Objects.ForEach(a => a.SetActive(false));
    }
    
}
