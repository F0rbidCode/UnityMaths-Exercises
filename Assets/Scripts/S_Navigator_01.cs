using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Navigator_01 : MonoBehaviour{
    
    // Start is called before the first frame update
    void Start(){ }

    // Update is called once per frame
    void Update(){
        Vector3 pos = transform.position; // vector pos(x, y, z) = my current position

        // add number to x and y element of position 
        pos.x += .02f;
        pos.y += .008f;
        
        transform.position = pos;
    }
}
