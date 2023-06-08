using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public static float lifeTime = 1f; 
    // Start is called before the first frame update
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
            Destroy(this.gameObject);
        }
    }
}
