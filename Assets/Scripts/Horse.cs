using UnityEngine;

public class Horse : MonoBehaviour
{
    public float speed;
    public bool isRunning;
    private CursorController cursorController;
    private SpriteRenderer spriteRenderer;
    public Sprite runningSprite; // Assign the new sprite in the Inspector
    public Sprite walkingSprite; // Assign the new sprite in the Inspector

    private void Start()
    {
        cursorController = GameObject.Find("Main Camera").GetComponent<CursorController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    { 
        CheckBorders();
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
        if (spriteRenderer != null && runningSprite != null)
        {
            // Change the sprite
            spriteRenderer.sprite = runningSprite;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or newSprite is not assigned.");
        }
    }
    
    public void StopRunning()
    {
        isRunning = false; 
        if (spriteRenderer != null && walkingSprite != null)
        {
            // Change the sprite
            spriteRenderer.sprite = walkingSprite;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or newSprite is not assigned.");
        }
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
        transform.Translate(Vector3.right * (speed * Time.deltaTime));

        if (speed > 2.50f && !isRunning)
        {
            StartRunning();
        }
        else if (speed < 2.50f && isRunning)
        {
            StopRunning();
        }
    }
}
