using System;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public float speed;
    public bool isRunning;
    private CursorController cursorController;
    private SpriteRenderer spriteRenderer;
    private static bool gameStarted;
    
    private void Start()
    {
        cursorController = GameObject.Find("Main Camera").GetComponent<CursorController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameStarted = SpriteLooper.gameStarted;
    }
    
    private void FixedUpdate()
    { 
        CheckBorders();
    }

    private void Update()
    { 
        if (speed>0f)
        {
            HorseMovement();
        }
    }

    private void CheckBorders()
    {
        if (transform.position.x > 7.27f)
        {
            transform.position = new Vector3(7.27f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -10f)
        {
            transform.position = new Vector3(-10f, transform.position.y, transform.position.z); 
        }
    }

    private void OnMouseEnter()
    {
        cursorController.SetActiveCursor(); 
    }

    private void OnMouseExit()
    {
        cursorController.SetNormalCursor(); 
    }
    
    public void StartRunning()
    {
        isRunning = true;  
    }
    
    public void StopRunning()
    {
        isRunning = false;  
    }
    
    public void ChangeSpeed(float newSpeed)
    {
        // koşma hızını değiştirir.
        // At normalde hareketli değil! ChangeSpeed ile hareketi başlatılacak.
        // Bu komutu Update() e falan yazmayın.
        speed = newSpeed;  
        // -5f < speed < 5f
        speed = Mathf.Max(speed, -5f);
        speed = Mathf.Min(speed, 5f);
        HorseMovement();

        if (speed > 2.50f && !isRunning)
        {
            StartRunning();
        }
        else if (speed < 2.50f && isRunning)
        {
            StopRunning();
        }
    }

    private void HorseMovement()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
        Debug.Log($"Horse is moving! Horse: {gameObject.name} , location: {transform.position}");
    }
}
