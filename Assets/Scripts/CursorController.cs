using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{ 
    public Texture2D cursor;
    public Texture2D activeCursor;
    private Vector2 cursorHotspot;
    private Vector2 activeCursorHotspot;
    
    
    // Aşağıdaki kodlar, mouse'un collider'a çarptığında çalışması için kullanılacaktı, ama problemi çözdük.
    
    //private Camera _mainCamera;
    //private InputAction _mouseAction; 

    /*private void Awake()
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
    }*/

    void Start() {
        // Cursor'u göz yapıyoruz. Ve cursor'un hot spot'unu ayarlıyoruz.
        cursorHotspot = new Vector2(cursor.width / 2f, cursor.height / 2f);
        activeCursorHotspot = new Vector2(activeCursor.width / 2f, activeCursor.height / 2f);
        Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto); 
    }  
    
    public void SetActiveCursor()
    {
        //Atla mouse collide olduğunda oyuncuya feedback ver.
        Cursor.SetCursor(activeCursor, activeCursorHotspot, CursorMode.Auto);
    }

    public void SetNormalCursor()
    {
        //feedback'i kapat.
        Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);
    }
}
