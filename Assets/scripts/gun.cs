using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class gun : MonoBehaviour
{
    public Transform fpscam;
    public float range = 20f;
    public float impactforce = 150f;
    public int damageamount = 20;
    public int firerate = 10;
    private float nextTimeToFire = 0;
    public ParticleSystem muzzleflash;
    public GameObject impacteffect;


    public int currentAmmo;
    public int maxAmmo =10;
    public int magazineSize = 30;

    public float reloadtime = 2f;
    public bool isreloading;
        public Animator animator;
        InputAction shoot;
    void Start()
    {
        shoot = new InputAction("Shoot",binding: "<mouse>/leftButton");
        shoot.AddBinding("<Gamepad>/x");
        shoot.Enable();
        currentAmmo = maxAmmo;

    }
    private void OnEnable() {
        isreloading = false;
        animator.SetBool("isreloading",false);
    }

    void Update()
    {
        if(currentAmmo == 0 && magazineSize == 0)
        {
            animator.SetBool("isshooting", false);
            return;
        }
        if(isreloading)
        return;
        bool isshooting = shoot.ReadValue<float>() == 1; 
         animator.SetBool("isshooting", isshooting);
         if(isshooting && Time.time >= nextTimeToFire)
         {
             nextTimeToFire = Time.time + 1f/firerate;
             fire();

         }
         if(currentAmmo == 0 && magazineSize > 0 && !isreloading)
         {
            StartCoroutine(Reload());
         } 
         else{
          currentAmmo = 10 ;
          magazineSize = 30;
         }
    }
    private void fire()
    {
        AudioManager.instance.Play("Shoot");  

        muzzleflash.Play();

        currentAmmo--;

        RaycastHit hit;
       if(Physics.Raycast(fpscam.position, fpscam.forward, out hit,range ))
       {
           if(hit.rigidbody != null)
           {
               hit.rigidbody.AddForce(-hit.normal * impactforce );
           }

        enemy e = hit.transform.GetComponent<enemy>();//getting e
        if(e!= null)
        {
            e.takedamage(damageamount);
            return;
        }


           Quaternion impactrotation = Quaternion.LookRotation(hit.normal);
           GameObject impact = Instantiate(impacteffect, hit.point,impactrotation);
           impact.transform.parent = hit.transform;
           Destroy(impact,5);
       }
    }
IEnumerator Reload()
{
isreloading = true;
animator.SetBool("isreloading",true);
yield return new WaitForSeconds(reloadtime);
animator.SetBool("isreloading",false);

if(magazineSize >= maxAmmo)
{
    currentAmmo = maxAmmo;
    magazineSize -= maxAmmo;
}
else{
    currentAmmo = magazineSize;
    magazineSize = 0;
}
isreloading = false;
}

}
