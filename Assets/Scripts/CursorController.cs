using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{ 
    public Texture2D cursor;
    public Texture2D activeCursor;

    void Start() {
        // Cursor'u göz yapıyoruz. 
        Cursor.SetCursor(cursor, Vector3.zero, CursorMode.ForceSoftware);
    }  
    
    public void SetActiveCursor()
    {
        Cursor.SetCursor(activeCursor, Vector3.zero, CursorMode.ForceSoftware);
    }

    public void SetNormalCursor()
    {
        Cursor.SetCursor(cursor, Vector3.zero, CursorMode.ForceSoftware);
    }
}
