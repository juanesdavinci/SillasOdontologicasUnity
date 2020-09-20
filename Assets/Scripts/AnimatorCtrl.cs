using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCtrl : MonoBehaviour
{
    public GameObject TapWater;
    public GameObject PipeWater;
    public Light Spotlight;
    public Light SubSpotlight;
    
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
//        Animator.SetTrigger(anim);
        ResetStates();
        Animator.SetBool(anim, true);
    }

    public void StartIngresar()
    {
        StartCoroutine(Ingresar());
    }
    
    public void StartExaminar()
    {
        StartCoroutine(Examinar());
    }
    
    private void ResetStates()
    {
        Animator.SetBool("Examinar", false);
        Animator.SetTrigger("examinar");
        Animator.SetBool("Ingresar", false);
        Animator.SetTrigger("ingresoingreso");
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
    
    
    private void PlayAnimationStep(string animation, float step, int layer)
    {
        Animator.Play(animation, layer, step);
        Animator.speed = 0;
    }
    
    public void LiftBack()
    {
        if(timeBack > 0)
            timeBack-= 0.01f;
        PlayAnimationStep("bajarEspaldar", timeBack, 1);
    }

    public void LowerBack()
    {
    
        if(timeBack < 1)
            timeBack += 0.01f;
        PlayAnimationStep("SubeEspaldar", (1-timeBack), 1);
    }   
    
    public void LiftChair()
    {
        
        if(timeChair < 1)
            timeChair += 0.01f;
        PlayAnimationStep("subeUnidad", timeChair,0);
    }    
    
    public void LowerChair()
    {
        if(timeChair > 0)
            timeChair-= 0.01f;
        PlayAnimationStep("bajaUnidad", (1-timeChair),0);
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


    public IEnumerator Ingresar()
    {
        while (!(timeBack <= 0 && timeChair <= 0))
        {
            LiftBack();
            LowerChair();
            yield return new WaitForEndOfFrame();
        }
    }
    
    public IEnumerator Examinar()
    {
        while (!(timeBack >= 1 && timeChair >= 1))
        {
            LowerBack();
            LiftChair();
            yield return new WaitForEndOfFrame();
        }
    }

    public void EnableTapWater(bool isActive)
    {
        TapWater.SetActive(isActive);
    }
    
    public void EnablePipeWater(bool isActive)
    {
        PipeWater.SetActive(isActive);
    }

    public void EnableLight(bool isEnabled)
    {
        Spotlight.gameObject.SetActive(isEnabled);
    }

    public void SetLightIntensity(int intensity)
    {
        Spotlight.intensity = intensity;
        SubSpotlight.intensity = intensity;
    }
}
