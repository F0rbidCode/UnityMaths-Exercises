using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightIndicator : MonoBehaviour{
    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonDown(0))
            Flash(true);
        if (Input.GetMouseButtonDown(1))
            Flash(false);
    }

    void Flash(bool isLeft){
        foreach (Target target in Target.targets){
            //Debug.Log("target:   " + target.name);
            
            float angle = GetAngle(new Vector3 (1, 0, 0), (target.transform.position - transform.position));
            Debug.Log("Angle: " + (angle * 180 / Mathf.PI) + " vv " + target.name + 
                "   vv   " + GetDotProduct(new Vector3(1, 0, 0) , (target.transform.position - transform.position)) );

            if (MathsUtils.IsOnLeft(transform, target.transform.position) == isLeft)
                target.Hit();
        }
    }

    float GetDotProduct(Vector3 a, Vector3 b){
        return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z));
    }

    float GetAngle(Vector3 a, Vector3 b) {
        float result = GetDotProduct(a, b) / (GetMagnitude(a) * GetMagnitude(b));
        return Mathf.Acos(result); // radian  ---> to degree  * 180/Mathf.PI
    }

    float GetMagnitude(Vector3 source) {
        return Mathf.Sqrt(
            GetSquare(source.x) +
            GetSquare(source.y) +
            GetSquare(source.z)
             );
    }
    float GetSquare(float value) {
        return value * value;
    }
}
