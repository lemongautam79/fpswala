using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public GameObject impacteffect;
    public float radius = 3;
    public int damageamount = 15;
    private void OnCollisionEnter(Collision other) 
    {
        FindObjectOfType<AudioManager>().Play("Explosion");
        GameObject impact = Instantiate(impacteffect, transform.position, Quaternion.identity);
       // Destroy(impacteffect,2);
        Destroy(impact,2);
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);

        foreach(Collider nearbyObject in colliders)
        {
              if(nearbyObject.tag == "Player")
              {
                  StartCoroutine(FindObjectOfType<playermanager>().takadamage(damageamount));
              }
        }
        this.enabled = false;
    }
}
