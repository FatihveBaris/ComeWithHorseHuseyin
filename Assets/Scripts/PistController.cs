using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistController : MonoBehaviour
{
    public int turAtisi; // Her Sprite Looper döngüsünde 1 azalacak.
    public static bool turAtildiMi = false;
    private GameObject pist1;
    private GameObject pist2;
    private GameObject pistFinal;

    private void Start()
    {
        // Tek sayılarda pist1 yok edilip yerine finish pisti konulacak.
        pist1 = GameObject.Find("pist1");
        pist2 = GameObject.Find("pist2");
        pistFinal = GameObject.Find("pistFinal");
    }

    void Update()
    {
        if (turAtildiMi)
        {
            turAtisi--;
        }

        if (turAtisi == 0)
        {
            pistFinal.SetActive(true);
            // Eğer {turatisi} tur tamamlandıysa, son pisti ortaya çıkar. 
            if (turAtisi % 2 != 0)
            {
                //tekse, pist1
                pistFinal.transform.position = pist1.transform.position;
                Destroy(pist1); 
            }else
            {
                //çiftse, pist2
                pistFinal.transform.position = pist2.transform.position;
                Destroy(pist2);
            }
        }
    }
}
