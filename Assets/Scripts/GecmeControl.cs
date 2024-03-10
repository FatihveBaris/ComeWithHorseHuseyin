using System.Collections.Generic;
using UnityEngine;

public class GecmeControl : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();
    private float counter = 0f;

    void Update()
    {
        counter += Time.deltaTime;
        Debug.Log(counter);
        if (counter >= 20f)
        {
            counter = 0f;
            SortGameObjects();
        }
    }

    void SortGameObjects()
  {
        // Sort the gameObjects list based on x positions
        gameObjects.Sort((a, b) => b.transform.position.x.CompareTo(a.transform.position.x));

        // Display the order in the debug log
        for (int i = 0; i < gameObjects.Count; i++)
        {
            Debug.Log($"{i + 1}. at: x = {gameObjects[i].name}");
        }
    }

}
