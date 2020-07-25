using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitController : MonoBehaviour
{

    public TextMeshProUGUI unitName;
    [HideInInspector] public AnimatorCtrl currAnimator;
    [HideInInspector] public ChangeChairColor ChairColor;

    public List<Unit> Units;
    // Start is called before the first frame update
    void Start()
    {
        ChangeChair(0);
    }

    public void ChangeChair(int index)
    {
        // reset all cameras
        foreach (var unit in Units)
        {
            unit.Obj.SetActive(false);
        }

        var u = Units[index];
        u.Obj.SetActive(true);
        unitName.text = u.name;
        currAnimator = u.Animator;
        ChairColor = u.ChangeColor;
    }

    public void StartAnimation(string anim)
    {
        currAnimator.StartAnimation(anim);
    }
    
    //Lift Back
    public void OnLiftBack()
    {
        currAnimator.OnLiftBack();
    }
    public void OffLiftBack()
    {
        currAnimator.OffLiftBack();
    }
    //Lower Back
    public void OnLowerBack()
    {
        currAnimator.OnLowerBack();
    }
    public void OffLowerBack()
    {
        currAnimator.OffLowerBack();
    }

    //Lift Chair
    public void OnLiftChair()
    {
        currAnimator.OnLiftChair();
    }
    public void OffLiftChair()
    {
        currAnimator.OffLiftChair();
    }
    
    //Lower Chair
    public void OnLowerChair()
    {
        currAnimator.OnLowerChair();
    }
    public void OffLowerChair()
    {
        currAnimator.OffLowerChair();
    }
    
    
    public void ChangeColor(int c)
    {
        ChairColor.ChangeColor(c);
    }
}

[Serializable]
public class Unit
{
    public string name;
    public GameObject Obj;
    public AnimatorCtrl Animator;
    public ChangeChairColor ChangeColor;

}