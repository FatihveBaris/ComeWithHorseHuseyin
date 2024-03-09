using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;

public class Horse : MonoBehaviour
{
    [SerializeField] private string _horseName; 
    [SerializeField] private float _speed;
    [SerializeField] private string _color;
    [SerializeField] private int _age;
    [SerializeField] private string _jockeyName;
    [SerializeField] private bool isRunning = false;
    private CursorController cursorController;

    private void Start()
    {
        cursorController = GameObject.Find("Main Camera").GetComponent<CursorController>();
    }

    public Horse(string horseName, float speed, string color, int age, string jockeyName)
    {
        _horseName = horseName;
        _speed = speed;
        _color = color;
        _age = age;
        _jockeyName = jockeyName;
    } 
    
    public void RunStatus(bool boolean)
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
    
    void OnMouseOver()
    { 
        cursorController.SetActiveCursor();
    }
    void OnMouseExit()
    {
        cursorController.SetNormalCursor();
    }
}
