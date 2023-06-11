using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_SummonCircleController : MonoBehaviour
{
    public float timeToDestroy = 0.1f; 
    void Start()
    {
        StartCoroutine(cd()); 
    }

    // Update is called once per frame
    IEnumerator cd(){
        yield return new WaitForSeconds(timeToDestroy); 
        Destroy(this.gameObject); 
    }
}
