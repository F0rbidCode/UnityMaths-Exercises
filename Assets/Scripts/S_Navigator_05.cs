using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Navigator_05 : MonoBehaviour{
    // Start is called before the first frame update
    
    public GameObject Traget_01;
    public float speed = .001f;
    
    private Vector3 direction;
    private float stopDist = .1f;
    void Start() { 
        direction = Traget_01.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update(){
        if (Vector3.Distance(Traget_01.transform.position , transform.position) > stopDist) { // check for distance
            transform.position += direction * speed;
        }
    }
    // speed problem with numbers
}
