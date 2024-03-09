using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLooper : MonoBehaviour
{
    public GameObject spritePrefab; // Sprite prefab'ınızı buraya sürükleyin
    public float movementSpeed = 5f; // Sprite'ların hareket hızı
    public Vector3 spawnPoint; // Yeni sprite'ların oluşacağı nokta

    private void Update()
    {
        // Mevcut sprite'ları sola doğru hareket ettir
        transform.Translate(-movementSpeed * Time.deltaTime, 0, 0);

        // Eğer sprite kameranın sol tarafına geçerse
        if (transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 1.95f)).x)
        {
            // Yeni bir sprite oluştur
            Instantiate(spritePrefab, spawnPoint, Quaternion.identity);

            // Mevcut sprite'ı sil
            Destroy(gameObject);
        }
    }
}

