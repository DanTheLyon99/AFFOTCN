using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    void Start()
    {
        //sets cursor to crosshair texture
        //BUG Image isn't centered on the mouse position
        Cursor.SetCursor(cursorTexture,Vector2.zero, CursorMode.Auto);
    }
    
}
