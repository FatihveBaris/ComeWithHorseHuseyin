using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapilarController : MonoBehaviour
{ 
    // Update is called once per frame
    void FixedUpdate()
    {
        if (SpriteLooper.gameStarted)
        { 
            transform.Translate(1.5f*Time.deltaTime*Vector3.left);
            if (Time.fixedTime == 7f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
