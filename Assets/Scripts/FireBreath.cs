using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : MonoBehaviour
{
    ParticleSystem particles;
    public bool isCylinder = false;
    public float offset;
    
    // Start is called before the first frame update
    void Start(){
        particles = GetComponent<ParticleSystem>();
        if (particles && particles.shape.angle == 0)
            isCylinder = true;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButton(0)){
            // read the particle's angle in degrees
            float angle = particles.shape.angle;

            // 0.5 = scale of the cylinder
            float radius = particles.shape.radius * 0.5f;

            // read the particles distance travelled, ie the length of the cone times scale of cylinder
            float range = particles.main.startLifetime.constant * particles.main.startSpeed.constant * 0.5f;

            // for each target in the scene, check if they're inside our cone
            // if they are, make their particle system go off
            foreach (Target target in Target.targets){

                float angle_01 = GetAngle(transform.up, (target.transform.position - transform.position));
                //Debug.Log("Angle: " + (angle_01 * 180 / Mathf.PI) + " vv " + target.name +
                //    "   vv   " + GetDotProduct(new Vector3(0, 0, 1), (target.transform.position - transform.position)));
                //Debug.Log("angle: " + angle + "    |radius: " + radius + "    |range: " + range);
                Debug.Log("GetOpposite: " + target.name + " vv   " + GetOpposite(angle_01, GetMagnitude(target.transform.position - transform.position)));

                if (isCylinder == false) {
                    if (
                        GetMagnitude(target.transform.position - transform.position) < range
                        && ((angle_01 * 180 / Mathf.PI) < angle)
                        ) {
                        target.Hit();
                    }
                }

                if (isCylinder == false){
                    //basic
                    //if (MathsUtils.IsInCone(target.transform.position, transform.position, transform.up, angle, range))
                    //pro
                    if (MathsUtils.IsInConePro(target.transform.position, transform.position, transform.up, angle, range, offset))
                        target.Hit();
                }else{
                    if (MathsUtils.IsInCylinder(target.transform.position, transform.position, transform.up, radius, range))
                        target.Hit();
                }

                if (isCylinder) {
                    if (GetOpposite(angle_01, GetMagnitude(target.transform.position - transform.position)) < radius) {
                        if (GetAdjacent(angle_01, GetMagnitude(target.transform.position - transform.position)) > 0) {
                            if (GetAdjacent(angle_01, GetMagnitude(target.transform.position - transform.position)) < range)
                                target.Hit();
                        }
                    }
                }

            }
        }
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
