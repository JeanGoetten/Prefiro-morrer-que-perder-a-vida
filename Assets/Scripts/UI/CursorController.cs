using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D cursorDefaultTexture;
    public Texture2D cursor_01Texture;
    public Vector3 hotSpot;

    private void Start() {
        CustomCursor(); 
    }

    void OnMouseEnter()
    {
        CustomCursor(); 
    }
    void OnMouseExit()
    {
        TargetCursor(); 
    }
    public void CustomCursor(){
        Cursor.SetCursor(cursorDefaultTexture, hotSpot, CursorMode.Auto);
    }
     public void TargetCursor(){
        Cursor.SetCursor(cursor_01Texture, hotSpot, CursorMode.Auto);
    }
}