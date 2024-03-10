using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiletTikParent : MonoBehaviour
{
    public Toggle[,] toggles = new Toggle[4, 4];

    void Start()
    {
        // Assuming your toggles are arranged in a 4x4 grid in the Unity Editor
        for (int row = 1; row <= 4; row++)
        {
            for (int col = 1; col <= 4; col++)
            {
                string toggleName = row.ToString() + "_" + col.ToString();
                toggles[row - 1, col - 1] = GameObject.Find(toggleName).GetComponent<Toggle>();
                toggles[row - 1, col - 1].onValueChanged.AddListener((value) => toggleDegistir(row - 1, col - 1, value));
            }
        }
    }

    public void toggleDegistir(int row, int col, bool value)
    {
        if (value && row >= 0 && row < 4 && col >= 0 && col < 4)
        {
            // Turn off other toggles in the same row
            for (int c = 0; c < 4; c++)
            {
                if (c != col)
                {
                    toggles[row, c].isOn = false;
                }
            }

            // Turn off other toggles in the same column
            for (int r = 0; r < 4; r++)
            {
                if (r != row)
                {
                    toggles[r, col].isOn = false;
                }
            }
        }
    } 
}
