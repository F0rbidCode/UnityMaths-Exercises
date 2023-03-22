using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Navigator_02 : MonoBehaviour{

    public Vector2 direction_01 = new Vector2(0.02f, 0.008f);
    //public Vector3 direction_02 = new Vector3(0.02f, 0.008f, 0.0f);
    
    // Start is called before the first frame update
    void Start(){ }

    // Update is called once per frame
    void Update(){
        Vector3 pos = transform.position;
        pos.x += direction_01.x;
        pos.y += direction_01.y;
        transform.position = pos;
    }
}
