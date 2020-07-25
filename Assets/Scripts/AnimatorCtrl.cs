using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCtrl : MonoBehaviour
{
    public float timeBack = 1;
    public float timeChair = 1;

    private bool liftBack;
    private bool lowerBack;
    private bool liftChair;
    private bool lowerChair;
    
    public enum Animations
    {
        bajar,
        bajarespaldar,
        subebajabrazo,
        girarBandeja,
        bajaSubeBrazo,
        unidadEspaldaBaja,
        subir,
        subirEspaldar
    };

    public Animator Animator;
   
    public void StartAnimation(string anim)
    {
        Animator.speed = 1;
        Animator.SetTrigger(anim);
        
        
    }
    
    //Lift Back
    public void OnLiftBack()
    {
        liftBack = true;
    }
    public void OffLiftBack()
    {
        liftBack = false;
    }
    
    //Lower Back
    public void OnLowerBack()
    {
        lowerBack = true;
    }
    public void OffLowerBack()
    {
        lowerBack = false;
    }
    
    //Lift Chair
    public void OnLiftChair()
    {
        liftChair = true;
    }
    public void OffLiftChair()
    {
        liftChair = false;
    }
    
    //Lower Chair
    public void OnLowerChair()
    {
        lowerChair = true;
    }
    public void OffLowerChair()
    {
        lowerChair = false;
    }
    
    
    private void PlayAnimationStep(string animation, float step)
    {
        Animator.Play(animation, 0, step);
        Animator.speed = 0;
    }
    
    public void LiftBack()
    {
        if(timeBack > 0)
            timeBack-= 0.01f;
        PlayAnimationStep("bajarEspaldar", timeBack);
    }

    public void LowerBack()
    {
    
        if(timeBack < 1)
            timeBack += 0.01f;
        PlayAnimationStep("SubeEspaldar", (1-timeBack));
    }   
    
    public void LiftChair()
    {
        
        if(timeChair < 1)
            timeChair += 0.01f;
        PlayAnimationStep("subeUnidad", timeChair);
    }    
    
    public void LowerChair()
    {
        if(timeChair > 0)
            timeChair-= 0.01f;
        PlayAnimationStep("bajaUnidad", (1-timeChair));
    }
    
    private void Update()
    {
        if (liftBack)
        {
            LiftBack();
        }
        
        if (lowerBack)
        {
            LowerBack();
        }
        
        if (liftChair)
        {
            LiftChair();
        }
        
        if (lowerChair)
        {
            LowerChair();
        }
    
    }
}
