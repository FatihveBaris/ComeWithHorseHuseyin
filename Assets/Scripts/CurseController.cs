using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseController : MonoBehaviour
{
    private float startTime;
    private float endTime;
    
    public void StartCounter()
    {
        startTime = Time.time;
    }
    
    public float EndCounter()
    {
        endTime = Time.time - startTime; 
        return endTime;
    }

    public void SetTheCurse(float curseTime, GameObject callingHorse)
    {
        //Debug.Log($"Lanetlenen at: {callingHorse.name} - Lanet süresi: {curseTime}");

        // Define the speed range based on curse time
        float minSpeed = -0.75f;
        float maxSpeed = -2.5f;

        // Interpolate the curse speed based on curse time
        float curseSpeed = Mathf.Lerp(minSpeed, maxSpeed, curseTime / 4f);

        // Apply the curse speed to the horse
        callingHorse.GetComponent<Horse>().ChangeSpeed(curseSpeed);
    }
}
