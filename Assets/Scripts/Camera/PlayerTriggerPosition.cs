using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerPosition : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public Transform limboPositionForCam; 
    public Transform passPositionForCam; 
    public Transform adventurePositionForCam; 

    public new Transform camera; 

    private bool limboTriggred; 
    private bool passTriggred; 
    private bool adventureTriggred; 

    void OnTriggerStay2D(Collider2D other)
    {
            if(other.tag == "Limbo"){
                
                limboTriggred = true; 
                passTriggred = false; 
                adventureTriggred = false; 
                //Debug.Log(other.tag);
            }
            if(other.tag == "Pass"){
                
                limboTriggred = false; 
                passTriggred = true; 
                adventureTriggred = false; 
                //Debug.Log(other.tag);
            }
            if(other.tag == "Adventure"){
                
                limboTriggred = false; 
                passTriggred = false; 
                adventureTriggred = true; 
                //Debug.Log(other.tag);
            }
            
    }
    private void Update() {
        if(limboTriggred){
            Vector3 targetPos = new Vector3(limboPositionForCam.position.x, limboPositionForCam.position.y, -10);
                Vector3 velocity = (targetPos - camera.position) * moveSpeed;
			    camera.position = Vector3.SmoothDamp(camera.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
        }
        if(passTriggred){
            Vector3 targetPos = new Vector3(passPositionForCam.position.x, passPositionForCam.position.y, -10);
                Vector3 velocity = (targetPos - camera.position) * moveSpeed;
			    camera.position = Vector3.SmoothDamp(camera.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
        }
        if(adventureTriggred){
            Vector3 targetPos = new Vector3(adventurePositionForCam.position.x, adventurePositionForCam.position.y, -10);
                Vector3 velocity = (targetPos - camera.position) * moveSpeed;
			    camera.position = Vector3.SmoothDamp(camera.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
        }
    }
}