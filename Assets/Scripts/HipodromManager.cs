using System.Collections.Generic;
using UnityEngine;

public class HipodromManager : MonoBehaviour
{ 
    public List<Horse> horses; // At objelerinizi burada saklayın
    private List<float> speeds = new List<float> {0.3f, 0.4f, 0.5f};
    private float remainingSpeed = 0.2f;

    private void Start()
    {
        // Speed değerlerini karıştır
        for (int i = 0; i < speeds.Count; i++)
        {
            float temp = speeds[i];
            int randomIndex = Random.Range(i, speeds.Count);
            speeds[i] = speeds[randomIndex];
            speeds[randomIndex] = temp;
        }

        // At objelerine hız değerlerini ata
        for (int i = 0; i < speeds.Count; i++)
        {
            if (i != GameManager.BirinciSecilenAt)
            { 
              horses[i].ChangeSpeed(-(horses[i].speed - speeds[i]));
            }
        }

        // Kalan hızı belirli bir ata ata
        horses[GameManager.BirinciSecilenAt].ChangeSpeed(-(horses[GameManager.BirinciSecilenAt].speed - remainingSpeed));
    }
}
