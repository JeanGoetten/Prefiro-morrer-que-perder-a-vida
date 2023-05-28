using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public static string model; 
    public static float force; 
    public static float fireRate; 
    public static int magazineSize; 
    public static float reloadTime; 
    public static GameObject bullet; 

    public List<WeaponStats> weapons; 

    private SpriteRenderer spriteRenderer; 

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        spriteRenderer.sprite = null; 
    }

    private void Update() {
        if(weapons[MimicSpawn.randomIndex].sprite == null){
            Shooting.canShoot = false; 
        }else{
            Shooting.canShoot = true; 
        }
        //Debug.Log(MimicSpawn.randomIndex);
        spriteRenderer.sprite = weapons[MimicSpawn.randomIndex].sprite; 
        bullet = weapons[MimicSpawn.randomIndex].bullet; 
        force = weapons[MimicSpawn.randomIndex].force; 
        fireRate = weapons[MimicSpawn.randomIndex].fireRate; 
    }
}