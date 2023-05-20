using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] float acceleration = 9.8f;

    Vector3 gravityOffset;
    void Start()
    {
        if(SystemInfo.supportsGyroscope){
            Input.gyro.enabled = true;
        }
        CaliibrateGravity();
    }

    void Update()
    {
        
        Physics.gravity = GetGravityFromSensor() + gravityOffset;

        CaliibrateGravity();
    }

    public void CaliibrateGravity(){
        gravityOffset = Vector3.down * acceleration - GetGravityFromSensor();
        // new Vector3(gravity.x, gravity.z, gravity.y);
    }

    public Vector3 GetGravityFromSensor(){
        Vector3 gravity;
        if(Input.gyro.gravity != Vector3.zero){
            gravity = Input.gyro.gravity * acceleration;
        } else{
            gravity = Input.acceleration * acceleration;
        }
        gravity.z = Mathf.Clamp(gravity.z, float.MinValue, -1);
        return new Vector3(gravity.x, gravity.z, gravity.y);
    }
}
