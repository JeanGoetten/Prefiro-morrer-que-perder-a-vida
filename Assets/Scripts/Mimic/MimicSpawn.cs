using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicSpawn : MonoBehaviour
{
    public List<GameObject> itemList; 
    public bool itemSpawnAvaiable = true; 

    private Inventory inventory; 

    public static int randomIndex; 

    private int lastRandomIndex; 

    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); 
        randomIndex = 0; 
    }

    public void SpawnItem(){
        if(itemSpawnAvaiable){
            
            randomIndex = Random.Range(0, itemList.Count); 
            
            while(randomIndex == 0 || randomIndex == lastRandomIndex){
                randomIndex = Random.Range(0, itemList.Count); 
            }
            GameObject item = Instantiate(itemList[randomIndex], 
            new Vector3(transform.position.x - 4, transform.position.y - 4, 0), transform.rotation) as GameObject;

            itemSpawnAvaiable = false; 
            // for one slot style
            Instantiate(item.GetComponent<Pickup>().itemButton, inventory.slots[0].transform, false);

            Debug.Log("nova arma");

            lastRandomIndex = randomIndex; 
            // for(int i = 0; i < inventory.slots.Length; i++)
            //     {
            //         if(inventory.isFull[i] == false){
            //             //ITEM CAN BE ADD
            //             inventory.isFull[i] = true;
            //             Instantiate(item.GetComponent<Pickup>().itemButton, inventory.slots[i].transform, false);
            //             //Destroy(gameObject);
            //             break; 
            //         }
            //     }
        }else{
            //reação do Mímico
        }
    }
}