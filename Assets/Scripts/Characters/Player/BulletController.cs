using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public static float lifeTime = 1f; 
    public GameObject FX_impact; 
    void Start()
    {
        StartCoroutine(DeathDelay()); 
    }

    IEnumerator DeathDelay(){
        yield return new WaitForSeconds(lifeTime); 
        Destroy(gameObject); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Instantiate(FX_impact, transform.position, transform.rotation); 
            Destroy(this.gameObject);
        }
    }
}