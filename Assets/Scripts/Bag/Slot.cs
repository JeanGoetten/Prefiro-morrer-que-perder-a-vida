using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory; 
    [Header("Slot Index")]
    public int i; 
    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); 
    }
    private void Update() {
        if(transform.childCount <= 0){
            inventory.isFull[i] = false; 
        }
    }
    // private void FixedUpdate() {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;
    //     if (Input.GetMouseButtonDown(1))
    //     {
    //         if (Physics.Raycast(ray, out hit, Mathf.Infinity))
    //         {
    //             //if(hit.gameObject.name == "ball");
    //             if(hit.transform.tag == "Slot"){

    //             }
    //         }
    //     }
    // }
}