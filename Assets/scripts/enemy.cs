using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using TMPro;

public class enemy : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilepoint;
    public int enemyhp = 100;
    public Animator animator;
//    public  bool death = false;
   public  TextMeshProUGUI deathrate;
    private int deathnumber = 0;
    
    // public delegate void enemykilled();
    // public static event enemykilled onenemykilled;

    public void Shoot()
    {
        Rigidbody rigidbody = Instantiate(projectile,projectilepoint.position,Quaternion.identity).GetComponent<Rigidbody>();
       rigidbody.AddForce(transform.forward* 30f , ForceMode.Impulse);
       rigidbody.AddForce(transform.up * 7, ForceMode.Impulse);
    }
    public void takedamage(int damageamount)
    {
        enemyhp -= damageamount;
        if(enemyhp <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.gameObject,4);
            deathnumbers();
             

            // if(onenemykilled != null)  
            // {
            // onenemykilled();
            // }
        }
        else {
             animator.SetTrigger("damage ");

        }
    }
    public void deathnumbers()
    {
        deathrate.text = deathnumber++.ToString();
    }
    
    } 
    
