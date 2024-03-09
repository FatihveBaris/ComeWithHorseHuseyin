using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI kullanmak için gerekli kütüphane
using TMPro;

public class Countdown : MonoBehaviour
{
    public float timeLeft = 3.0f; // Geri sayım süresi
    public TextMeshProUGUI countdownText; // Geri sayımı gösterecek UI Text nesnesi

    void Update()
    {
        timeLeft -= Time.deltaTime;// Her frame'de süreyi azalt
        if (timeLeft > 0)
        {
            countdownText.text = Mathf.Ceil(timeLeft).ToString(); // Süreyi yuvarlayıp string'e çevir ve ekranda göster
        }
        else
        {
            countdownText.text = "Başla!";// Süre bittiğinde ekranda ne gösterileceği
            SpriteLooper.gameStarted = true;


            if (timeLeft < -2)
            {
                countdownText.text = " ";
            }
        }
    }
}
