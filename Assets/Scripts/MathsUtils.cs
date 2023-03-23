using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MathsUtils : MonoBehaviour {
    // return true if the point is on the right side of the given Transform
    public static bool IsOnLeft(Transform user, Vector3 point) {
        // use the dot product
        Vector3 dir = (point - user.position).normalized;
        //float dot = Vector3.Dot(dir, user.right);
        float dot = (dir.x * user.right.x) + (dir.y * user.right.y) + (dir.z * user.right.z);
        if (dot < 0 )
        {
            return true;
        }
        else
        {
            return false;
        }       
       
    }

    // returns true if the point position is inside a cone starting at origin, with a forward vector, angle in degrees and a range in units
    public static bool IsInCone(Vector3 position, Vector3 origin, Vector3 forward, float angle, float range) {
        // you'll want to transform position into the cooridinate space of the cone, and decompose it into a forward component
        // and sideways component. 

        // The forward component should be between 0 and range, and the sideways component should be less than a vale representing the radius
        // of the cone at that distance.

        // a 45 degrees cone means that sideways has to be less than or equals to 1 * range. A tigher cone has a smaller multipler.
        // what trig do we use to get this multipler?

        //get vector to target
        Vector3 toTarget = position - origin;
        //get the distance to target
        float distance = toTarget.magnitude; // sqrt(x*x + y*y + z*z)

        //get the angle to target
        float dot = (origin.x * toTarget.x) + (origin.y * toTarget.y) + (origin.z * toTarget.z);
        float angleToTarget = (Vector3.Dot(origin, toTarget) / (origin.magnitude * toTarget.magnitude));
        angleToTarget = Mathf.Acos(angleToTarget)* 180 / Mathf.PI;
        //float angleToTarget =  Vector3.Angle(origin, toTarget);
        if (distance < range && distance > 0)
        {
            if (angleToTarget < (angle))                
            { return true; }
            return false;
        }
        else
        {
            return false;
        }    
    }

    public static bool IsInConePro(Vector3 position, Vector3 origin, Vector3 forward, float angle, float range, float coneOffset)
    {

        //move the origin back by the offset
        origin.z -= coneOffset;
        //increase the range by the offset
        range += coneOffset;

        //get vector to target
        Vector3 toTarget = position - origin;
        //get the distance to target
        float distance = toTarget.magnitude; // sqrt(x*x + y*y + z*z)

        //get the angle to target
        //float dot = (origin.x * toTarget.x) + (origin.y * toTarget.y) + (origin.z * toTarget.z);
        float angleToTarget = (Vector3.Dot(origin, toTarget) / (origin.magnitude * toTarget.magnitude));
        angleToTarget = Mathf.Acos(angleToTarget) * 180 / Mathf.PI;
        //float angleToTarget =  Vector3.Angle(origin, toTarget);
        if (distance < range && distance > 0)
        {
            if (angleToTarget < (angle))
            { return true; }
            return false;
        }
        else
        {
            return false;
        }
    }

    public static bool IsInCylinder(Vector3 position, Vector3 origin, Vector3 forward, float radius, float range) {
        // you'll want to transform position into the cooridinate space of the cylinder, and decompose it into a forward component
        // and sideways component, same as the cone. 

        // The forward component should be between 0 and range, and the sideways component should be less than the radius

        //get the distance on 'z' axis away from user
        float toPosZ = position.z - origin.z;
        //get the distance on 'y' axis away from user
        float toPosX = position.x - origin.x;
        float toPosY = position.y - origin.y;

        
        Vector2 toTarget = new Vector2(toPosX, toPosY);

        if(toPosZ < range && toPosZ > 0)
        {
            if(toTarget.magnitude < radius)
            {
                return true;
            }

        }

        return false;
    }

    // return the angle in degrees from the forward axis of the user transform to the vector from user origin to pos
    public static float AngleTo(Transform user, Vector3 pos) {
        float angle = 0;
        // look up Mathf.Atan2
        // it takes cartesian coordinates (x and y) and turns them into an angle via than inverse tan (Atan), 
        // but takes care of all the fiddly stuff to do with quadrants for you.
        // atan2 is also available in C++, so its always good to know!

        // make sure your angle ranges 0 to 360 - Atan2 will return a range of -Pi to Pi in radians

        //get the vector to the target
        Vector3 toTarget = pos - user.forward;
        
        //calculate the angle
        angle = -(Mathf.Atan2(pos.z, pos.x) - Mathf.Atan2(user.forward.z, user.forward.x));

        //angle = Mathf.Atan2(toTarget.z, toTarget.x);

        //angle = Mathf.Atan2(pos.z - user.forward.z, pos.x - user.forward.x) * 180 / Mathf.PI;

        //if (angle < 0) { angle += 2 * Mathf.PI; }
        //if (angle <= Mathf.PI) { angle -= 2 * Mathf.PI; }

        
        angle = angle * 180 / Mathf.PI;
        angle = (angle + 360) % 360;
        return angle;
    }

    public static void FollowImmediate(Transform user, Vector3 target) {
        // this can be done in one line of code.
        // consider all the ways of setting rotation in Unity's Transform class

    }

    public static void FollowDelayed(Transform user, Vector3 target, float speed) {
        // find the forward vector we want


        // get the quaternion corresponding to that forward vector

        // move towards it at a steady speed. Vector3.MoveTowards is great for positions. 
        // See if Quaternions have something similar

    }

    public static void FollowImmediateHorizontal(Transform user, Vector3 target) {
        // point straight at the target as per FollowImmediate

        // zero the rotation around x and z so we're just left with rotation around y
        // is this a job for rotation, eulerANgles or the various axes Vector3s?

    }

    public static void FollowDelayedHorizontal(Transform user, Vector3 target, float speed) {

        // get the desired rotation around y using a trig helper function we've already used
        // to turn x and z into an angle

        // get the current euler angles

        // use a maths helper function that wraps us nicely around the 360 degrees boundary
        // its another 'MoveTowards' type function in Mathf namespace

        // set the current euler angles appropriately 
    }


}
