using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleIndicator : MonoBehaviour{
    // Update is called once per frame
    void Update(){
        
        float angle_01 = 0.0f;
        float opposite = 0.0f;
        float adjacent = 0.0f;
        
        if (Input.GetMouseButton(0)){
            int index = 0;

            // display the order of each object, from 1 to N, clockwise
            foreach (Target target in Target.targets){
                index++;
                target.SetText(index.ToString());
            }
        }else{
            // display the actual angles above each target
            foreach (Target target in Target.targets){


                Debug.Log("GetOpposite: " + target.name  
                    + " vv  " + (target.transform.position.z - transform.position.z).ToString() + 
                    "   |   " + (target.transform.position.x - transform.position.x).ToString() );

                float angle_02 = Mathf.Atan2(target.transform.position.z - transform.position.z, target.transform.position.x - transform.position.x) * 180 / Mathf.PI;
                
                //if (angle_02 < 0 ) { angle_02 += 360; }
                
                
                //target.SetText(angle_02.ToString() );


                target.SetText(MathsUtils.AngleTo(transform, target.transform.position).ToString("0.0"));
            }
        }

        // sort the targets in order ofn their angle to the player
        Target.targets.Sort(delegate (Target a, Target b) {
            return MathsUtils.AngleTo(transform, a.transform.position).CompareTo(MathsUtils.AngleTo(transform, b.transform.position));
        });
    }

    float GetDotProduct(Vector3 a, Vector3 b) {
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

    float GetAdjacent(float ang, float Hypo) {
        return Mathf.Cos(ang) * Hypo;
    }

    float GetOpposite(float ang, float Hypo) {
        return Mathf.Sin(ang) * Hypo;
    }

}
