using System;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public string horseName;
    public float speed;
    public bool isRunning;
    private CursorController cursorController;
    private SpriteRenderer spriteRenderer;
    private CurseController curseController;
    private float baseSpeed;
    public float lerpSpeed = 0.6f;
    
    private void Start()
    {
        cursorController = GameObject.Find("Main Camera").GetComponent<CursorController>();
        curseController = GameObject.Find("Main Camera").GetComponent<CurseController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseSpeed = speed;
    }
    
    private void FixedUpdate()
    { 
        CheckBorders();
        if (speed < baseSpeed)
        {
            //eğer baseSpeed, speed'den büyükse, yavaş bir şekilde speed'i base'e eşitle.
            speed = Mathf.Lerp(speed,baseSpeed, Time.deltaTime * lerpSpeed);
        }
    }

    private void Update()
    { 
        if (SpriteLooper.gameStarted)
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
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z); 
        }
    }

    private void OnMouseEnter()
    {
        cursorController.SetActiveCursor(); 
        curseController.StartCounter();
    }

    private void OnMouseExit()
    {
        cursorController.SetNormalCursor(); 
        float timePassed = curseController.EndCounter();
        curseController.SetTheCurse(timePassed, this.gameObject);
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
        speed += newSpeed;  
        // -5f < speed < 5f
        speed = Mathf.Max(speed, -0.3f);
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
        if (speed >=0f)
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime)); 
        }
        //Debug.Log($"Horse is moving! Horse: {gameObject.name} , location: {transform.position}");
    }
}
