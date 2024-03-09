using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class Horse : MonoBehaviour
{
    private string _horseName; 
    private float _speed;
    private string _color;
    private int _age;
    private int _jockeyName;
    [SerializeField] private bool isRunning = false;

    public Horse(string horseName, float speed, string color, int age, int jockeyName)
    {
        _horseName = horseName;
        _speed = speed;
        _color = color;
        _age = age;
        _jockeyName = jockeyName;
    } 
    
    public void Run(bool boolean)
    {
        isRunning = boolean;
    }

    public bool GetRunningStatus()
    {
        return isRunning;
    }
    
    public Dictionary<String,Object> GetHorseInfo()
    {
        Dictionary<String,Object> horseInfo = new Dictionary<String,Object>
        {
            { "Horse Name", _horseName },
            { "Speed", _speed },
            { "Color", _color },
            { "Age", _age },
            { "Jockey Name", _jockeyName }
        };
        return horseInfo;
    }
}
