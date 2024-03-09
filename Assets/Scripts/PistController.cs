using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistController : MonoBehaviour
{
    public int turAtisi; // Her Sprite Looper döngüsünde 1 azalacak.
    public int turSayisi;
    public static bool turAtildiMi = false;
    private GameObject pist1;
    private GameObject pist2;
    private GameObject pistFinal; 
    private void Awake()
    {
        turAtisi = turSayisi;
        // Tek sayılarda pist1 yok edilip yerine finish pisti konulacak.
        pist1 = GameObject.Find("pist1");
        pist2 = GameObject.Find("pist2");
        pistFinal = GameObject.Find("pistFinal");
        pistFinal.SetActive(false);
    }

    void Update()
    {
        if (turAtildiMi)
        {
            turAtisi--;
            turAtildiMi = false;
        }

        if (turAtisi == 0)
        {
            pistFinal.SetActive(true);
            // Eğer {turSayisi} tur tamamlandıysa, son pisti ortaya çıkar. 
            if (turSayisi % 2 != 0)
            {
                //tekse, pist1
                pistFinal.transform.position = pist1.transform.position;
                Destroy(pist1); 
                turAtisi--;
                
            }else
            {
                //çiftse, pist2
                pistFinal.transform.position = pist2.transform.position;
                Destroy(pist2);
                turAtisi--;
            }
        }
    }
}
