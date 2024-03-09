using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{ 
    public Texture2D cursor;
    public Texture2D activeCursor;
    private Camera _mainCamera;
    private InputAction _mouseAction;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _mouseAction = new InputAction(type: InputActionType.PassThrough, binding: "<Mouse>/position");
        _mouseAction.performed += context => CheckForCollider(context.ReadValue<Vector2>());
        _mouseAction.Enable();
    }

    private void CheckForCollider(Vector2 mousePosition)
    {
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(mousePosition));
        if (rayHit.collider != null)
        {
            SetActiveCursor();
        }
        else
        {
            SetNormalCursor();
        }
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
