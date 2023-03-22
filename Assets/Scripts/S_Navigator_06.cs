using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Navigator_06 : MonoBehaviour{
    // Start is called before the first frame update

    public GameObject Traget_01;
    public float speed = .01f;

    private Vector3 direction;
    private Vector3 direction_Normal;
    private float stopDist = .1f;
    void Start(){
        direction = Traget_01.transform.position - transform.position; // get direction
        direction_Normal = GetNormalizedVector(direction); // <-- make normal vector
    }

    // Update is called once per frame
    void Update(){
        if (Vector3.Distance(Traget_01.transform.position, transform.position) > stopDist){
            transform.position += direction_Normal * speed * Time.deltaTime;
        }
    }

    Vector3 GetNormalizedVector(Vector3 source){
        float magnitude = Mathf.Sqrt(
            GetSquare(source.x) +
            GetSquare(source.y) +
            GetSquare(source.z) 
             );
        Vector3 NormalizedVec = new Vector3(
            source.x / magnitude, 
            source.y / magnitude, 
            source.z / magnitude
            );
        return NormalizedVec;
    }
    float GetSquare(float value){   
        return value * value;   
    }
}


