using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;

public class Horse : MonoBehaviour
{
    public string _horseName; 
    public float _speed;
    public string _color;
    public int _age;
    public string _jockeyName;
    public bool isRunning = false;
    private CursorController cursorController;

    private void Start()
    {
        cursorController = GameObject.Find("Main Camera").GetComponent<CursorController>();
    }

    private void OnMouseEnter()
    {
        cursorController.SetActiveCursor();
        Debug.Log("Hipodrom: Atla collide olundu.");
    }

    private void OnMouseExit()
    {
        cursorController.SetNormalCursor();
        Debug.Log("Hipodrom: Atla collide'tan çıkıldı.");
    }
}
