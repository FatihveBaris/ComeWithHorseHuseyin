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
        Debug.Log($"Lanetlenen at: {callingHorse.name} - Lanet süresi: {curseTime}");
        if (curseTime < 1f)
        {
            callingHorse.GetComponent<Horse>().ChangeSpeed(-0.75f);
        }
        else if (curseTime < 2f)
        {
            callingHorse.GetComponent<Horse>().ChangeSpeed(-1f);
        }
        else if (curseTime < 3f)
        {
            callingHorse.GetComponent<Horse>().ChangeSpeed(-1.5f);
        }
        else if (curseTime < 4f)
        {
            callingHorse.GetComponent<Horse>().ChangeSpeed(-2f);
        }
        else 
        {
            callingHorse.GetComponent<Horse>().ChangeSpeed(-2.5f);
        } 
    }
}
