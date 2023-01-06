using UnityEngine;

public class MouseMovement : MonoBehaviour
{
   
    public Texture2D cursorTexture, cursorTextureRed;
    public Vector2 hotSpot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;
    

    void Start()
    {  
        // Show the cursor
        Cursor.visible = true;

        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
    }

     void OnMouseOver()
    {
        Cursor.SetCursor(cursorTextureRed, hotSpot, CursorMode.Auto);

        // if(Cursor == )
    }
}

