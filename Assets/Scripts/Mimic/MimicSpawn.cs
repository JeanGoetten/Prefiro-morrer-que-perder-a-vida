using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicSpawn : MonoBehaviour
{
    public List<GameObject> itemList; 
    public bool itemSpawnAvaiable = true; 

    private Inventory inventory; 

    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); 
    }

    public void SpawnItem(){
        if(itemSpawnAvaiable){
            
            int randomIndex = Random.Range(0, itemList.Count); 
            GameObject item = Instantiate(itemList[randomIndex], 
            new Vector3(transform.position.x - 4, transform.position.y - 4, 0), transform.rotation) as GameObject;

            itemSpawnAvaiable = false; 

            for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if(inventory.isFull[i] == false){
                        //ITEM CAN BE ADD
                        inventory.isFull[i] = true;
                        Instantiate(item.GetComponent<Pickup>().itemButton, inventory.slots[i].transform, false);
                        //Destroy(gameObject);
                        break; 
                    }
                }
        }else{
            //reação do Mímico
        }
    }
}
