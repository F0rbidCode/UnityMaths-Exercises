using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Navigator_03 : MonoBehaviour{

    public float speed = .1f;
    // Start is called before the first frame update
    void Start(){ }

    // Update is called once per frame
    void Update(){
        Vector3 position = transform.position;
        Move(position);
        //Move_pro();
    }

    void Move(Vector3 pos){ // using scalar value
        if (Input.GetKey(KeyCode.LeftArrow))    { pos.x -= speed; }
        if (Input.GetKey(KeyCode.RightArrow))   { pos.x += speed; }
        if (Input.GetKey(KeyCode.UpArrow))      { pos.y += speed; }
        if (Input.GetKey(KeyCode.DownArrow))    { pos.y -= speed; }
        transform.position = pos;
    }

    void Move_pro(){ // using direction vector for axis 
        if (Input.GetKey(KeyCode.LeftArrow))    { transform.position += new Vector3(-1, 0, 0) * speed; }
        if (Input.GetKey(KeyCode.RightArrow))   { transform.position += new Vector3(1, 0, 0)  * speed; }
        if (Input.GetKey(KeyCode.UpArrow))      { transform.position += new Vector3(0, 1, 0)  * speed; }
        if (Input.GetKey(KeyCode.DownArrow))    { transform.position += new Vector3(0, -1, 0) * speed; }
        if (Input.GetKey(KeyCode.E)) { transform.position += new Vector3(0, 0, 1) * speed; }
        if (Input.GetKey(KeyCode.Q)) { transform.position += new Vector3(0, 0, -1) * speed; }
    }
}