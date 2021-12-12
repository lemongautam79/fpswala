using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class scope : MonoBehaviour
{
    public Animator animator;
    public GameObject overlay;
    private bool isScoped = false;
    InputAction Scope;
    public Camera fpscamera;
    void Start()
    {
        Scope = new InputAction("Scope", binding: "<mouse>/rightButton");

        Scope.Enable();
    }

    void Update()
    {
        gun Gun = FindObjectOfType<gun>();
        if(Gun.isreloading ||Gun.currentAmmo == 0 )
        {
            onunscoped();
        }
        else{

            if(Scope.triggered)
        {
           isScoped = !isScoped;
           if(isScoped)
           {
               StartCoroutine(onscoped());
           }
           else
           {
               onunscoped();
           }
        }
        }
    }
    IEnumerator onscoped()
    {
         animator.SetBool("isScoped",true);
        yield return new WaitForSeconds(0.25f);
        fpscamera.fieldOfView = 30; 
        overlay.SetActive(true);
               fpscamera.cullingMask = fpscamera.cullingMask & ~(1<< 11);
    }
    void onunscoped()
    {
        animator.SetBool("isScoped",false);
        fpscamera.fieldOfView = 60;
        overlay.SetActive(false);
        fpscamera.cullingMask = fpscamera.cullingMask |(1<< 11);
    }
}
