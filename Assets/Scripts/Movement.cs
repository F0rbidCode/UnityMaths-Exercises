using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Tooltip("Forward speed in units/second")]
    public float m_Speed = 5;
    [Tooltip("Turning speed in degrees/second")]
    public float m_TurnSpeed = 90;

    float velocity = 0;
    
    bool jump = false;
    float speed = 5.2f;
    float jumpForce = 5.2f;
    float gravity = 5.2f;
    Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start(){ }

    // Update is called once per frame
    void Update(){
        transform.eulerAngles += Vector3.up * Input.GetAxis("Horizontal") * m_TurnSpeed * Time.deltaTime;
        transform.position += transform.forward * Input.GetAxis("Vertical") * m_Speed * Time.deltaTime;

        // gravity and jumping
        if (transform.position.y > 1){
            //velocity += Physics.gravity.y * Time.deltaTime;
            //velocity += (-.5f) * Time.deltaTime;
            velocity += (-.025f) * Time.deltaTime;
            //Debug.Log(Physics.gravity.y);
        }else{
            velocity = 0;
            Vector3 pos = transform.position;
            pos.y = 1;
            transform.position = pos;

            if (Input.GetKeyDown(KeyCode.Space)){
                //velocity = .1f;
                velocity = .02f;
                //velocity = 3;
            }
        }

        transform.position += Vector3.up * velocity;

        if ( !jump && Input.GetKeyDown(KeyCode.Space)) jump = true;
        if (jump) direction.y -= gravity * Time.deltaTime;

    }


}
