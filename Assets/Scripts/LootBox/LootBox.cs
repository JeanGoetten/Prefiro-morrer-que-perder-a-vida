using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    [SerializeField] 
    private int meuNumero; 
    public List<GameObject> lootBox; 
    public Animator panelAnimator; 
    public Transform itemList; 
    
    public void ObjectSetActive(GameObject objectForEnable){
        objectForEnable.SetActive(true); 
    }

    public void LootBoxChoose(){
        panelAnimator.SetBool("choosed", true); 

        int randomIndex = Random.Range(0, itemList.childCount); 
        itemList.GetChild(randomIndex).gameObject.SetActive(true);

        
        
        Debug.Log(randomIndex);
    }
}
