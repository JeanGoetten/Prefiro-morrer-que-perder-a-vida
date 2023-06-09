using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats : MonoBehaviour
{
    public string model; 
    public bool freeFire; 
    public float force; 
    public float damage; 
    public float fireRate; 
    public int magazineSize; 
    public float reloadTime; 
    public float screenShakeForce; 
    public float bulletLifeTime; 

    public Sprite sprite; 

    public GameObject bullet; 

    public AudioClip SFX_Shot; 
    private void Update() {
        ScreenShake.duration = screenShakeForce; 
        BulletController.lifeTime = bulletLifeTime; 
    }
}
