using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    // Start is called before the first frame update
    void Start()
    {
        //sets cursor to crosshair texture
        Cursor.SetCursor(cursorTexture,Vector2.zero, CursorMode.Auto);
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
