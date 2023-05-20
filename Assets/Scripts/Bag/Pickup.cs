using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //private Inventory inventory; 
    public GameObject itemButton; // o ícone referente ao ítem que aparecerá na bag
    // private void Start() {
    //     inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); 
    // }
    // private void OnTriggerStay2D(Collider2D other) {
    //     if(other.CompareTag("Player")){
    //         if(Input.GetKeyDown(KeyCode.Space)){
    //             for (int i = 0; i < inventory.slots.Length; i++)
    //             {
    //                 if(inventory.isFull[i] == false){
    //                     //ITEM CAN BE ADD
    //                     inventory.isFull[i] = true;
    //                     Instantiate(itemButton, inventory.slots[i].transform, false);
    //                     Destroy(gameObject);
    //                     break; 
    //                 }
    //             }
    //         }
    //     }
    // }
}
