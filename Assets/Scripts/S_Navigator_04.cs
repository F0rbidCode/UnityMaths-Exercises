using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Navigator_04 : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject Traget_01;
    public float speed = .01f;
    
    Vector3 direction;
    
    void Start(){
        direction = Traget_01.transform.position - transform.position; // <-- vector rule of subtraction
    }

    // Update is called once per frame
    void Update(){
        transform.position += direction * speed;
    }

}
