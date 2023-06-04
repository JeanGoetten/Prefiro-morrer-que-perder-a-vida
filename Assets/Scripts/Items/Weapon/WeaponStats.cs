using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats : MonoBehaviour
{
    public string model; 
    public float force; 
    public float damage; 
    public float fireRate; 
    public int magazineSize; 
    public float reloadTime; 
    public float screenShakeForce; 

    public Sprite sprite; 

    public GameObject bullet; 
    private void Update() {
        ScreenShake.duration = screenShakeForce; 
    }
}
