using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other) //check the other object
    {
        
        //all of these will use singletons from gamemanager
        
        if (other.tag == "Cube1")
        {
            GameManager.instance.Cube1Score++;
        }

        if (other.tag == "Cube2")
        {
            GameManager.instance.Cube2Score++;
        }

        if (other.tag == "Cube3")
        {
            GameManager.instance.Cube3Score++;
        }
        
    }
}
