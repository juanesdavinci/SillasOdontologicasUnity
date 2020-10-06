using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCtrl : MonoBehaviour
{
    public GameObject TapWater;
    public GameObject PipeWater;
    public Light Spotlight;
    public Light SubSpotlight;
    public GameObject Quad;
    
    public float timeBack = 1;
    public float timeChair = 1;
    public float timePlateLift = 1;
    public float timePlateOpen = 1;
    public float timePlateArmOpen = 1;

    private bool liftBack;
    private bool lowerBack;
    private bool liftChair;
    private bool lowerChair;

    [SerializeField]
    private bool lowerPlate;
    [SerializeField]
    private bool liftPlate;
    [SerializeField]
    private bool openPlate;
    [SerializeField]
    private bool closePlate;

    private bool openArmPlate;
    private bool closeArmPlate;

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

    internal void OnLowerPlate()
    {
        lowerPlate = true;
    }

    internal void OffLowerPlate()
    {
        lowerPlate = false;
    }

    internal void OnLiftPlate()
    {
        liftPlate = true;
    }

    internal void OffLiftPlate()
    {
        liftPlate = false;
    }

    internal void OnOpenArmPlate()
    {
        openArmPlate = true;
    }
    internal void OffOpenArmPlate()
    {
        openArmPlate = false;
    }

    internal void OnCloseArmPlate()
    {
        closeArmPlate = true;
    }

    internal void OffCloseArmPlate()
    {
        closeArmPlate = false;
    }

    internal void OnOpenPlate()
    {
        openPlate = true;
    }
    internal void OffOpenPlate()
    {
        openPlate = false;
    }
    internal void OnClosePlate()
    {
        closePlate = true;
    }
    internal void OffClosePlate()
    {
        closePlate = false;
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

    public void LiftPlate()
    {

        if (timePlateLift < 1)
            timePlateLift += 0.01f;
        PlayAnimationStep("subirBandeja", timePlateLift, 2);
    }

    public void LowerPlate()
    {
        if (timePlateLift > 0)
            timePlateLift -= 0.01f;
        PlayAnimationStep("bajarBandeja", (1 - timePlateLift), 2);
    }

    public void OpenPlate()
    {

        if (timePlateOpen < 1)
            timePlateOpen += 0.01f;
        PlayAnimationStep("abrirBandeja", timePlateOpen, 2);
    }

    public void ClosePlate()
    {
        if (timePlateOpen > 0)
            timePlateOpen -= 0.01f;
        PlayAnimationStep("cerrarBandeja", (1 - timePlateOpen), 2);
    }

    public void OpenArmPlate()
    {

        if (timePlateArmOpen < 1)
            timePlateArmOpen += 0.01f;
        PlayAnimationStep("brazoBandejaAbrir", timePlateArmOpen, 3);
    }
    public void CloseArmPlate()
    {
        if (timePlateArmOpen > 0)
            timePlateArmOpen -= 0.01f;
        PlayAnimationStep("brazoBandejaCerrar", (1 - timePlateArmOpen), 3);
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

        if (liftPlate)
        {
            LiftPlate();
        }

        if (lowerPlate)
        {
            LowerPlate();
        }

        if (openPlate)
        {
            OpenPlate();
        }

        if (closePlate)
        {
            ClosePlate();
        }

        if (openArmPlate)
        {
            OpenArmPlate();
        }

        if (closeArmPlate)
        {
            CloseArmPlate();
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

    public void SetQuad(bool isEnabled)
    {
        Quad.SetActive(isEnabled);
    }
}
