using UnityEngine;

public class SpriteLooper : MonoBehaviour
{
    public float movementSpeed = 5f; // Sprite'ların hareket hızı
    public Vector3 spawnPoint; // Sprite'ın ışınlandığı nokta
    public Vector3 gecisPoint; // Sprite'ın son geçtiği nokta
    public static bool gameStarted = false; // Oyunun başladığını belirten değişken

    private void Start()
    {
        //Bunları direkt prefab'ın UI'dan ekledim.
        //spawnPoint = new Vector3(26.8f, 0f, 1.95f);
        //gecisPoint = new Vector3(-27f, 0f, 1.95f);
    }

    private void FixedUpdate()
    {
        if (gameStarted)
        { 
            transform.Translate(movementSpeed*Time.deltaTime*Vector3.left);
            if (transform.position.x <= gecisPoint.x)
            {
                this.transform.localPosition = spawnPoint;
                Debug.Log($"sprite ışınlandı: {this.transform.localPosition}");
            }
        }
    } 
}

