using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Navigator_07 : MonoBehaviour{
    // Start is called before the first frame update

    public GameObject Traget_01;
    public float speed = .01f;

    private Vector3 direction;
    private Vector3 direction_Normal;
    private float stopDist = .1f;
    void Start(){
        direction = Traget_01.transform.position - transform.position;
        direction_Normal = GetNormalizedVector(direction);
    }

    // Update is called once per frame
    void Update(){
        if (Vector3.Distance(Traget_01.transform.position, transform.position) > stopDist){
            transform.position += direction_Normal * speed;
            float angle = GetAngle(new Vector3 (0, 1 ,0), direction_Normal); // get angle between y axis and direction
            Debug.Log("Angle: " + (angle * 180 / Mathf.PI));
        }
    }

    float GetDotProduct(Vector3 a, Vector3 b){
        return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z));
    }
    float GetMagnitude(Vector3 source){
        return Mathf.Sqrt(
            GetSquare(source.x) +
            GetSquare(source.y) +
            GetSquare(source.z)
             );
    }

    float GetAngle(Vector3 a, Vector3 b){
        float result = GetDotProduct(a, b) / (GetMagnitude(a) * GetMagnitude(b));
        return Mathf.Acos(result); // radian  ---> to degree  * 180/Mathf.PI
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


