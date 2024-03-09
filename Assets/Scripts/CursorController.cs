using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{ 
    public Texture2D cursor;
    public Texture2D activeCursor;
    private Camera _mainCamera;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    
    public void OnMouseOver(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay((Vector3)Mouse.current.position.ReadValue()));
        if (rayHit.collider == null) SetNormalCursor();

        Debug.Log(rayHit.collider.gameObject.name);
    }
    
    
    
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
