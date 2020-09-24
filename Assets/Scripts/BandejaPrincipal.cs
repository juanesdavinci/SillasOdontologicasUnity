using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandejaPrincipal : MonoBehaviour
{
    public GameObject Bandeja8000;
    public GameObject Bandeja8500LED;

    private GameObject _currObject;

    private void Awake()
    {
        SetBandeja8000();
    }

    public void SetBandeja8000()
    {
        SetObjectActive(false);
        _currObject = Bandeja8000;
        SetObjectActive(true);
    }
    
    public void SetBandeja8500()
    {
        SetObjectActive(false);
        _currObject = Bandeja8500LED;
        SetObjectActive(true);
    }

    public void SetObjectActive(bool isActive)
    {
        if(_currObject == null)
            _currObject = Bandeja8000;
        
        _currObject.SetActive(isActive);
    }
    
}
